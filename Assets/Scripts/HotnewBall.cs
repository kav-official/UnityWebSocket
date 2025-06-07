using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HotnewBall : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeSpeed = 0.5f;
    private void Start()
    {
        StartCoroutine(FadeCanvasGroupLoop());
    }

    IEnumerator FadeCanvasGroupLoop()
    {
        float minAlpha = 0.12f;
        float maxAlpha = 0.22f;

        bool fadingOut = true;

        while (true)
        {
            if (fadingOut)
            {
                canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
                if (canvasGroup.alpha <= minAlpha)
                {
                    canvasGroup.alpha = minAlpha;
                    fadingOut = false;
                }
            }
            else
            {
                canvasGroup.alpha += Time.deltaTime * fadeSpeed;
                if (canvasGroup.alpha >= maxAlpha)
                {
                    canvasGroup.alpha = maxAlpha;
                    fadingOut = true;
                }
            }
            yield return null;
        }
    }


}
