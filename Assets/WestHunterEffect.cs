using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class WestHunterEffect : MonoBehaviour
{
    [Header("West Hunter")]
    public Image targetImage;        // The image you want to pulse
    public GameObject lightSprite;   // The "light" sprite GameObject (set active/inactive)
    public float pulseSpeed = 2f;    // How fast it pulses
    public float scaleAmount = 0.1f; // How big it scales up and down

    private Vector3 originalScale;
    private float timer = 0f;
    void Start()
    {
         if (targetImage == null) targetImage = GetComponent<Image>();
        originalScale = transform.localScale;

        if (lightSprite != null)
            lightSprite.SetActive(false); // Start off
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * pulseSpeed;

        // Calculate scale factor using sine wave
        float scaleFactor = 1f + Mathf.Sin(timer) * scaleAmount;
        transform.localScale = originalScale * scaleFactor;

        // Toggle lightSprite when scaling up
        if (lightSprite != null)
        {
            bool isGrowing = Mathf.Sin(timer) > 0.5f; // Show light when expanding
            lightSprite.SetActive(isGrowing);
        }
    }
}
