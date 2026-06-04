using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;

    [Header("Animation")]
    public Animator animator;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

        if (cameraTransform != null)
        {
            xRotation = cameraTransform.localEulerAngles.x;

            if (xRotation > 180f)
                xRotation -= 360f;
        }
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

        transform.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (right * x) + (forward * z);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Animation
        float speed = moveDirection.magnitude;
        animator.SetFloat("speed", speed);
    }
}