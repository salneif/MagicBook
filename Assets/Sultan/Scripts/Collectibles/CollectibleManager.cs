using UnityEngine;
using UnityEngine.SceneManagement;


public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }

    [SerializeField] private ResizePlayer resizePlayer;
    [SerializeField] private BoxRelease boxRelease;
    [SerializeField] private GameObject hiddenCollectible;
    [SerializeField] private float scaleIncrease = 2f;
    [SerializeField] private int boxTriggerCount = 2;
    [SerializeField] private GameObject objectToHide;
    [SerializeField] private GameObject objectToTransit;
    [SerializeField] private string SceneToLoad;
    [SerializeField] private AudioSource audioSource;

    private int collectedCount = 0;
    private bool collectedThisFrame = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        collectedThisFrame = false;
    }

    public void Collect(GameObject collectible)
    {
        if (collectedThisFrame) return;
        collectedThisFrame = true;

        collectedCount++;

        if (resizePlayer != null)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }

            resizePlayer.Grow();
        }


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

        if(objectToTransit != null && objectToTransit==collectible)
        {
            SceneManager.LoadScene(SceneToLoad);
        }

    }
}