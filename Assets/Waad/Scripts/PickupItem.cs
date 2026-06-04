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
        animator.SetTrigger("Pickup");

        yield return new WaitForSeconds(1f);

        CollectibleManager.Instance.Collect();

        gameObject.SetActive(false);
    }
}