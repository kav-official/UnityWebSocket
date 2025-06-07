using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ShowRolling : MonoBehaviour
{
    [Header("Button Show Spinner")]
    public StartAction buttonShow;
    [Header("Toggle Content")]
    public GameObject gameObject;
    public CanvasGroup canvasGroup;
    public float duration = 0.35f;
    public float delay = 0.05f;

    private void Awake()
    {
        canvasGroup.alpha = 0f;
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
        HidePopup();
    }

    public void ShowPopup()
    {
        buttonShow._buttonShowRolling.SetActive(false);
        gameObject.SetActive(true);

        LeanTween.cancel(gameObject);

        canvasGroup.alpha = 0f;
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f); 
        
        LeanTween.delayedCall(0.05f, () =>
        {
             LeanTween.alphaCanvas(canvasGroup, 1f, duration)
            .setEaseOutCubic();

            LeanTween.scale(gameObject, Vector3.one, duration)
            .setEaseOutElastic();
        });
    }
    public void HidePopup()
    {
        LeanTween.alphaCanvas(canvasGroup, 0f, duration * 0.8f).setEaseInCubic();
        LeanTween.scale(gameObject, Vector3.zero, duration * 0.8f)
            .setEaseInBack()
            .setOnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }
}
