using UnityEngine;

namespace UnityEasing
{
    public class CubeExample : MonoBehaviour
    {
        [SerializeField] private Transform targetTranform;
        [SerializeField] private Vector3 targetPosition;
        
        private void Start()
        {
            if (targetTranform != null)
            {
                transform.MoveTo(targetTranform, 2.0f, EasingType.OutCubic, 1.0f, Space.World);
            }
            else
            {
                transform.MoveTo(targetPosition, 2.0f, EasingType.OutCubic, 1.0f, Space.World);
            }
        }
    }
}