using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFader : MonoBehaviour
{
    private bool mFaded = false;
    public float Duration = 0.4f;

    public void Fade() {
        var canvasGroup = GetComponent<CanvasGroup>();
        
        // Toggle the end value depending on the faded state
        StartCoroutine(DoFade(canvasGroup, canvasGroup.alpha, mFaded ? 1 : 0));
        
        // Toggle the faded state
        mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end) {
        float counter = 0f;

        while(counter < Duration) {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }
    }
}
