using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private float loseRadius = 15f;
    [SerializeField] private float damageRadius = 1.5f;
    [SerializeField] private float patrolRadius = 8f;
    [SerializeField] private int waypointCount = 6;
    [SerializeField] private float waypointReachDistance = 1.5f;

    private enum State { Dormant, Patrol, Chase, Hunt }
    private State state = State.Dormant;

    private NavMeshAgent agent;
    private Vector3[] waypoints;
    private int currentWaypoint = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    public void Release()
    {
        transform.SetParent(null); 
        agent.enabled = true;
        BuildWaypoints(transform.position);
        state = State.Patrol;
    }

    private void BuildWaypoints(Vector3 center)
    {
        waypoints = new Vector3[waypointCount];
        for (int i = 0; i < waypointCount; i++)
        {
            float angle = (i / (float)waypointCount) * 2f * Mathf.PI;
            Vector3 point = center + new Vector3(
                Mathf.Cos(angle) * patrolRadius,
                0f,
                Mathf.Sin(angle) * patrolRadius
            );

            NavMeshHit hit;
            waypoints[i] = NavMesh.SamplePosition(point, out hit, 5f, NavMesh.AllAreas)
                ? hit.position
                : center;
        }
    }

    private void Update()
    {
        if (state == State.Dormant) return;

        float dist = Vector3.Distance(transform.position, player.position);

        switch (state)
        {
            case State.Patrol:
                Patrol();
                if (dist <= detectionRadius)
                {
                    state = State.Chase;
                    Debug.Log("Car spotted player!");
                }
                break;

            case State.Chase:
                agent.SetDestination(player.position);
                if (dist <= damageRadius)
                    Debug.Log("Player hit! Connect to health system here.");
                if (dist > loseRadius)
                {
                    BuildWaypoints(player.position);
                    currentWaypoint = 0;
                    state = State.Hunt;
                    Debug.Log("Lost player — hunting last known area.");
                }
                break;

            case State.Hunt:
                Patrol();
                if (dist <= detectionRadius)
                {
                    state = State.Chase;
                    Debug.Log("Car spotted player again!");
                }
                break;
        }
    }

    private void Patrol()
    {
        if (waypoints == null) return;
        agent.SetDestination(waypoints[currentWaypoint]);
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint]) < waypointReachDistance)
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }
}