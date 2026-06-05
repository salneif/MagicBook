using UnityEngine;

public class UnderBedZone : MonoBehaviour
{
    public bool PlayerInZone { get; private set; }
    private int pendingGrows = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PlayerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = false;
            for (int i = 0; i < pendingGrows; i++)
                CollectibleManager.Instance.Collect(null);
            pendingGrows = 0;
        }
    }

    public void PotionCollected()
    {
        pendingGrows++;
    }
}