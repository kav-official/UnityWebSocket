using UnityEngine;
  public class CoinSpin : MonoBehaviour
    {
        public float spinSpeed = 360f;

        void Update()
        {
            transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        }
    }
