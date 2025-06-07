using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TableToggleSet : MonoBehaviour
{
    public TableManageMent tableManager;
    [Header("toggle table set1")]
    public Transform[] allToggleTargetsSet1;
    [Header("toggle table set2")]
    public Transform[] allToggleTargetsSet2;
    [Header("toggle table set3")]
    public Transform[] allToggleTargetsSet3;
    public TextMeshProUGUI textTableCard;
    private bool isActive;
    public void onClickToggleObject(Transform targetChild)
    {
        if (targetChild == null) return;
        isActive = targetChild.gameObject.activeSelf;
        targetChild.gameObject.SetActive(!isActive);
        CountAllObjects(4);
    }
    private void CountAllObjects(int Counter)
    {
        int activeCount = 0;
        for (int i = 0; i < Counter && i < allToggleTargetsSet1.Length; i++)
        {
            Transform obj = allToggleTargetsSet1[i];
            if (obj != null)
            {
                if (obj.gameObject.activeSelf)
                    activeCount++;
            }
        }
        textTableCard.text = activeCount.ToString();
    }
}
