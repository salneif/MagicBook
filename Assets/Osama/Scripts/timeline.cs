using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public GameObject playerObject; 

    private PlayerMovement playerScript;

    void Start()
    {
        if (playerObject != null)
        {
            
            playerScript = playerObject.GetComponent<PlayerMovement>();

            if (playerScript != null)
            {
                playerScript.enabled = false; 
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
            playerScript.enabled = true; 
            
        }
    }
}