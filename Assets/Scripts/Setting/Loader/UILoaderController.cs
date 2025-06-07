using UnityEngine;
using UnityEngine.UI;

public class UILoaderController : MonoBehaviour
{
    public GameObject loaderPanel;
    public CanvasGroup canvasGroup;
    public float fadeDuration = 0.3f;

    void Start()
    {
        HideImmediate(); // Hide on start
    }

    public void Show()
    {
        loaderPanel.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(Fade(0f, 1f));
        Debug.Log("show time...");
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(Fade(1f, 0f, () => loaderPanel.SetActive(false)));
    }

    void HideImmediate()
    {
        canvasGroup.alpha = 0;
        loaderPanel.SetActive(false);
    }

    System.Collections.IEnumerator Fade(float from, float to, System.Action onComplete = null)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = to;
        onComplete?.Invoke();
    }
}
