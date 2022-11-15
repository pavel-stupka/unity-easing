using UnityEngine;

namespace UnityEasing
{
    public class CubeExample : MonoBehaviour
    {
        [SerializeField] private Transform targetTranform;
        [SerializeField] private Vector3 targetPosition;
        
        [SerializeField] private float duration = 2f;
        [SerializeField] private float delay = 1f;

        private void Start()
        {
            if (targetTranform != null)
            {
                transform.MoveTo(targetTranform, duration, EasingType.OutCubic, delay, Space.World);
            }
            else
            {
                transform.MoveTo(targetPosition, duration, EasingType.OutCubic, delay, Space.World);
            }
        }
    }
}