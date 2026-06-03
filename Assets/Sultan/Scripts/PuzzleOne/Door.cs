using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1.5f;
    [SerializeField] private float moveSpeed = 3f;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    public void Open()
    {
        targetPosition = transform.position + new Vector3(0f, moveDistance, 0f);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}