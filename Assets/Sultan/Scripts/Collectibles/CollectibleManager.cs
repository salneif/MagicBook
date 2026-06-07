using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    [SerializeField] private GameObject secondObjectToHide;
    // [SerializeField] private GameObject transitionCanvas;
    [SerializeField] private GameObject transitionImage; 
    [SerializeField] private GameObject transitionImage2;
    [SerializeField] private float transitionDelay = 20f; 
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

    public void PlayPickupSound()
    {
        if (audioSource != null)
            audioSource.Play();
    }

    public void Collect(GameObject collectible)
    {
        if (collectedThisFrame) return;
        collectedThisFrame = true;

        collectedCount++;

        if (resizePlayer != null)
        {
            // if (audioSource != null)
            // {
            //     audioSource.Play();
            // }
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
            secondObjectToHide.SetActive(false);
            // SceneManager.LoadScene(SceneToLoad);
            StartCoroutine(TransitionToScene());
        }

    }

    private IEnumerator TransitionToScene()
    {
        if (transitionImage != null)
            transitionImage.SetActive(true);

        if (transitionImage2 != null)
            transitionImage2.SetActive(true); // ADD

        yield return new WaitForSeconds(transitionDelay);

        SceneManager.LoadScene(SceneToLoad);
    }
}