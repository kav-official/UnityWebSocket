using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class WinlineManager : MonoBehaviour
{
    public TableManageMent tableManager;
    public Table1 table1;
    [Header("Prefab Content")]
    public GameObject _smallContentPrefab;
    [Header("Count prefab Content")]
    public List<GameObject> counter_winline_prefab = new List<GameObject>();
    [Header("Line Point Content")]
    public Transform _winline_point;
    [Header("Win Line List")]
    public GameObject _winline_1;
    public GameObject _winline_2;
    public GameObject _winline_3;
    public GameObject _winline_4;
    public GameObject _winline_5;
    public GameObject _winline_6;
    public GameObject _winline_7;
    public GameObject _winline_8;
    public GameObject _winline_9;
    public GameObject _winline_10;
    public GameObject _winline_11;
    public GameObject _winline_12;
    public GameObject _winline_13;
    public GameObject _winline_14;
    [Header("Coroutine Content")]
    public Coroutine winlineCoroutine1;
    public Coroutine winlineCoroutine2;
    public Coroutine winlineCoroutine3;
    public Coroutine winlineCoroutine4;
    public Coroutine winlineCoroutine5;
    public Coroutine winlineCoroutine6;
    public Coroutine winlineCoroutine7;
    public Coroutine winlineCoroutine8;
    public Coroutine winlineCoroutine9;
    public Coroutine winlineCoroutine10;
    public Coroutine winlineCoroutine11;
    public Coroutine winlineCoroutine12;
    public Coroutine winlineCoroutine13;
    public Coroutine winlineCoroutine14;
    [Header("Has show line content")]
    public bool hasShownHintLine1 = false;
    public bool hasShownHintLine2 = false;
    public bool hasShownHintLine3 = false;
    public bool hasShownHintLine4 = false;
    public bool hasShownHintLine5 = false;
    public bool hasShownHintLine6 = false;
    public bool hasShownHintLine7 = false;
    public bool hasShownHintLine8 = false;
    public bool hasShownHintLine9 = false;
    public bool hasShownHintLine10 = false;
    public bool hasShownHintLine11 = false;
    public bool hasShownHintLine12 = false;
    public bool hasShownHintLine13 = false;
    public bool hasShownHintLine14 = false;
    public bool hasShownFullLine1 = false;
    public bool hasShownFullLine2 = false;
    public bool hasShownFullLine3 = false;
    public bool hasShownFullLine4 = false;
    public bool hasShownFullLine5 = false;
    public bool hasShownFullLine6 = false;
    public bool hasShownFullLine7 = false;
    public bool hasShownFullLine8 = false;
    public bool hasShownFullLine9 = false;
    public bool hasShownFullLine10 = false;
    public bool hasShownFullLine11 = false;
    public bool hasShownFullLine12 = false;
    public bool hasShownFullLine13 = false;
    public bool hasShownFullLine14 = false;
    public List<int> matchedindexTable = new List<int>();
    public List<int> checkedBalls = new List<int>();
    public List<Coroutine> markerCoroutine = new List<Coroutine>();
    private bool _isMarkerVisible;
    public bool isShowingMarker = true;
    // public IEnumerator ShowMarkerSmallItem(Transform parent, int balNumber, int winMoney)
    // {
    //     if (_smallContentPrefab == null) yield break;

    //     GameObject marker = Instantiate(_smallContentPrefab);
    //     marker.transform.SetParent(parent, false);
    //     counter_winline_prefab.Add(marker);
    //     marker.transform.localPosition = Vector3.zero;
    //     marker.transform.localScale = Vector3.one;
    //     marker.transform.SetAsLastSibling();

    //     // TextMeshProUGUI textBalls = marker.transform.Find("childImage/textSmallBallNumber").GetComponent<TextMeshProUGUI>();
    //     // TextMeshProUGUI textwinMoney = marker.transform.Find("textWinMoney").GetComponent<TextMeshProUGUI>();
    //     var textBalls      = marker.GetComponentInChildren<TextMeshProUGUI>();
    //     var textwinMoney = marker.GetComponentInChildren<TextMeshProUGUI>();

    //     if (textBalls != null) textBalls.text = balNumber.ToString();
    //     if (textwinMoney != null) textwinMoney.text = winMoney.ToString();

    //     while (true)
    //     {
    //         _isMarkerVisible = !_isMarkerVisible;
    //         if (marker != null)
    //         {
    //             marker.SetActive(_isMarkerVisible);
    //         }
    //         else { yield break; }
    //         yield return new WaitForSeconds(0.5f);
    //     }
    // }
    // public IEnumerator ShowMarkerWinline(GameObject winline)
    // {
    //     bool state = false;
    //     while (isShowingMarker && winline != null)
    //     {
    //         state = !state;
    //         winline.SetActive(state);
    //         yield return new WaitForSeconds(0.5f);
    //     }
    //     if(winline != null) winline.SetActive(false);
    // }
    public void ResetAllHighlights()
    {
        if (winlineCoroutine1 != null)
        {
            StopCoroutine(winlineCoroutine1);
            winlineCoroutine1 = null;
        }
        if (winlineCoroutine2 != null)
        {
            StopCoroutine(winlineCoroutine2);
             winlineCoroutine2 = null;
        }
        if (winlineCoroutine3 != null)
        {
            StopCoroutine(winlineCoroutine3);
             winlineCoroutine3 = null;
        }
        if (winlineCoroutine4 != null)
        {
            StopCoroutine(winlineCoroutine4);
            winlineCoroutine4 = null;
        }
        if (winlineCoroutine5 != null)
        {
            StopCoroutine(winlineCoroutine5);
             winlineCoroutine5 = null;
        }
        if (winlineCoroutine6 != null)
        {
            StopCoroutine(winlineCoroutine6);
             winlineCoroutine6 = null;
        }
        if (winlineCoroutine7 != null)
        {
            StopCoroutine(winlineCoroutine7);
             winlineCoroutine7 = null;
        }
        if (winlineCoroutine8 != null)
        {
            StopCoroutine(winlineCoroutine8);
             winlineCoroutine8 = null;
        }
        if (winlineCoroutine9 != null)
        {
            StopCoroutine(winlineCoroutine9);
             winlineCoroutine9 = null;
        }
        if (winlineCoroutine10 != null)
        {
            StopCoroutine(winlineCoroutine10);
             winlineCoroutine10 = null;
        }
        if (winlineCoroutine11 != null)
        {
            StopCoroutine(winlineCoroutine11);
             winlineCoroutine11 = null;
        }
        if (winlineCoroutine12 != null)
        {
            StopCoroutine(winlineCoroutine12);
             winlineCoroutine12 = null;
        }
        if (winlineCoroutine13 != null)
        {
            StopCoroutine(winlineCoroutine13);
             winlineCoroutine13 = null;
        }
        if (winlineCoroutine14 != null)
        {
            StopCoroutine(winlineCoroutine14);
             winlineCoroutine14 = null;
        }

        if (_winline_1 != null) _winline_1.SetActive(false);
        if (_winline_2 != null) _winline_2.SetActive(false);
        if (_winline_3 != null) _winline_3.SetActive(false);
        if (_winline_4 != null) _winline_4.SetActive(false);
        if (_winline_5 != null) _winline_5.SetActive(false);
        if (_winline_6 != null) _winline_6.SetActive(false);
        if (_winline_7 != null) _winline_7.SetActive(false);
        if (_winline_8 != null) _winline_8.SetActive(false);
        if (_winline_9 != null) _winline_9.SetActive(false);
        if (_winline_10 != null) _winline_10.SetActive(false);
        if (_winline_11 != null) _winline_11.SetActive(false);
        if (_winline_12 != null) _winline_12.SetActive(false);
        if (_winline_13 != null) _winline_13.SetActive(false);
        if (_winline_14 != null) _winline_14.SetActive(false);

        _isMarkerVisible = true;
        
        foreach (Coroutine c in markerCoroutine)
        {
            if (c != null) StopCoroutine(c);
        }
        markerCoroutine.Clear();

        for (int i = 0; i < tableManager._tableSet1_Content_1.childCount; i++)
        {
            Transform child = tableManager._tableSet1_Content_1.GetChild(i);
            var text = child.GetComponentInChildren<TextMeshProUGUI>();
            var image = child.GetComponentInChildren<Image>();

            if (text != null)
            {
                text.color = Color.black;
            }
            if (image != null)
            {
                image.color = new Color(0f, 0f, 0f, 0f);
            }
        }
        matchedindexTable.Clear();
        checkedBalls.Clear();

        hasShownHintLine1 = false;
        hasShownHintLine2 = false;
        hasShownHintLine3 = false;
        hasShownHintLine4 = false;
        hasShownHintLine5 = false;
        hasShownHintLine6 = false;
        hasShownHintLine7 = false;
        hasShownHintLine8 = false;
        hasShownHintLine9 = false;
        hasShownHintLine10 = false;
        hasShownHintLine11 = false;
        hasShownHintLine12 = false;
        hasShownHintLine13 = false;
        hasShownHintLine14 = false;

        hasShownFullLine1 = false;
        hasShownFullLine2 = false;
        hasShownFullLine3 = false;
        hasShownFullLine4 = false;
        hasShownFullLine5 = false;
        hasShownFullLine6 = false;
        hasShownFullLine7 = false;
        hasShownFullLine8 = false;
        hasShownFullLine9 = false;
        hasShownFullLine10 = false;
        hasShownFullLine11 = false;
        hasShownFullLine12 = false;
        hasShownFullLine13 = false;
        hasShownFullLine14 = false;
        
        foreach (GameObject prefab in table1.counter_winline_prefab)
        {
            Destroy(prefab);
        }
        table1.counter_winline_prefab.Clear();    
    }
}
