using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform startPoint;
    public float speed = 8f;
    bool attack = false;

    void Update()
    {
        if (attack)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                startPoint.position,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, startPoint.position) < 1.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StartAttack()
    {
        attack = true;
    }
}