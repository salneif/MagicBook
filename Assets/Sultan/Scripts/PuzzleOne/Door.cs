using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1.5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private AudioSource audioSource;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    public void Open()
    {
        targetPosition = transform.position + new Vector3(0f, moveDistance, 0f);

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}