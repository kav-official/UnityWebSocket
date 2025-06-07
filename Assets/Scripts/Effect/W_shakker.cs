using UnityEngine;

public class W_shakker : MonoBehaviour
{
    public float scaleAmount = 0.01f;
    public float speed = 20f;
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
