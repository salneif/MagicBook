using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MagicBookTeleport : MonoBehaviour
{
    public string targetSceneName = "Scene_2";
    public KeyCode interactKey = KeyCode.E;
    public float fadeSpeed = 1.0f;
    public Image fadeImage;
    public GameObject interactText;

    private bool isPlayerClose = false;
    private bool isFading = false;

    void Start()
    {
        if (interactText != null)
        {
            interactText.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerClose && Input.GetKeyDown(interactKey) && !isFading)
        {
            StartCoroutine(FadeAndLoad());
        }
    }

    IEnumerator FadeAndLoad()
    {
        isFading = true;
        if (interactText != null)
        {
            interactText.SetActive(false);
        }

        Color fadeColor = fadeImage.color;

        while (fadeColor.a < 1f)
        {
            fadeColor.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = fadeColor;
            yield return null;
        }

        SceneManager.LoadScene(targetSceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = true;
            if (interactText != null && !isFading)
            {
                interactText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = false;
            if (interactText != null)
            {
                interactText.SetActive(false);
            }
        }
    }
}