using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private int plateOrder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PuzzleManager.Instance.PlateTriggered(plateOrder);
    }
}

