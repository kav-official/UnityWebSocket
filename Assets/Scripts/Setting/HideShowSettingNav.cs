using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class SettingSlideToggle : MonoBehaviour
{
    public UILoaderController loader;
    public GameObject _inforPanel;
    public GameObject _loadInforPanel;
    public GameObject settingPanel;
    public RectTransform buttonShow;
    public RectTransform loginPanel;
    public CanvasGroup buttonShowGroup;
    public CanvasGroup loginPanelGroup;
    [Header("Sprite && Image Content")]
    public Image[] imageButton;
    public Image[] imageBackground;
    public Sprite spriteCheck, spriteDefault;
    [Header("Butons")]
    private Color activeColor = new Color(255f / 255f, 255f / 255f, 255f / 255f);
    private Color defaultColor = new Color(97f / 255f, 97f / 255f, 97f / 255f);
    private bool isToggleButton1 = false;
    private bool isToggleButton2 = false;
    private bool isToggleButton3 = false;
    private bool isToggleButton4 = false;
    private bool isToggleButton5 = false;
    [Header("############")]
    public float slideDistance = 300f;
    public float duration = 0.5f;
    private Vector2 buttonOriginalPos;
    private Vector2 panelOriginalPos;
    public Button buttonShowSettingPannel;
    bool isShow = false;
    [Header("Possible panel")]
    public RectTransform Possiblepanel;
    public CanvasGroup PanelCanvas;
    private Vector2 onScreenPosition;
    public Vector2 offScreenLeft = new Vector2(-1000f, 0);
    [Header("Loader")]
     public GameObject loaderPanel;
    public RectTransform loaderIcon;
    public float spinSpeed = 100f;
    private bool isLoading = false;
    void Start()
    {
        
        // -- Possible Panel --//
        onScreenPosition = Possiblepanel.anchoredPosition;
        Possiblepanel.anchoredPosition = offScreenLeft;
        PanelCanvas.alpha = 0;
        PanelCanvas.interactable = false;
        PanelCanvas.blocksRaycasts = false;
        Possiblepanel.gameObject.SetActive(false);
        // -- END --//
        for (int i = 0; i < imageBackground.Length; i++)
        {
            imageBackground[i].color = defaultColor;
        }
        settingPanel.SetActive(false);
        buttonOriginalPos = buttonShow.anchoredPosition;
        panelOriginalPos = loginPanel.anchoredPosition;
        // Start with panel hidden
        loginPanel.anchoredPosition = panelOriginalPos + Vector2.left * slideDistance;
        loginPanelGroup.alpha = 0f;
        loginPanelGroup.interactable = false;
        loginPanelGroup.blocksRaycasts = false;
        buttonShowSettingPannel.onClick.AddListener(onClickShowSetting);
    }
    public void ShowLoginPanel()
    {
        LeanTween.move(buttonShow, buttonOriginalPos + Vector2.left * slideDistance, duration).setEase(LeanTweenType.easeInExpo);
        LeanTween.alphaCanvas(buttonShowGroup, 0f, duration).setEase(LeanTweenType.easeInExpo)
            .setOnComplete(() => buttonShow.gameObject.SetActive(false));
        // Show loginPanel after a short delay
        loginPanel.gameObject.SetActive(true);
        LeanTween.delayedCall(0.1f, () =>
        {
            LeanTween.move(loginPanel, panelOriginalPos, duration).setEase(LeanTweenType.easeOutExpo);
            LeanTween.alphaCanvas(loginPanelGroup, 1f, duration).setEase(LeanTweenType.easeOutExpo);
            loginPanelGroup.interactable = true;
            loginPanelGroup.blocksRaycasts = true;
        });
    }
    public void HideLoginPanel()
    {
        // Slide and fade out loginPanel
        LeanTween.move(loginPanel, panelOriginalPos + Vector2.left * slideDistance, duration).setEase(LeanTweenType.easeInExpo);
        LeanTween.alphaCanvas(loginPanelGroup, 0f, duration).setEase(LeanTweenType.easeInExpo)
            .setOnComplete(() =>
            {
                loginPanel.gameObject.SetActive(false);
                loginPanelGroup.interactable = false;
                loginPanelGroup.blocksRaycasts = false;
            });
        // Show ButtonShow after a short delay
        buttonShow.gameObject.SetActive(true);
        LeanTween.delayedCall(0.1f, () =>
        {
            LeanTween.move(buttonShow, buttonOriginalPos, duration).setEase(LeanTweenType.easeOutExpo);
            LeanTween.alphaCanvas(buttonShowGroup, 1f, duration).setEase(LeanTweenType.easeOutExpo);
        });
    }
    public void ShowPossiblePanel()
    {
        Possiblepanel.gameObject.SetActive(true);
        Possiblepanel.anchoredPosition = offScreenLeft;
        PanelCanvas.alpha = 0;
        // Slide + Fade In
        LeanTween.move(Possiblepanel, onScreenPosition, duration).setEase(LeanTweenType.easeOutCubic);
        LeanTween.alphaCanvas(PanelCanvas, 1f, duration).setEase(LeanTweenType.easeOutCubic);

        PanelCanvas.interactable = true;
        PanelCanvas.blocksRaycasts = true;
    }
    public void HidePossiblePanel()
    {
        LeanTween.alphaCanvas(PanelCanvas, 0f, duration).setEase(LeanTweenType.easeInCubic);
        LeanTween.move(Possiblepanel, offScreenLeft, duration)
            .setEase(LeanTweenType.easeInCubic)
            .setOnComplete(() =>
            {
                Possiblepanel.gameObject.SetActive(false);
                PanelCanvas.interactable = false;
                PanelCanvas.blocksRaycasts = false;
            });
    }

    public void onClickShowSetting()
    {
        isShow = !isShow;
        if (isShow)
        {
            settingPanel.SetActive(isShow);
        }
        else
        {
            settingPanel.SetActive(isShow);
        }
    }
    public void onCancelSetting()
    {
        settingPanel.SetActive(!isShow);
    }
    public void onChangeBackkground_1(int index = 0)
    {
        isToggleButton1 = !isToggleButton1;
        if (isToggleButton1)
        {
            imageBackground[index].color = activeColor;
            imageButton[index].sprite = spriteCheck;
            imageButton[index].gameObject.SetActive(true);
        }
        else
        {
            imageBackground[index].color = defaultColor;
            imageButton[index].sprite = spriteDefault;
            imageButton[index].gameObject.SetActive(false);

        }
    }
    public void onChangeBackkground_2(int index = 1)
    {
        isToggleButton2 = !isToggleButton2;
        if (isToggleButton2)
        {
            imageBackground[index].color = activeColor;
            imageButton[index].sprite = spriteCheck;
            imageButton[index].gameObject.SetActive(true);
        }
        else
        {
            imageBackground[index].color = defaultColor;
            imageButton[index].sprite = spriteDefault;
            imageButton[index].gameObject.SetActive(false);

        }
    }
    public void onChangeBackkground_3(int index = 2)
    {
        isToggleButton3 = !isToggleButton3;
        if (isToggleButton3)
        {
            imageBackground[index].color = activeColor;
            imageButton[index].sprite = spriteCheck;
            imageButton[index].gameObject.SetActive(true);
        }
        else
        {
            imageBackground[index].color = defaultColor;
            imageButton[index].sprite = spriteDefault;
            imageButton[index].gameObject.SetActive(false);

        }
    }
    public void onChangeBackkground_4(int index = 3)
    {
        isToggleButton4 = !isToggleButton4;
        if (isToggleButton4)
        {
            imageBackground[index].color = activeColor;
            imageButton[index].sprite = spriteCheck;
            imageButton[index].gameObject.SetActive(true);
        }
        else
        {
            imageBackground[index].color = defaultColor;
            imageButton[index].sprite = spriteDefault;
            imageButton[index].gameObject.SetActive(false);

        }
    }
    public void onChangeBackkground_5(int index = 4)
    {
        isToggleButton5 = !isToggleButton5;
        if (isToggleButton5)
        {
            imageBackground[index].color = activeColor;
            imageButton[index].sprite = spriteCheck;
            imageButton[index].gameObject.SetActive(true);
        }
        else
        {
            imageBackground[index].color = defaultColor;
            imageButton[index].sprite = spriteDefault;
            imageButton[index].gameObject.SetActive(false);

        }
    }
    public void onClickCloseInfor()
    {
        _inforPanel.gameObject.SetActive(false);
    }
    public void onCLickLoadInfor()
    {
        OnButtonClick();
    }
    public void OnButtonClick()
    {
        loader.Show();
        Invoke(nameof(HideLater), 1f); // Simulate loading 3 seconds
    }

    void HideLater()
    {
        loader.Hide();
        _inforPanel.gameObject.SetActive(true);
    }
    
}
