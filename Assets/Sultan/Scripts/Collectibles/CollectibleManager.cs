using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }

    [SerializeField] private ResizePlayer resizePlayer;
    [SerializeField] private BoxRelease boxRelease;
    [SerializeField] private int boxTriggerCount = 2;

    private int collectedCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Collect()
    {
        collectedCount++;

        if (resizePlayer != null)
            resizePlayer.Grow();

        Debug.Log($"Collected: {collectedCount}");

        if (collectedCount >= boxTriggerCount)
            boxRelease.TriggerRelease();
    }
}