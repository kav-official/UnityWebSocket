using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class SpinnerController : MonoBehaviour
{
    public ShowRolling toggleRolling;
    public GameObject textAlert;
    [Header("Rolling Content")]
    public Button buttonSpin;
    public float spinDuration = 15f;
    public int extraRounds = 5;
    private bool isSpinning = false;
    public RollingChild _smallRoll;
    private List<float> segmentAngles = new List<float>
    {
        0f, -30f, -60f, -90f, -120f, -150f,
        -180f, -210f, -240f, -270f, -300f, -330f
    };

    void Start()
    {
        buttonSpin = GameObject.Find("RollingContainer").GetComponent<Button>();
        buttonSpin.onClick.AddListener(Spin);
        if (buttonSpin != null && buttonSpin.TryGetComponent(out Button btn))
        {
            buttonSpin = btn;
            buttonSpin.onClick.AddListener(Spin);
        }
    }
    public void Spin()
    {
        if (isSpinning) return;
        isSpinning = true;
        textAlert.SetActive(false);

        _smallRoll.SpinChild(spinDuration + 0.5f);
        // 1. Random winning segment
        int winIndex = Random.Range(0, segmentAngles.Count);
        float segmentAngle = segmentAngles[winIndex];
        // 2. Calculate the extra rotation to land it at -30°
        float offsetToTop = -30f - segmentAngle;
        float targetRotation = 360f * extraRounds + offsetToTop;
        // 3. Spin from current Z
        float currentZ = transform.eulerAngles.z;
        float targetZ = currentZ + targetRotation;
        LeanTween.rotateZ(gameObject, targetZ, spinDuration)
            .setEaseOutQuart()
            .setOnComplete(() =>
            {
                StartCoroutine(getHideRolling());
                isSpinning = false;
                Debug.Log("✅ Landed on index: " + winIndex);
            });
    }
    IEnumerator getHideRolling()
    {
        yield return new WaitForSeconds(2);
        toggleRolling.HidePopup();
    }
}