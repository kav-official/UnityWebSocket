using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class LoopSpritess : MonoBehaviour
{
    public Image _imageStyle1, _imageStyle8;
    [Header("Sprite Stye Win")]
    public Sprite[] _spriteStyle1;
    public Sprite[] _spriteStyle8;
    private float _interval = 0.5f;
    private int _currentIndex = 0;
    
    void Start()
    {
        StartCoroutine(LoopSprite());

       
    }
  
    IEnumerator LoopSprite()
    {
        while (true)
        {
            if (_spriteStyle1.Length > 0 && _imageStyle1 != null)
            {
                _imageStyle1.sprite = _spriteStyle1[_currentIndex];
                _currentIndex = (_currentIndex + 1) % _spriteStyle1.Length;
            }
            if (_spriteStyle8.Length > 0 && _imageStyle1 != null)
            {
                _imageStyle8.sprite = _spriteStyle8[_currentIndex];
                _currentIndex = (_currentIndex + 1) % _spriteStyle8.Length;
            }
            yield return new WaitForSeconds(_interval);
        }
    }
}
