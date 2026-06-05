using UnityEngine;

public class SingleSoundTrigger : MonoBehaviour
{
    [Header("«”Õ» „·› «·’Ê  Õﬁ Â–« «·’‰œÊﬁ Â‰«")]
    public AudioClip mySound;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "pl" || other.CompareTag("Player"))
        {
            
            AudioSource source = gameObject.GetComponent<AudioSource>();
            if (source == null)
            {
                source = gameObject.AddComponent<AudioSource>();
            }

            source.clip = mySound;
            source.spatialBlend = 0f; 
            source.Play();

            
            GetComponent<Collider>().enabled = false;
        }
    }
}