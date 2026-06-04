using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2.2f, -2.5f);
    public float mouseSensitivity = 3f;

    float yaw = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        Quaternion rotation = Quaternion.Euler(0, yaw, 0);

        transform.position = target.position + rotation * offset;

        transform.LookAt(target.position + Vector3.up);
    }
}