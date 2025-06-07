using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class SimpleImageSlider : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [Header("Slider Content")]
    public Slider slider;
    public Button buttonContinue;
    public float progress = 2.5f;
    [Header("Check Content")]
    public Image checkImage;
    public Sprite defaultSprite;
    public Sprite checkSprite;
    private bool isChecked = false;
    [Header("Text Content")]
    public TextMeshProUGUI textNuumberPercent;
    private float duration = 2.5f;
    private int targetNumber = 100;
    [Header("Image slide content")]
    public RectTransform image1;
    public RectTransform image2;
    public CanvasGroup group1;
    public CanvasGroup group2;
    public Button nextButton;
    public float slideDuration = 0.5f;
    public float fadeDuration = 0.3f;
    private int currentIndex = 0;
    private Vector2 centerPosition;
    private Vector2 offscreenRight;
    private Vector2 offscreenLeft;

    void Start()
    {
        StartSlide();
        StartCounting();

        float width = image1.rect.width;

        centerPosition = image1.anchoredPosition;
        offscreenRight = centerPosition + new Vector2(width, 0);
        offscreenLeft = centerPosition - new Vector2(width, 0);

        // Initial positions
        image1.anchoredPosition = centerPosition;
        image2.anchoredPosition = offscreenRight;

        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);

        group1.alpha = 1f;
        group2.alpha = 0f;

        nextButton.onClick.AddListener(SlideNext);

        checkImage.gameObject.SetActive(false);
        buttonContinue.gameObject.SetActive(false);
    }

    public void SlideNext()
    {
        if (currentIndex == 0)
        {
            image2.gameObject.SetActive(true);

            LeanTween.move(image1, offscreenLeft, slideDuration).setEaseOutCubic();
            LeanTween.alphaCanvas(group1, 0f, fadeDuration).setEaseInOutQuad();
            LeanTween.move(image2, centerPosition, slideDuration).setEaseOutCubic();
            LeanTween.alphaCanvas(group2, 1f, fadeDuration).setEaseInOutQuad();
            // Deactivate image1 after fade
            LeanTween.delayedCall(slideDuration, () =>
            {
                image1.gameObject.SetActive(false);
            });

            currentIndex = 1;
        }
        else
        {
            image1.gameObject.SetActive(true);

            LeanTween.move(image2, offscreenRight, slideDuration).setEaseOutCubic();
            LeanTween.alphaCanvas(group2, 0f, fadeDuration).setEaseInOutQuad();
            LeanTween.move(image1, centerPosition, slideDuration).setEaseOutCubic();
            LeanTween.alphaCanvas(group1, 1f, fadeDuration).setEaseInOutQuad();
            // Deactivate image2 after fade
            LeanTween.delayedCall(slideDuration, () =>
            {
                image2.gameObject.SetActive(false);
            });

            currentIndex = 0;
        }
    }
    public void OnBeginDrag(PointerEventData eventData) { }
    public void OnEndDrag(PointerEventData eventData)
    {
        float delta = eventData.pressPosition.x - eventData.position.x;

        if (Mathf.Abs(delta) > 50f)
        {
            if (delta > 0 && currentIndex == 0) SlideNext();
            else if (delta < 0 && currentIndex == 1) SlideNext();
        }
    }

    // -- Slider 
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
        buttonContinue.gameObject.SetActive(true);
        slider.gameObject.SetActive(false);
        Debug.Log("Slider complete!");
    }
    //--- Loading Counter 
    public void StartCounting()
    {
        StartCoroutine(CountUp());
    }

    IEnumerator CountUp()
    {
        int current = 0;
        float rate = targetNumber / duration;
        float progress = 0f;

        while (current < targetNumber)
        {
            progress += Time.deltaTime * rate;
            int newValue = Mathf.FloorToInt(progress);

            if (newValue != current)
            {
                current = newValue;
                textNuumberPercent.text = current.ToString() + "%";
            }
            yield return null;
        }
        textNuumberPercent.text = targetNumber.ToString() + "%"; // Ensure final value
    }

    //----- Checker
    public void onCLickChecker()
    {
        isChecked = !isChecked;
        if (isChecked)
        {
            checkImage.gameObject.SetActive(true);
            checkImage.sprite = checkSprite;
        }
        else
        {
            checkImage.gameObject.SetActive(false);
        }
    }
    //---- button next to main scene
    public void onClickToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
