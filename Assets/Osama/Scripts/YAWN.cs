using UnityEngine;

public class YAWN : MonoBehaviour
{
    void Start()
    {
        
        GetComponent<AudioSource>().PlayDelayed(7f);
    }
}