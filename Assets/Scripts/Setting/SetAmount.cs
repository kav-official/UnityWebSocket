using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SetAmount : MonoBehaviour
{
    [Header("Text Amount")]
    public TextMeshProUGUI textAmount1;
    public TextMeshProUGUI textAmount2;
    public TextMeshProUGUI textAmount3;
    public TextMeshProUGUI textAmount4;
    public TextMeshProUGUI textAmount5;
    [Header("Line Set")]
    public GameObject[] lineSetObject;
    private bool isShowSetline = true;
    [Header("Button Set1")]
    public Button[] buttonAmount1;
    public Button button1_Decrease;
    public Button button1_Increase;
    [Header("Button Set2")]
    public Button button2_Decrease;
    public Button button2_Increase;
    [Header("Button Set3")]
    public Button button3_Decrease;
    public Button button3_Increase;
    [Header("Button Set4")]
    public Button button4_Decrease;
    public Button button4_Increase;
    [Header("Button Set5")]
    public Button button5_Decrease;
    public Button button5_Increase;
    void Start()
    {
        textAmount1.text = 100.ToString();
        textAmount2.text = 400.ToString();
        textAmount3.text = 120.ToString();
        textAmount4.text = 800.ToString();
        textAmount5.text = 3000.ToString();

        for (int i = 0; i < lineSetObject.Length; i++)
        {
            int index = i;
            lineSetObject[i].GetComponent<Button>().onClick.AddListener(() => onClickSetline(index));
        }
    }
    void onClickSetline(int index)
    {
        if (index == null) return;
        Image image =  lineSetObject[index].GetComponent<Image>();
        if (image == null)
        {
            Debug.LogWarning("No Image component found on " );
            return;
        }
        image.enabled = !image.enabled;
    }
     public void onClickToggleObjectWinline(Transform targetChild)
    {
        bool isActive;
        if (targetChild == null) return;
        isActive = targetChild.gameObject.activeSelf;
        targetChild.gameObject.SetActive(!isActive);
       
    }
    public void ClearLine()
    {
        for (int i = 0; i < lineSetObject.Length; i++)
        {
            lineSetObject[i].GetComponent<Image>().enabled = false;
        }
    }
    public void SelectAlline()
    {
         for (int i = 0; i < lineSetObject.Length; i++)
        {
            lineSetObject[i].GetComponent<Image>().enabled = true;
        }
    }
    public void onCLickAmountSet1(int amount)
    {
        textAmount1.text = amount.ToString();
    }
    
    public void onCLickLengAmountSet1(string choice)
    {
        int amount = 0;
        if (int.TryParse(textAmount1.text, out amount))
        {
            switch (choice)
            {
                case "+": amount++; break;
                case "-": amount--; break;
            }
        }
    textAmount1.text = amount.ToString();
    }
    public void onCLickLengAmountSet2(string choice)
    {
        int amount = 0;
        if (int.TryParse(textAmount2.text, out amount))
        {
            switch (choice)
            {
                case "+": amount++; break;
                case "-": amount--; break;
            }
        }
    textAmount2.text = amount.ToString();
    }
    public void onCLickLengAmountSet3(string choice)
    {
        int amount = 0;
        if (int.TryParse(textAmount3.text, out amount))
        {
            switch (choice)
            {
                case "+": amount++; break;
                case "-": amount--; break;
            }
        }
    textAmount3.text = amount.ToString();
    }
    public void onCLickLengAmountSet4(string choice)
    {
        int amount = 0;
        if (int.TryParse(textAmount4.text, out amount))
        {
            switch (choice)
            {
                case "+": amount++; break;
                case "-": amount--; break;
            }
        }
    textAmount4.text = amount.ToString();
    }
    public void onCLickLengAmountSet5(string choice)
    {
        int amount = 0;
        if (int.TryParse(textAmount5.text, out amount))
        {
            switch (choice)
            {
                case "+": amount++; break;
                case "-": amount--; break;
            }
        }
    textAmount5.text = amount.ToString();
    }
}
