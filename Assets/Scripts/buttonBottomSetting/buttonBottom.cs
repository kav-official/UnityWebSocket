using UnityEngine;
using UnityEngine.UI;
public class buttonBottom : MonoBehaviour
{
    public Image _imageAuto;
    public Image _imageThunder;
    private Color defaultColor = new Color32(0xA6, 0xA6, 0xA6, 0xFF);
    private Color toggledColor = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
    private bool isToggled = false;
    void Start()
    {
        _imageAuto.color = defaultColor;
        _imageThunder.color = defaultColor;
    }
    public void onCLickAuto()
    {
        isToggled = !isToggled;
        _imageAuto.color = isToggled ? toggledColor : defaultColor;
    }
    public void onClickAutoThunder()
    {
        isToggled = !isToggled;
        _imageThunder.color = isToggled ? toggledColor : defaultColor;
    }
}

