using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Collectible : MonoBehaviour
{
    public bool growOnPickup = true;
    public GameObject pressEText;

    private bool playerInRange = false;

    private void Start()
    {
        if (pressEText != null)
            pressEText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (pressEText != null)
                pressEText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (pressEText != null)
                pressEText.SetActive(false);
        }
    }

    private void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Animator animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            if (animator != null)
                animator.SetTrigger("Pickup");

            UnderBedZone zone = FindFirstObjectByType<UnderBedZone>();

            if (zone != null && zone.PlayerInZone)
                zone.PotionCollected();          // in zone → delay grow until exit
            else
                CollectibleManager.Instance.Collect(gameObject); // outside → grow now

            if (pressEText != null)
                pressEText.SetActive(false);

            Destroy(gameObject);
        }
    }
}