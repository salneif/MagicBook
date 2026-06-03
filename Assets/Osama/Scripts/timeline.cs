using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public GameObject playerObject; // ÈäÓÍÈ ãÌÓã ÇááÇÚÈ åäÇ ãÈÇÔÑÉ

    private PlayerMovement playerScript;

    void Start()
    {
        if (playerObject != null)
        {
            // ÈÌíÈ ÇáÓßÑÈÊ ãä ãÌÓã ÇááÇÚÈ ÊáŞÇÆíÇğ ÈÏæä áİ æÏæÑÇä
            playerScript = playerObject.GetComponent<PlayerMovement>();

            if (playerScript != null)
            {
                playerScript.enabled = false; // Øİí ÇáÊÍßã æŞÊ ÇáãÔåÏ
            }
        }

        if (timelineDirector != null)
        {
            timelineDirector.stopped += OnTimelineEnded;
        }
    }

    void OnTimelineEnded(PlayableDirector director)
    {
        if (playerScript != null)
        {
            playerScript.enabled = true; // ÔÛá ÇáÊÍßã Ãæá ãÇ íÎáÕ ÇáãÔåÏ
            Debug.Log("ÇäÊåì ÇáãÔåÏ¡ ÇááÇÚÈ íÊÍÑß ÇáÂä!");
        }
    }
}