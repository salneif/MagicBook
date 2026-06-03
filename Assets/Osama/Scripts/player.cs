using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 2f;
    public Transform cameraTransform; // «”Õ» „Ã”„ «·‹ CustomCam Â‰«

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        // ﬁ›· «·„«Ê” ›Ì ‰’ «·‘«‘… ⁄‘«‰ «··⁄»
        Cursor.lockState = CursorLockMode.Locked;

        //  ’›Ì— “Ê«Ì« «·œÊ—«‰ Õﬁ  «·ﬂ«„Ì—« œ«Œ·Ì« ›Ì «·ﬂÊœ ⁄‘«‰ „«  ‘ÿÕ
        if (cameraTransform != null)
        {
            Vector3 currentRot = cameraTransform.localRotation.eulerAngles;
            xRotation = 0f;
            yRotation = 0f;
        }
    }

    void Update()
    {
        // 1. ‰Ÿ«„ «·«· ›«  »«·„«Ê” («·„‘ﬂ·… «··Ì ﬂ«‰  ⁄‰œﬂ)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // «· Õﬂ„ »«·‰Ÿ— ›Êﬁ Ê Õ  (X) ÊÌ„Ì‰ ÊÌ”«— (Y)
        xRotation -= mouseY;
        yRotation += mouseX;

        // ‰ﬁ›· «·‰Ÿ— ›Êﬁ Ê Õ  ⁄‰œ 90 œ—Ã… ⁄‘«‰ „« Ìﬁ·» —«”Â ÊÌœÊŒ
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //  ÿ»Ìﬁ «·«· ›«  «·ÿ»Ì⁄Ì ⁄·Ï «·ﬂ«„Ì—« „»«‘—…
        cameraTransform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);


        // 2. ‰Ÿ«„ «·„‘Ì »«·‹ WASD (Ì„‘Ì »« Ã«Â ‰Ÿ— «·ﬂ«„Ì—« «·ÕﬁÌﬁÌ)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // ‰ÃÌ» « Ã«Â ‰Ÿ— «·ﬂ«„Ì—« ··√„«„ Ê··Ã‰»
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // ‰’›— «·‹ Y ⁄‘«‰ «··«⁄» „« ÌÿÌ— ›Ì «·”„«¡ ·Ê ÿ«·⁄ ›Êﬁ ÊÂÊ Ì„‘Ì
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Õ”«» « Ã«Â «·Õ—ﬂ… «·‰Â«∆Ì
        Vector3 moveDirection = (right * x) + (forward * z);

        //  Õ—Ìﬂ «·ﬂ»”Ê·… («··«⁄»)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}