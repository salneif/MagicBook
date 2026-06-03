using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        transform.position = target.position + new Vector3(0, 2.2f, -2.5f);
        transform.LookAt(target.position + Vector3.up);
    }
}