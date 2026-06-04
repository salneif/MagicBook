using UnityEngine;

public class ResizePlayer : MonoBehaviour
{
    public ParticleSystem resizeEffect;
    public AudioSource transformSound;

    public Vector3 size1 = new Vector3(1f, 1f, 1f);
    public Vector3 size2 = new Vector3(1.3f, 1.3f, 1.3f);
    public Vector3 size3 = new Vector3(1.7f, 1.7f, 1.7f);
    public Vector3 size4 = new Vector3(2.2f, 2.2f, 2.2f);

    private int currentSize = 0;

    void Start()
    {
        transform.localScale = size1;
    }

    public void Grow()
    {
        currentSize++;

        Debug.Log("Grow Called: " + currentSize);

        if (currentSize == 1)
        {
            transform.localScale = size2;
        }
        else if (currentSize == 2)
        {
            transform.localScale = size3;
        }
        else if (currentSize >= 3)
        {
            transform.localScale = size4;
        }

        if (resizeEffect != null)
            resizeEffect.Play();

        if (transformSound != null)
            transformSound.Play();
    }
}