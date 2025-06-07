using UnityEngine;
using UnityEngine.UI;
public class can : MonoBehaviour
{
    public Image image;
    public Sprite sprite1,sprite2;
    public Button buttonSoundToggle;
    bool isPress = true;
    void Start()
    {
        buttonSoundToggle.onClick.AddListener(toggleIcon);
    }
    public void toggleIcon()
    {
        isPress = !isPress;
        if (isPress)
        {
            image.sprite = sprite1;
            Debug.Log("status 1");
        }
        else
        {
            image.sprite = sprite2;
            Debug.Log("status 0");
        }
    }
    
}
