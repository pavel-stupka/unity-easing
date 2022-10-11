using UnityEngine;

namespace UnityEasing
{
    public class CubeExample : MonoBehaviour
    {
        private Vector3Easing easing;
        
        private void Start()
        {
            easing = new Vector3Easing(transform.position, transform.position + new Vector3(8, 0, 0), 2, EasingType.OutCubic, 2.0f);
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