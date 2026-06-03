using UnityEngine;
using UnityEngine.InputSystem;

public class ResizePlayer : MonoBehaviour
{
    public ParticleSystem resizeEffect;

    bool isBig = false;

    public void OnResize()
    {
        if (resizeEffect != null)
            resizeEffect.Play();

        if (isBig)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        isBig = !isBig;
    }
}