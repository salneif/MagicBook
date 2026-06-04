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
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Animator animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            animator.SetTrigger("Pickup");

            UnderBedZone zone = FindFirstObjectByType<UnderBedZone>();

            if (zone != null)
                zone.PotionCollected();

            Destroy(gameObject);
        }
    }
}