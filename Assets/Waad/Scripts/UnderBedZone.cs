using UnityEngine;

public class UnderBedZone : MonoBehaviour
{
    private bool potionCollected = false;

    public void PotionCollected()
    {
        potionCollected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && potionCollected)
        {
            CollectibleManager.Instance.Collect(gameObject);
            potionCollected = false;
        }
    }
}