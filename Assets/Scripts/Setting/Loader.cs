using UnityEngine;
using UnityEngine.UI;

public class UILoaderButton : MonoBehaviour
{
    public GameObject loaderPanel;
    public RectTransform loaderIcon;
    public float spinSpeed = 800f;

    private bool isLoading = false;
    void Start()
    {
        OnLoaderButtonClicked();
    }
    void Update()
    {
        if (isLoading && loaderIcon != null)
        {
            loaderIcon.Rotate(0, 0, -spinSpeed * Time.deltaTime); // Spin
        }
    }

    public void OnLoaderButtonClicked()
    {
        loaderPanel.SetActive(true);
        isLoading = true;

        // Simulate loading for 3 seconds
        Invoke(nameof(HideLoader), 2f);
    }

    void HideLoader()
    {
        isLoading = false;
        loaderPanel.SetActive(false);
    }
}
