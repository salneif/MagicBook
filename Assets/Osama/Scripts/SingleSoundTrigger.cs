using UnityEngine;

public class SingleSoundTrigger : MonoBehaviour
{
    [Header("ÇÓÍÈ ãáİ ÇáÕæÊ ÍŞ åĞÇ ÇáÕäÏæŞ åäÇ")]
    public AudioClip mySound;

    void OnTriggerEnter(Collider other)
    {
        // ÇáÍíä ÇáßæÏ ÈíáŞØ ßÈÓæáÉ ÇááÇÚÈ pl İæÑÇğ ÈÓÈÈ ÇáÜ Rigidbody
        if (other.name == "pl" || other.CompareTag("Player"))
        {
            // äÖíİ ãßæä ÕæÊ ÈÏÇÎá ÇáÈæßÓ æäÔÛáå İæÑÇğ
            AudioSource source = gameObject.GetComponent<AudioSource>();
            if (source == null)
            {
                source = gameObject.AddComponent<AudioSource>();
            }

            source.clip = mySound;
            source.spatialBlend = 0f; // äÎáíå 2D ÚÔÇä ÊÓãÚå æÇÖÍ ÈÃĞäß İæÑÇğ
            source.Play();

            // äŞİá ÇáßæáÇíÏÑ ÍŞ ÇáÈæßÓ ÚÔÇä ãÇ íÊßÑÑ ÇáÕæÊ áæ ÊÍÑßÊ ÌæÇå
            GetComponent<Collider>().enabled = false;
        }
    }
}