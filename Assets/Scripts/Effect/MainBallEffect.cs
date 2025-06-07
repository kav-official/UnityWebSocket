using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
public class StarMainBallEffect : MonoBehaviour
{
    [Header("Prefab Content")]
    public GameObject prefab_Extraball_1;
    public GameObject prefab_Extraball_2;
    public GameObject prefab_Freeball;
    public GameObject prefab_Wildball_balls;
    public GameObject prefab_Wildball;
    public GameObject prefab_wildball_mainball;
    public GameObject prefab_coin_droping;
    public GameObject prefab_back_light;
    public GameObject prefab_button_merg_showrolling;
    [Header("Target Point Content")]
    public RectTransform target_Extraball_1;
    public RectTransform target_Extraball_2;
    public RectTransform target_Freeball;
    public RectTransform target_WildBall_balls;
    public RectTransform target_WildBall;
    public RectTransform target_WildBall_mainBalll;
    public RectTransform target_coin_droping;
    public RectTransform target_back_light;
    public RectTransform target_buttonMerg_showrolling;
    public Camera uiCamera;
    [Header("Counter variable")]
    public List<GameObject> spawnFreeBall = new List<GameObject>();
    public List<GameObject> spawnWildBall = new List<GameObject>();
    public List<GameObject> spawnWildBallMainBall = new List<GameObject>();
    public List<GameObject> spawnCoinDroping = new List<GameObject>();
    public List<GameObject> spawnWildMiniBalls = new List<GameObject>();
    public void PlayFX()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, target_Extraball_1.position);
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(target_Extraball_1, screenPos, uiCamera, out worldPos))
        {
            GameObject fxInstance = Instantiate(prefab_Extraball_1, worldPos, Quaternion.identity, target_Extraball_1.parent);
            ParticleSystem ps = fxInstance.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
                Destroy(fxInstance, ps.main.duration + ps.main.startLifetime.constant); // ลบหลังจบ
            }
        }
    }

    public void PlayFX2()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, target_Extraball_2.position);
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(target_Extraball_2, screenPos, uiCamera, out worldPos))
        {
            GameObject fxInstance = Instantiate(prefab_Extraball_2, worldPos, Quaternion.identity, target_Extraball_2.parent);
            ParticleSystem ps = fxInstance.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
                Destroy(fxInstance, ps.main.duration + ps.main.startLifetime.constant); // ลบหลังจบ
            }
        }
    }
    public void PlayFreeBallEffect()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, target_Freeball.position);
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(target_Freeball, screenPos, uiCamera, out worldPos))
        {
            GameObject fxInstance = Instantiate(prefab_Freeball, worldPos, Quaternion.identity, target_Freeball.parent);
            ParticleSystem ps = fxInstance.GetComponent<ParticleSystem>();
            spawnFreeBall.Add(fxInstance);
            if (ps != null)
            {
                ps.Play();
                Destroy(fxInstance, ps.main.duration + ps.main.startLifetime.constant); // ลบหลังจบ
            }
        }
    }
    public void WildBall_MiniBall_Effect()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, target_WildBall_balls.position);
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(target_WildBall_balls, screenPos, uiCamera, out worldPos))
        {
            GameObject fxInstance = Instantiate(prefab_Wildball_balls, worldPos, Quaternion.identity, target_WildBall_balls.parent);
            ParticleSystem ps = fxInstance.GetComponent<ParticleSystem>();
            spawnWildMiniBalls.Add(fxInstance);
            if (ps != null)
            {
                ps.Play();
                Destroy(fxInstance, ps.main.duration + ps.main.startLifetime.constant); // ลบหลังจบ
            }
        }
    }
    public void WildBallEffect()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, target_WildBall.position);
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(target_WildBall, screenPos, uiCamera, out worldPos))
        {
            GameObject fxInstance = Instantiate(prefab_Wildball, worldPos, Quaternion.identity, target_WildBall.parent);
            ParticleSystem ps = fxInstance.GetComponent<ParticleSystem>();
            spawnWildBall.Add(fxInstance);
            if (ps != null)
            {
                ps.Play();
                Destroy(fxInstance, ps.main.duration + ps.main.startLifetime.constant); // ลบหลังจบ
            }
        }
    }
    public void WildBallMainBall_W_Effect()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, target_WildBall_mainBalll.position);
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(target_WildBall_mainBalll, screenPos, uiCamera, out worldPos))
        {
            GameObject fxInstance = Instantiate(prefab_wildball_mainball, worldPos, Quaternion.identity, target_WildBall_mainBalll.parent);
            ParticleSystem ps = fxInstance.GetComponent<ParticleSystem>();
            spawnWildBallMainBall.Add(fxInstance);
            if (ps != null)
            {
                ps.Play();
                Destroy(fxInstance, ps.main.duration + ps.main.startLifetime.constant); // ลบหลังจบ
            }
        }
    }
    public void Coin_Drop_Effect()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, target_coin_droping.position);
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(target_coin_droping, screenPos, uiCamera, out worldPos))
        {
            GameObject fxInstance = Instantiate(prefab_coin_droping, worldPos, Quaternion.identity, target_coin_droping.parent);
            ParticleSystem ps = fxInstance.GetComponent<ParticleSystem>();
            spawnCoinDroping.Add(fxInstance);
            if (ps != null)
            {
                ps.Play();
                Destroy(fxInstance, ps.main.duration + ps.main.startLifetime.constant); // ลบหลังจบ
            }
        }
    }
    public void Effect_BackLight_Coin()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, target_back_light.position);
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(target_back_light, screenPos, uiCamera, out worldPos))
        {
            GameObject fxInstance = Instantiate(prefab_back_light, worldPos, Quaternion.identity, target_back_light.parent);
            ParticleSystem ps = fxInstance.GetComponent<ParticleSystem>();
            spawnCoinDroping.Add(fxInstance);
            if (ps != null)
            {
                ps.Play();
                Destroy(fxInstance, ps.main.duration + ps.main.startLifetime.constant); // ลบหลังจบ
            }
        }
    }
    public void Effect_buttonMerg_Showrolling()
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(uiCamera, target_buttonMerg_showrolling.position);
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(target_buttonMerg_showrolling, screenPos, uiCamera, out worldPos))
        {
            GameObject fxInstance = Instantiate(prefab_button_merg_showrolling, worldPos, Quaternion.identity, target_buttonMerg_showrolling.parent);
            ParticleSystem ps = fxInstance.GetComponent<ParticleSystem>();
            spawnCoinDroping.Add(fxInstance);
            if (ps != null)
            {
                ps.Play();
                Destroy(fxInstance, ps.main.duration + ps.main.startLifetime.constant); // ลบหลังจบ
            }
        }
    }


}
