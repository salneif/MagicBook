using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class BoxRelease : MonoBehaviour
{
    [SerializeField] private CarAI car;
    [SerializeField] private float rotationDuration = 1.5f;
    [SerializeField] private float releaseDelay = 0.5f;

    private bool hasTriggered = false;

    // TEMP: press T to test — replace with your actual condition later
    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
            TriggerRelease();
    }

    public void TriggerRelease()
    {
        if (hasTriggered) return;
        hasTriggered = true;
        StartCoroutine(RotateAndRelease());
    }

    private IEnumerator RotateAndRelease()
    {
        Quaternion startRot = transform.rotation;
        Quaternion endRot = startRot * Quaternion.Euler(0f, 0f, -90f);
        float elapsed = 0f;

        while (elapsed < rotationDuration)
        {
            elapsed += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRot, endRot, elapsed / rotationDuration);
            yield return null;
        }

        transform.rotation = endRot;

        yield return new WaitForSeconds(releaseDelay);
        car.Release();
    }
}

// using UnityEngine;
// using UnityEngine.InputSystem;
// using System.Collections;

// public class BoxRelease : MonoBehaviour
// {
//     [SerializeField] private CarAI car;
//     [SerializeField] private float rotationDuration = 1.5f;
//     [SerializeField] private float releaseDelay = 0.5f;

//     private bool hasTriggered = false;

//     private void Update()
//     {
//         if (Keyboard.current.tKey.wasPressedThisFrame)
//             TriggerRelease();
//     }

//     public void TriggerRelease()
//     {
//         if (hasTriggered) return;
//         hasTriggered = true;
//         StartCoroutine(RotateAndRelease());
//     }

//     private IEnumerator RotateAndRelease()
//     {
//         Quaternion startRot = transform.rotation;
//         Quaternion endRot = startRot * Quaternion.Euler(90f, 0f, 0f);
//         float elapsed = 0f;

//         while (elapsed < rotationDuration)
//         {
//             elapsed += Time.deltaTime;
//             transform.rotation = Quaternion.Lerp(startRot, endRot, elapsed / rotationDuration);
//             yield return null;
//         }

//         transform.rotation = endRot;
//         yield return new WaitForSeconds(releaseDelay);
//         car.Release();
//     }
// }