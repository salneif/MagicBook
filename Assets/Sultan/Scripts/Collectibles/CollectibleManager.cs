using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }

    [SerializeField] private Transform player;
    [SerializeField] private BoxRelease boxRelease;
    [SerializeField] private float scaleIncrease = 0.2f;
    [SerializeField] private int boxTriggerCount = 2;

    private int collectedCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Collect()
    {
        collectedCount++;
        player.localScale += Vector3.one * scaleIncrease;
        Debug.Log($"Collected: {collectedCount}");

        if (collectedCount >= boxTriggerCount)
            boxRelease.TriggerRelease();
    }
}