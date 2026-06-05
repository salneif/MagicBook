using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform startPoint;
    public float speed = 8f;
    bool attack = false;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject trigger;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (attack)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                startPoint.position,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, startPoint.position) < 1.5f)
            {
                Destroy(gameObject);
                if (trigger != null)
                {
                    trigger.SetActive(false);
                }
            }
        }
    }

    public void StartAttack()
    {
        attack = true;
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         HealthSystem playerHealth =
    //             other.gameObject.GetComponent<HealthSystem>();

    //         if (playerHealth != null)
    //         {
    //             playerHealth.TakeDamage(20);
    //             Debug.Log(playerHealth.currentHealth);
    //         }
    //     }
    // }
}