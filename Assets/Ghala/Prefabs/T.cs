using UnityEngine;

public class T : MonoBehaviour
{
    public Ball[] balls;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject trigger;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }

            foreach (Ball b in balls)
            {
                b.StartAttack();
            }

            if (trigger != null)
            {
                trigger.SetActive(false);
            }
        }
    }
}