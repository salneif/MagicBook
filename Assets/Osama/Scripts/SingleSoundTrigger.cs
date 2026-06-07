using UnityEngine;

public class SingleSoundTrigger : MonoBehaviour
{
    public AudioClip mySound;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "pl" || other.CompareTag("Player"))
        {
            
            AudioSource playerSource = other.GetComponent<AudioSource>();

            if (playerSource == null)
            {
                playerSource = other.gameObject.AddComponent<AudioSource>();
            }

            
            playerSource.clip = mySound;
            playerSource.spatialBlend = 0f;
            playerSource.Play();

            
            GetComponent<Collider>().enabled = false;
        }
    }
}