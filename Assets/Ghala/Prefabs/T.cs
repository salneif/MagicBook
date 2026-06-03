using UnityEngine;

public class T : MonoBehaviour
{
    public Ball[] balls;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Ball b in balls)
            {
                b.StartAttack();
            }
        }

        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
    }
}