using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class RollingChild : MonoBehaviour
{
    public float spinDuration = 45f;
    public int extraRounds = 5;
    private bool isSpinning = false;
    private List<float> segmentAngles = new List<float>
    {
        28f, 58f, 88f, 118f, 148f, 178f,
        208f, 238f, 268f, 298f, 328f, 358f
    };
    public void SpinChild(float customDuration)
    {
        if (isSpinning) return;
        isSpinning = true;

        int winIndex = Random.Range(0, segmentAngles.Count);
        float targetSegmentAngle = segmentAngles[winIndex];

        float offsetToTop = 28f - targetSegmentAngle;
        float targetZ = transform.eulerAngles.z + (360f * extraRounds) + offsetToTop;

        LeanTween.rotateZ(gameObject, targetZ, customDuration)
            .setEaseOutQuart()
            .setOnComplete(() =>
            {
                Debug.Log($"✅ Child spinner stopped on index: {winIndex}");
                isSpinning = false;
            });
    }
}
