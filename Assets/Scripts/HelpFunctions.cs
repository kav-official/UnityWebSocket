using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class HelpFunctions : MonoBehaviour
{
    public Vector3 originalLeftScale, originalRightScale, origin_gb_left, origin_gb_right;
    public GameObject rightDoor, leftDoor;
    public GameObject _star_gb_left, _star_gb_right;

    public CanvasGroup _canva_gb_left, _canva_gb_right, _extraBallImageLight;
    public float openDuration = 0.5f;
    public bool isOpen = false;
    public LeanTweenType easeType = LeanTweenType.easeOutBack;
    public RectTransform _textLabelExtraBall, _textLabelBall;
    public Image glowImage, glowImage2;
    private float scaleUp = 1f;
    private float scaleDown = 0.9f;
    private float delay = 1.2f;
    private float duration = 0.20f;
    [Header("References")]
    public Transform ball;
    public Transform startPoint;
    public Transform endPoint;

    [Header("Animation Settings")]
    public float fallDuration = 2f;
    public float springHeight = 0.5f; 
    public float springUpDuration = 0.3f;
    public float springDownDuration = 0.2f; 
    public AnimationCurve fallCurve;
    public AnimationCurve springUpCurve;
    public AnimationCurve springDownCurve;
    private bool isAnimating = false;
    void Start()
    {
        _canva_gb_left.alpha = 0;
        _canva_gb_right.alpha = 0;
        originalLeftScale = leftDoor.transform.localScale;
        originalRightScale = rightDoor.transform.localScale;
    }
    public void DoorOpen()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            leftDoor.SetActive(true);
            rightDoor.SetActive(true);

            LeanTween.scaleX(leftDoor, 0f, openDuration)
                .setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() =>
                {
                    leftDoor.SetActive(false);
                });
            LeanTween.scaleX(rightDoor, 0f, openDuration)
                .setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() =>
                {
                    rightDoor.SetActive(false);
                });
        }
        else
        {
            leftDoor.transform.localScale = new Vector3(0f, originalLeftScale.y, originalLeftScale.z);
            rightDoor.transform.localScale = new Vector3(0f, originalRightScale.y, originalRightScale.z);

            leftDoor.SetActive(true);
            rightDoor.SetActive(true);

            LeanTween.scaleX(leftDoor, originalLeftScale.x, openDuration)
                .setEase(LeanTweenType.easeInOutSine);
            LeanTween.scaleX(rightDoor, originalRightScale.x, openDuration)
                .setEase(LeanTweenType.easeInOutSine);
        }
    }
    public void hideStarBackgroud()
    {
        _canva_gb_left.alpha = 1;
        _canva_gb_right.alpha = 1;

        _star_gb_left.transform.localScale = new Vector3(0f, 1f, 1f);
        _star_gb_right.transform.localScale = new Vector3(0f, 1f, 1f);

        LeanTween.scaleX(_star_gb_left, 1f, 0.8f)
            .setEase(easeType);
        LeanTween.scaleX(_star_gb_right, 1f, 0.8f)
            .setEase(easeType);
    }
    public void showStarBackground()
    {
        _canva_gb_left.alpha = 0;
        _canva_gb_right.alpha = 0;

        _star_gb_left.transform.localScale = new Vector3(1f, 1f, 1f);
        _star_gb_right.transform.localScale = new Vector3(1f, 1f, 1f);

        LeanTween.scaleX(_star_gb_left, 0f, 0.8f)
            .setEase(easeType);
        LeanTween.scaleX(_star_gb_right, 0f, 0.8f)
            .setEase(easeType);
    }

    public void showExtraBallBackground()
    {
        LeanTween.scale(_textLabelExtraBall, Vector3.one * scaleDown, duration).setEaseInOutSine().setOnComplete(() =>
        {
            LeanTween.scale(_textLabelExtraBall, Vector3.one * scaleUp, duration).setEaseInOutSine()
            .setOnStart(() =>
            {
                LeanTween.value(glowImage.gameObject, 0f, 1f, duration / 2f).setOnUpdate((float val) =>
                {
                    Color c = glowImage.color;
                    c.a = val;
                    glowImage.color = c;
                });
            })
            .setOnComplete(() =>
            {
                LeanTween.value(glowImage.gameObject, 1f, 0f, duration / 2f).setOnUpdate((float val) =>
                {
                    Color c = glowImage.color;
                    c.a = val;
                    glowImage.color = c;
                });
            });
        });

        LeanTween.scale(_textLabelBall, Vector3.one * scaleDown, duration).setEaseInOutSine().setOnComplete(() =>
        {
            LeanTween.scale(_textLabelBall, Vector3.one * scaleUp, duration).setEaseInOutSine()
            .setOnStart(() =>
            {
                LeanTween.value(glowImage2.gameObject, 0f, 1f, duration / 2f).setOnUpdate((float val) =>
                {
                    Color c = glowImage2.color;
                    c.a = val;
                    glowImage2.color = c;
                });
            })
            .setOnComplete(() =>
            {
                LeanTween.value(glowImage2.gameObject, 1f, 0f, duration / 2f).setOnUpdate((float val) =>
                {
                    Color c = glowImage2.color;
                    c.a = val;
                    glowImage2.color = c;
                });
            });
        });
        LeanTween.delayedCall(delay + duration * 2, showExtraBallBackground);
    }

    public void StartDropAnimation()
    {
        if (isAnimating) return;
        isAnimating = true;
        LeanTween.cancel(ball.gameObject);
        LeanTween.move(ball.gameObject, endPoint.position, fallDuration)
            .setEase(fallCurve)
            .setOnComplete(DoSingleSpring);
    }
    public void DoSingleSpring()
    {
        Vector3 springTarget = endPoint.position + Vector3.up * springHeight;
        LeanTween.move(ball.gameObject, springTarget, springUpDuration)
            .setEase(springUpCurve)
            .setOnComplete(() => 
            {
                LeanTween.move(ball.gameObject, endPoint.position, springDownDuration)
                    .setEase(springDownCurve);
            });
    }

    public void ResetBall()
    {
        isAnimating = false;
        LeanTween.cancel(ball.gameObject);
        ball.position = startPoint.position;
        StartDropAnimation(); // Auto-start new drop
    }
    public void OnValidate()
    {
        if (fallCurve.length == 0)
        {
            fallCurve = new AnimationCurve(
                new Keyframe(0, 0, 0, 0),
                new Keyframe(0.3f, 0.1f, 1, 1),
                new Keyframe(1, 1, 0, 0));
        }
        if (springUpCurve.length == 0)
        {
            springUpCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        }
        if (springDownCurve.length == 0)
        {
            springDownCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        }
    }
}
