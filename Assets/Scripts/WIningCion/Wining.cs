using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class DigitSpriteCounter : MonoBehaviour
{
    // public StarMainBallEffect effect;
    [Header("Money Number Content")]
    public Sprite[] digitSprites; 
    public Image[] digitImages; 
    public int currentValue = 2355;
    public int maxValue = 9999;
    public float updateDelay = 0f;

    private bool isCounting = false;

    public void StartCounting()
    {
        if (!isCounting)
            StartCoroutine(CountUpRoutine());
    }

    IEnumerator CountUpRoutine()
    {
        isCounting = true;

        int targetValue = Mathf.Min(currentValue + 145, maxValue);

        while (currentValue < targetValue)
        {
            currentValue++;
            UpdateDisplay(currentValue);
            yield return new WaitForSeconds(updateDelay);
        }

        isCounting = false;
    }

    void UpdateDisplay(int number)
    {
        number = Mathf.Clamp(number, 0, 9999);
        string numStr = number.ToString("D4");

        for (int i = 0; i < digitImages.Length && i < 4; i++)
        {
            int digit = int.Parse(numStr[i].ToString());
            digitImages[i].sprite = digitSprites[digit];
        }
    }
    void Awake()
    {
        UpdateDisplay(currentValue);
        StartCounting();
    }
}
