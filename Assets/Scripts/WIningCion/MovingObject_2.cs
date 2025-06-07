using UnityEngine;

public class MovingObject2 : MonoBehaviour
{
    [Header("Object Blink Content")]
    public Vector3 moveOffset = new Vector3(0f, 3f, 0f); 
    public float duration = 0.3f; 
    public bool loop = true;
    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.localPosition;
        MoveSlightly();
    }
    public void MoveSlightly()
    {
        LeanTween.moveLocal(gameObject, originalPosition + moveOffset, duration)
            .setEaseOutQuad()
            .setOnComplete(() =>
            {
                LeanTween.moveLocal(gameObject, originalPosition, duration)
                    .setEaseInQuad();

                if (loop)
                {
                    Invoke(nameof(MoveSlightly), duration * 2);
                }
            });
    }
}
