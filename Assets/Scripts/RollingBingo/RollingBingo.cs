using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReelSpinner : MonoBehaviour
{
    public GameObject selftObject;
    [Header("Count Spin")]
    public Sprite[] numberSprites;
    public Image tensImage;
    public Image onesImage;
    private int currentCountdown = 10;
    [Header("Reel spin Set 1")]
    public GameObject[] symbolPrefabs;
    public RectTransform content;
    public ScrollRect scrollRect;
    [Header("Reel spin Set 2")]
    public GameObject[] symbolPrefabs_set2;
    public RectTransform content_set2;
    public ScrollRect scrollRect_set2;
    [Header("Reel spin Set 3")]
    public GameObject[] symbolPrefabs_set3;
    public RectTransform content_set3;
    public ScrollRect scrollRect_set3;
    [Header("Reel spin Set 4")]
    public GameObject[] symbolPrefabs_set4;
    public RectTransform content_set4;
    public ScrollRect scrollRect_set4;
    [Header("General")]
    public int totalItems = 20;
    public int visibleItems = 4;
    public float spinDuration = 2f;
    private float itemHeight;
    private bool isSpinning = false;

    void Start()
    {
        // ScrollRect Setup
        SetupScroll(scrollRect);
        SetupScroll(scrollRect_set2);
        SetupScroll(scrollRect_set3);
        SetupScroll(scrollRect_set4);

        StartSpin();

        if (symbolPrefabs.Length > 0)
        {
            GameObject temp = Instantiate(symbolPrefabs[0], content);
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
            itemHeight = ((RectTransform)temp.transform).rect.height;
            Destroy(temp);
        }
        // Generate items for all 4 reels
        GenerateItems(content, symbolPrefabs);
        GenerateItems(content_set2, symbolPrefabs_set2);
        GenerateItems(content_set3, symbolPrefabs_set3);
        GenerateItems(content_set4, symbolPrefabs_set4);
    }
    void SetupScroll(ScrollRect scroll)
    {
        scroll.vertical = false;
        scroll.inertia = false;
        scroll.movementType = ScrollRect.MovementType.Clamped;
    }
    void GenerateItems(RectTransform targetContent, GameObject[] prefabList)
    {
        foreach (Transform child in targetContent)
            Destroy(child.gameObject);

        for (int i = 0; i < totalItems; i++)
        {
            int rand = Random.Range(0, prefabList.Length);
            Instantiate(prefabList[rand], targetContent);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(targetContent);
    }
    void UpdateCountdownDisplay()
    {
        if (currentCountdown >= 10)
        {
            int tens = currentCountdown / 10;
            int ones = currentCountdown % 10;

            tensImage.gameObject.SetActive(true);
            onesImage.gameObject.SetActive(true);

            tensImage.sprite = numberSprites[tens];
            onesImage.sprite = numberSprites[ones];
        }
        else
        {
            tensImage.gameObject.SetActive(false);
            onesImage.gameObject.SetActive(true);
            onesImage.sprite = numberSprites[currentCountdown];
        }
    }

    public void StartSpin()
    {
        if (!isSpinning && currentCountdown > 0)
        {
            currentCountdown--;
            UpdateCountdownDisplay();
            StartCoroutine(SpinAllReels());
        }
        else
        {
            Debug.Log("Rolling Spin is over.");
        }
    }

    IEnumerator SpinAllReels()
    {
        isSpinning = true;

        // Generate new items for all 4 reels
        GenerateItems(content, symbolPrefabs);
        GenerateItems(content_set2, symbolPrefabs_set2);
        GenerateItems(content_set3, symbolPrefabs_set3);
        GenerateItems(content_set4, symbolPrefabs_set4);
        yield return null;

        // Start all reels in parallel
        Coroutine r1 = StartCoroutine(SpinReel(scrollRect, content));
        Coroutine r2 = StartCoroutine(SpinReel(scrollRect_set2, content_set2));
        Coroutine r3 = StartCoroutine(SpinReel(scrollRect_set3, content_set3));
        Coroutine r4 = StartCoroutine(SpinReel(scrollRect_set4, content_set4));

        yield return r1;
        yield return r2;
        yield return r3;
        yield return r4;

        isSpinning = false;

        if (currentCountdown > 0)
        {
            yield return new WaitForSeconds(2f);
            StartSpin(); // auto spin again
        }
        else
        {
            selftObject.SetActive(false);
        }
    }

    IEnumerator SpinReel(ScrollRect targetScroll, RectTransform targetContent)
    {
        float elapsed = 0f;
        float speed = 2000f;

        while (elapsed < spinDuration)
        {
            targetScroll.verticalNormalizedPosition = Mathf.Repeat(targetScroll.verticalNormalizedPosition + (speed * Time.deltaTime / 10000f), 1f);
            speed = Mathf.Lerp(2000f, 200f, elapsed / spinDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        float decelTime = 0.5f;
        float startPos = targetScroll.verticalNormalizedPosition;
        float targetPos = CalculateRandomStopPosition(targetScroll, targetContent);

        float t = 0;
        while (t < decelTime)
        {
            targetScroll.verticalNormalizedPosition = Mathf.Lerp(startPos, targetPos, t / decelTime);
            t += Time.deltaTime;
            yield return null;
        }
        targetScroll.verticalNormalizedPosition = targetPos;
    }
    float CalculateRandomStopPosition(ScrollRect targetScroll, RectTransform targetContent)
    {
        int minIndex = visibleItems;
        int maxIndex = totalItems - visibleItems;
        int stopIndex = Random.Range(minIndex, maxIndex);

        float totalHeight = targetContent.rect.height;
        float visibleHeight = targetScroll.viewport.rect.height;

        float targetY = itemHeight * stopIndex - (visibleHeight / 2f) + (itemHeight / 2f);
        float normalized = 1f - (targetY / (totalHeight - visibleHeight));
        return Mathf.Clamp01(normalized);
    }
}
