using UnityEngine;
using UnityEngine.InputSystem;

public class Collectible : MonoBehaviour
{
    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)

        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            CollectibleManager.Instance.Collect();
            Destroy(gameObject);
        }
    }
}