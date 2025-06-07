using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;


public class Table1 : MonoBehaviour
{
    public StartAction _balls;
    public WinlineManager _winline;
    public TableManageMent tableManager;
    [Header("Prefab:")]
    public GameObject _prefabsmall_Content;
    public List<GameObject> counter_winline_prefab = new List<GameObject>();
    [Header("Miss Index:")]
    private List<int> missingIndexes_line1 = new List<int>();
    private List<int> missingIndexes_line2 = new List<int>();
    private List<int> missingIndexes_line3 = new List<int>();
    private List<int> missingIndexes_line4 = new List<int>();
    private List<int> missingIndexes_line5 = new List<int>();
    private List<int> missingIndexes_line6 = new List<int>();
    private List<int> missingIndexes_line7 = new List<int>();
    private List<int> missingIndexes_line8 = new List<int>();
    private List<int> missingIndexes_line9 = new List<int>();
    private List<int> missingIndexes_line10 = new List<int>();
    private List<int> missingIndexes_line11 = new List<int>();
    private List<int> missingIndexes_line12 = new List<int>();
    private List<int> missingIndexes_line13 = new List<int>();
    private List<int> missingIndexes_line14 = new List<int>();
    [Header("Winline List:")]
    public GameObject[] _tableWinline = new GameObject[14];
    [Header("Normal Varialble")]
    private bool _isMarkerVisible;
    public bool isShowingMarker = true;
    public void StartCheckBallNumber()
    {
        StartCoroutine(CheckBallNumber());
    }
 
    public IEnumerator CheckSingleBalls(int singleBall)
    {
        if (!_winline.checkedBalls.Contains(singleBall))
        {
            Debug.Log("stag one match:");
            _winline.checkedBalls.Add(singleBall);
            yield return StartCoroutine(HighlightMatchingUI(singleBall));
        }

        int extraBall = _balls.newExtraBallNumber;
        if (extraBall != 0 && !_winline.checkedBalls.Contains(extraBall))
        { Debug.Log("stag two match:");
            _winline.checkedBalls.Add(extraBall);
            yield return StartCoroutine(HighlightMatchingUI(extraBall));
           
        }
    }
    private IEnumerator HighlightMatchingUI(int targetNumber)
    {
        for (int i = 0; i < tableManager._tableSet1_Content_1.childCount; i++)
        {
            Transform child = tableManager._tableSet1_Content_1.GetChild(i);
            var text        = child.GetComponentInChildren<TextMeshProUGUI>();
            var image       = child.GetComponentInChildren<Image>();

            if (text == null || image == null) continue;
            if (int.TryParse(text.text, out int displayNumber) && displayNumber == targetNumber)
            {
                if (!_winline.matchedindexTable.Contains(i)) _winline.matchedindexTable.Add(i);

                float fadeSpeed = 8f;
                int blinkCount  = 5;
                for (int b = 0; b < blinkCount; b++)
                {
                    // fade out
                    for (float a = 1f; a >= 0f; a -= Time.deltaTime * fadeSpeed)
                    {
                        var c       = image.color;
                        c.a         = a;
                        image.color = c;
                        yield return null;
                    }
                    // fade in
                    for (float a = 0f; a <= 1f; a += Time.deltaTime * fadeSpeed)
                    {
                        var c       = image.color;
                        c.a         = a;
                        image.color = c;
                        yield return null;
                    }
                }
                Color color = image.color;
                color.a     = 1f;
                image.color = color;
                text.color = Color.green;

                Debug.Log("⚡ Win line at index:" + i);
                Debug.Log($"✅ Matched number: {targetNumber} at index {i}");
                yield return new WaitForSeconds(0.8f);
            }
        }
    }

