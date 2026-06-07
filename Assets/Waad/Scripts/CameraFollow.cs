using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2.2f, -2.5f);
    public float mouseSensitivity = 3f;

    float yaw = 0f;
    float pitch = 15f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -20f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        float playerSize = target.localScale.y;

        Vector3 dynamicOffset = offset;
        dynamicOffset.y += (playerSize - 1f) * 2f;
        dynamicOffset.z -= (playerSize - 1f) * 1.5f;

        transform.position = target.position + rotation * dynamicOffset;

        transform.LookAt(target.position + Vector3.up * playerSize);
    }
}