using UnityEngine;

public class EndCutscene : MonoBehaviour
{
    public GameObject customCam;
    public GameObject playerCam;

    public void EndScene()
    {
        customCam.SetActive(false);
        playerCam.SetActive(true);
    }
}