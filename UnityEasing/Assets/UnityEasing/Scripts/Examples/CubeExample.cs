using UnityEngine;

namespace UnityEasing
{
    public class CubeExample : MonoBehaviour
    {
        private Vector3Easing easing;
        
        private void Start()
        {
            Invoke(nameof(StartEasing), 1);
        }

        private void StartEasing()
        {
            easing = new Vector3Easing(transform.position, transform.position + new Vector3(8, 0, 0), 2, EasingType.OutCubic);
        }

        private void Update()
        {
            if (easing != null)
            {
                if (easing.Update())
                {
                    transform.position = easing.Value;
                }
                else
                {
                    easing = null;
                }
            }
        } 
    }
}