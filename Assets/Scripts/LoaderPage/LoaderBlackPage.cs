using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoaderPage : MonoBehaviour
{
    public Slider slider;
    public float progress = 2f;
    void Start()
    {
        StartSlide();
    }
    public void StartSlide()
    {
        StartCoroutine(SlideOverTime(0f, 1f, progress));
    }
    private IEnumerator SlideOverTime(float startValue, float endValue, float time)
    {
        float elapsed = 0f;
        slider.value = startValue;

        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);
            slider.value = Mathf.Lerp(startValue, endValue, t);
            yield return null;
        }
        OnSlideComplete();
    }

    private void OnSlideComplete()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("Slider complete!");
    }
}
