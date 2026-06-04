using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }

    [SerializeField] private Transform player;
    [SerializeField] private BoxRelease boxRelease;
    [SerializeField] private GameObject hiddenCollectible;
    [SerializeField] private float scaleIncrease = 2f;
    [SerializeField] private int boxTriggerCount = 2;
    [SerializeField] private GameObject objectToHide;

    private int collectedCount = 0;
    private bool collectedThisFrame = false;

    private void Awake()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        collectedThisFrame = false;
    }

    public void Collect()
    {
        if (collectedThisFrame) return;
        collectedThisFrame = true;

        collectedCount++;
        // player.localScale += Vector3.one * scaleIncrease;
        player.localScale *= scaleIncrease;
        Debug.Log($"Player scale is now: {player.localScale}");
        Debug.Log($"Collected: {collectedCount}");

        if (collectedCount == 1 && objectToHide != null)
        {
            objectToHide.SetActive(false);
        }

        if (collectedCount >= boxTriggerCount)
        {
            boxRelease.TriggerRelease();
            if (hiddenCollectible != null)
                hiddenCollectible.SetActive(true);
        }
    }
}