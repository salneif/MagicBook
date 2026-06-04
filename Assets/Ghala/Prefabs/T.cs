using UnityEngine;

public class T : MonoBehaviour
{
    public Ball[] balls;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Ball b in balls)
            {
                b.StartAttack();
            }
        }
    }
}