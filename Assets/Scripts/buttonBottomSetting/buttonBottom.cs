using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class buttonBottom : MonoBehaviour
{
    public TableManageMent card;
    public Image _imageAuto;
    public Image _imageThunder;
    public Sprite _spriteAutoActive;
    public Sprite _spriteAutoInActive;
    public Sprite _spriteTunderActive;
    public Sprite _spriteTunderInActive;
    private bool isToggled = false;
    [Header("Betting")]
    public GameObject _objectPanelBet;
    public TextMeshProUGUI textBetAmount;
    public TextMeshProUGUI textTotalBet;
    public TextMeshProUGUI textCurrentBalance;
    public float _totalBetAmount = 0;
    void Start()
    {
        _imageAuto.sprite = _spriteAutoInActive;
        _imageThunder.sprite = _spriteTunderInActive;
        
        _totalBetAmount = 0.1f;
        textBetAmount.text = "USDT"+_totalBetAmount.ToString();
    }
    public void onClickSetbetAmount(float amount)
    {
        if (amount > 0)
        {
            _totalBetAmount = amount;
            textBetAmount.text = "USDT" + _totalBetAmount.ToString();

           float total =  card._cardNumber * _totalBetAmount;
           textTotalBet.text = "USDT"+total.ToString(); 
        }
    }
    public void onCLickAuto()
    {
        isToggled = !isToggled;
        _imageAuto.sprite = isToggled ? _spriteAutoActive : _spriteAutoInActive;
    }
    public void onClickAutoThunder()
    {
        isToggled = !isToggled;
        _imageThunder.sprite = isToggled ? _spriteTunderActive : _spriteTunderInActive;
    }
    public void onCLickToggleBetPanel()
    {
        isToggled = !isToggled;
        _objectPanelBet.SetActive(isToggled);
    }
}