    public IEnumerator CheckBallNumber()
    {
        for (int b = 0; b < _balls.ballNumbers.Count; b++)
        {
            int ballNumber = _balls.ballNumbers[b];
            if (_winline.checkedBalls.Contains(ballNumber)) continue;

            _winline.checkedBalls.Add(ballNumber);

            for (int i = 0; i < tableManager._tableSet1_Content_1.childCount; i++)
            {
                Transform child = tableManager._tableSet1_Content_1.GetChild(i);
                var text        = child.GetComponentInChildren<TextMeshProUGUI>();
                var image       = child.GetComponentInChildren<Image>();
                Debug.Log("Table Number::"+(i));
                if (text == null || image == null) continue;

                if (int.TryParse(text.text, out int displayNumber) && displayNumber == ballNumber)
                {
                    if (!_winline.matchedindexTable.Contains(i)) _winline.matchedindexTable.Add(i);

                    Color color = image.color;
                    color.a     = 255f;
                    image.color = color;
                    text.color  = Color.green;

                    Debug.Log($"✅ Matched number: {ballNumber} at index {i}");
                    yield return new WaitForSeconds(0.8f);
                }
            }
        }
    }
    public void CheckWinline()
    {
        missingIndexes_line1 = tableManager.Indexes_Wining_line1.Except(_winline.matchedindexTable).ToList();
        missingIndexes_line2 = tableManager.Indexes_Wining_line2.Except(_winline.matchedindexTable).ToList();
        missingIndexes_line3 = tableManager.Indexes_Wining_line3.Except(_winline.matchedindexTable).ToList();
        // --- WIN LINE 1 ---
        if (missingIndexes_line1.Count == 1 && !_winline.hasShownHintLine1)
        {
            _winline.hasShownHintLine1  = true;
            int lastIndex               = missingIndexes_line1[0];
            Transform targetChild       = tableManager._tableSet1_Content_1.GetChild(lastIndex);
            var textNumber              = targetChild.GetComponentInChildren<TextMeshProUGUI>();
            var imageBackground         = targetChild.GetComponentInChildren<Image>();

            if (textNumber != null && imageBackground != null)
            {
                if (int.TryParse(textNumber.text, out int number))
                {
                    StartCoroutine(ShowMarkerSmallItem(targetChild, number, 3));
                    Debug.Log($"Line X: lastIndex={lastIndex}, parentName={targetChild.name}, number={number}");
                    if (_tableWinline[0] == null)
                    {
                        Debug.LogError("_winline_1 is null");
                    }
                    _tableWinline[0].SetActive(true);
                    _winline.winlineCoroutine1 = StartCoroutine(ShowMarkerWinline(_tableWinline[0]));
                    Debug.Log("Line 1 Triggered");
                }
            }
            Debug.Log("if = " + missingIndexes_line1);
        }
        else if (missingIndexes_line1.Count == 0 && !_winline.hasShownFullLine1)
        {
            _winline.hasShownFullLine1 = true;
            HighlightWinline(tableManager.Indexes_Wining_line1);

            _winline.winlineCoroutine1 = StartCoroutine(ShowMarkerWinline(_tableWinline[0]));
            Debug.Log("Line one win at index:"+ tableManager.Indexes_Wining_line1);
        }
        // --- WIN LINE 2 ---
        if (missingIndexes_line2.Count == 1 && !_winline.hasShownHintLine2)
        {
            _winline.hasShownHintLine2 = true;
            int lastIndex = missingIndexes_line2[0];
            Transform targetChild = tableManager._tableSet1_Content_1.GetChild(lastIndex);
            var textNumber = targetChild.GetComponentInChildren<TextMeshProUGUI>();
            var imageBackground = targetChild.GetComponentInChildren<Image>();

            if (textNumber != null && imageBackground != null)
            {
                if (int.TryParse(textNumber.text, out int number))
                {
                    StartCoroutine(ShowMarkerSmallItem(targetChild, number, 3));
                    Debug.Log($"Line X: lastIndex={lastIndex}, parentName={targetChild.name}, number={number}");
                    if (_tableWinline[1] == null)
                    {
                        Debug.LogError("_winline_1 is null");
                    }
                    _tableWinline[1].SetActive(true);
                    _winline.winlineCoroutine2 = StartCoroutine(ShowMarkerWinline(_tableWinline[1]));
                    Debug.Log("Line 2 Triggered");
                }
            }
        }
        else if (missingIndexes_line2.Count == 0 && !_winline.hasShownFullLine2)
        {
            _winline.hasShownFullLine2 = true;
            RemoveSmallMarkerByIndexes(tableManager.Indexes_Wining_line1);
            HighlightWinline(tableManager.Indexes_Wining_line2);
            _winline.winlineCoroutine2 = StartCoroutine(ShowMarkerWinline(_tableWinline[1]));
            Debug.Log("Line two win at index:"+ tableManager.Indexes_Wining_line2);
        }
        // --- WIN LINE 3 ---
        if (missingIndexes_line3.Count == 1 && !_winline.hasShownHintLine3)
        {
            _winline.hasShownHintLine3 = true;
            int lastIndex = missingIndexes_line3[0];
            Transform targetChild = tableManager._tableSet1_Content_1.GetChild(lastIndex);
            var textNumber = targetChild.GetComponentInChildren<TextMeshProUGUI>();
            var imageNumberBackground = targetChild.GetComponentInChildren<Image>();

            if (textNumber != null && imageNumberBackground != null)
            {
                if (int.TryParse(textNumber.text, out int number))
                {
                    StartCoroutine(ShowMarkerSmallItem(targetChild, number, 3));
                    Debug.Log($"Line X: lastIndex={lastIndex}, parentName={targetChild.name}, number={number}");

                    if (_tableWinline[2] == null)
                    {
                        Debug.LogError("_winline_1 is null");
                    }
                    _tableWinline[2].SetActive(true);
                    _winline.winlineCoroutine3 = StartCoroutine(ShowMarkerWinline(_tableWinline[2]));
                    Debug.Log("Line 3 Triggered");
                }
            }
        }
        if (missingIndexes_line3.Count == 0 && !_winline.hasShownFullLine3)
        {
            _winline.hasShownFullLine3 = true;
            // RemoveSmallMarkerByIndexes(tableManager.Indexes_Wining_line1);
            HighlightWinline(tableManager.Indexes_Wining_line3);
            _winline.winlineCoroutine3 = StartCoroutine(ShowMarkerWinline(_tableWinline[2]));
            Debug.Log("Line three win at index:"+ tableManager.Indexes_Wining_line3);
        }

    }
    private void HighlightWinline(List<int> indexes)
    {
        foreach (int index in indexes)
        {
            if (index >= 0 && index < tableManager._tableSet1_Content_1.childCount)
            {
                Transform child = tableManager._tableSet1_Content_1.GetChild(index);
                var textNumber = child.GetComponentInChildren<TextMeshProUGUI>();
                var imageBackground = child.GetComponentInChildren<Image>();

                if (textNumber != null && imageBackground != null)
                {
                    imageBackground.color = Color.red;
                    textNumber.color = Color.white;
                }
            }
        }
    }
    public IEnumerator ShowMarkerSmallItem(Transform parent, int balNumber, int winMoney)
    {
        if (_prefabsmall_Content == null) yield break;
        Transform targetCell = null;
        foreach (Transform child in parent)
        {
            TextMeshProUGUI cellText = child.GetComponentInChildren<TextMeshProUGUI>();
            if (cellText != null && cellText.text == balNumber.ToString())
            {
                targetCell = child;
                break;
            }
        }

        if (targetCell == null)
        {
            Debug.LogWarning($"No matching cell found for ball number {balNumber} in parent {parent.name}");
            yield break;
        }

        // Instantiate marker
        GameObject marker = Instantiate(_prefabsmall_Content);
        marker.transform.SetParent(targetCell, false);
        marker.transform.localPosition = Vector3.zero;
        marker.transform.localScale = Vector3.one;
        marker.transform.SetAsLastSibling();
        counter_winline_prefab.Add(marker);

        TextMeshProUGUI textBalls = marker.transform.Find("childImage/textSmallBallNumber")?.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI textwinMoney = marker.transform.Find("textWinMoney")?.GetComponent<TextMeshProUGUI>();

        if (textBalls == null) Debug.LogError("textBalls is null");
        else textBalls.text = balNumber.ToString();

        if (textwinMoney == null) Debug.LogError("textwinMoney is null");
        else textwinMoney.text = winMoney.ToString();

        bool isVisible = true;
        while (marker != null)
        {
            isVisible = !isVisible;
            marker.SetActive(isVisible);
            yield return new WaitForSeconds(0.5f);
        }

        Debug.LogWarning("Marker was destroyed unexpectedly.");
        yield break;
    }
    private void RemoveSmallMarkerByIndexes(List<int> indexes)
    {
        GameObject[] allMarkers = GameObject.FindGameObjectsWithTag("SmallMarker1");

        foreach (GameObject marker in allMarkers)
        {
            foreach (int index in indexes)
            {
                if (marker.name.Contains("Win_Line_" + (index + 1))) // +1 เพราะคุณเริ่มนับจาก 1
                {
                    Destroy(marker);
                    Debug.Log("❌ Removed marker: " + marker.name);
                }
            }
        }
    }

    public IEnumerator ShowMarkerWinline(GameObject winline)
    {
        bool state = false;
        while (isShowingMarker && winline != null)
        {
            state = !state;
            winline.SetActive(state);
            yield return new WaitForSeconds(0.5f);
        }
        if (winline != null) winline.SetActive(false);
    }
}
