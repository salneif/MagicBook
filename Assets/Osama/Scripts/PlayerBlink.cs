using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleBlinkOnce : MonoBehaviour
{
    public Image blinkScreen; 

    
    public float blinkDuration = 0.15f; 
    public float timeBetweenBlinks = 0.5f; 

    void Start()
    {
        
        StartCoroutine(BlinkSequence());
    }

    IEnumerator BlinkSequence()
    {
       
        yield return StartCoroutine(QuickBlink(blinkDuration));

        
        yield return new WaitForSeconds(timeBetweenBlinks);

        
        yield return StartCoroutine(QuickBlink(blinkDuration));

        
        this.enabled = false;
    }

    IEnumerator QuickBlink(float duration)
    {
        Color c = blinkScreen.color;
        c.a = 1f; blinkScreen.color = c; 
        yield return new WaitForSeconds(duration);
        c.a = 0f; blinkScreen.color = c; 
    }
}