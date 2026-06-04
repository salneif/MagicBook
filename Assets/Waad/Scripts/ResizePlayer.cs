using UnityEngine;

public class ResizePlayer : MonoBehaviour
{
    public ParticleSystem resizeEffect;
    public AudioSource transformSound;

    public Vector3 size1 = new Vector3(0.8f, 0.8f, 0.8f); // البداية
    public Vector3 size2 = new Vector3(1.1f, 1.1f, 1.1f); // الجرعة الأولى
    public Vector3 size3 = new Vector3(1.4f, 1.4f, 1.4f); // الجرعة الثانية
    public Vector3 size4 = new Vector3(1.8f, 1.8f, 1.8f); // الجرعة الثالثة

    private int currentSize = 0;

    void Start()
    {
        transform.localScale = size1;
    }

    public void Grow()
    {
        currentSize++;

        if (currentSize == 1)
            transform.localScale = size2;
        else if (currentSize == 2)
            transform.localScale = size3;
        else if (currentSize >= 3)
            transform.localScale = size4;

        if (resizeEffect != null)
            resizeEffect.Play();

        if (transformSound != null)
            transformSound.Play();
    }
}