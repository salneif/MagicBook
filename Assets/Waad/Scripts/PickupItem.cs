using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour
{
    public Animator animator;
    private bool canPickup = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
        }
    }

    private void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Pickup());
        }
    }

    IEnumerator Pickup()
    {
        animator.SetBool("Pickup", true);

        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);

        animator.SetBool("Pickup", false);
    }
}