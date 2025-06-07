using UnityEngine;
using TMPro;

public class FreeBounce : MonoBehaviour
{
    public float scaleAmount = 0.03f;
    public float speed = 6f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * speed) * scaleAmount;
        transform.localScale = originalScale * scale;
    }
}
