using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class WildBallShake : MonoBehaviour
{
    [Header("Wild BAll")]
    public float scaleAmount = 0.01f;
    public float speed = 50f;
    private Vector3 originalScale;
    public GameObject _wildBallObject;
    public CanvasGroup _wildBallcanvas;
    [Header("Wild Content")]
    public RectTransform targetWildObject;
    private Vector2 hiddenPos;
    private Vector2 shownPos;
    private CanvasGroup canvasGroup;
    public Image countDownImage;
    public Sprite[] numberSprite;
    public float delay = 1f;
    public Coroutine countdownRoutine;
    [Header("WIldball")]
    public GameObject wildBall_W;
    void Start()
    {
        originalScale = transform.localScale;

        if (wildBall_W == null) return;
        wildBall_W.gameObject.SetActive(false);

        if (_wildBallObject == null) return;
        _wildBallObject.transform.localScale = Vector3.zero;
        _wildBallcanvas = _wildBallObject.GetComponent<CanvasGroup>();
        if (_wildBallcanvas == null)
        {
            _wildBallcanvas = _wildBallObject.AddComponent<CanvasGroup>();
        }
        _wildBallcanvas.alpha = 0f;

        // -- Wild ball content --//
        shownPos = targetWildObject.anchoredPosition;
        hiddenPos = shownPos + new Vector2(0, Screen.height);
        targetWildObject.anchoredPosition = hiddenPos;
        canvasGroup = targetWildObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = targetWildObject.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f;
    }
    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * speed) * scaleAmount;
        transform.localScale = originalScale * scale;
    }

    public void ShowWildBall_Popup()
    {
        LeanTween.alphaCanvas(_wildBallcanvas, 1f, 0.01f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(_wildBallObject, Vector3.one, 0.6f)
            .setEase(LeanTweenType.easeOutBack);
    }
    public void HideWildBall_Popup()
    {
        LeanTween.alphaCanvas(_wildBallcanvas, 0f, 0.4f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.scale(_wildBallObject, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInBack);
    }
    public void ShowWildContentTop()
    {
        LeanTween.alphaCanvas(canvasGroup, 1f, 0.4f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.move(targetWildObject, shownPos, 0.6f).setEase(LeanTweenType.easeOutBack);
    }
    public void HideWildContentTop()
    {
        LeanTween.alphaCanvas(canvasGroup, 0f, 0.3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.move(targetWildObject, hiddenPos, 0.5f).setEase(LeanTweenType.easeInBack);
    }
    public void CountDown_Wildball()
    {
        if (countdownRoutine != null)
        {
            StopCoroutine(countdownRoutine);
        }
        countdownRoutine = StartCoroutine(CountDown());
    }
    public void Stop_CountDown_Wildball()
    {
        if (countdownRoutine != null)
        {
            StopCoroutine(countdownRoutine);
            countdownRoutine = null;
            countDownImage.enabled = false;
        }
    }
    IEnumerator CountDown()
    {
        countDownImage.enabled = true;
        for (int i = 9; i >= 0; i--)
        {
            if (i < numberSprite.Length && numberSprite[i] != null)
            {
                countDownImage.sprite = numberSprite[i];
            }
            else
            {
                Debug.LogWarning("Missing sprite for number" + i);
            }
            yield return new WaitForSeconds(delay);
        }
        countDownImage.enabled = false;
        countdownRoutine = null;
    }
    //-- Wild Ball wild 
    public void showWildBall_W()
    {
        Debug.Log("wild red ball");
        wildBall_W.gameObject.SetActive(true);
    }
    public void hideWildBall_W()
    {
        Debug.Log("hide red wild");
        wildBall_W.gameObject.SetActive(false);
    }

}
