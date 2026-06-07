using UnityEngine;
using UnityEngine.Playables;

public class TimelineControllerr : MonoBehaviour
{

    public PlayableDirector timeline;


    public CameraFollow cameraScript;

    void Start()
    {

        if (timeline != null && cameraScript != null)
        {

            cameraScript.enabled = false;


            timeline.stopped += OnTimelineFinished;
        }
    }


    void OnTimelineFinished(PlayableDirector director)
    {

        cameraScript.enabled = true;
    }
}