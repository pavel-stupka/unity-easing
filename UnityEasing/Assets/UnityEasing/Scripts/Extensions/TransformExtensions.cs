using Unity.VisualScripting;
using UnityEngine;

namespace UnityEasing
{
    /// <summary>
    /// Extensions for Unity Transform component.
    /// </summary>
    public static class TransformExtensions
    {
        public static void MoveTo(this Transform transform, Vector3 target, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f, Space space = Space.World)
        {
            var moveToBehaviour = GetMoveToBehaviour(transform);
            moveToBehaviour.MoveTo(target, duration, easingType, delay, space);
        }
        
        public static void MoveTo(this Transform transform, Transform target, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f, Space space = Space.World)
        {
            var moveToBehaviour = GetMoveToBehaviour(transform);
            moveToBehaviour.MoveTo(target, duration, easingType, delay, space);
        }

        private static MoveToBehaviour GetMoveToBehaviour(Component component)
        {
            var moveToBehaviour = component.GetComponent<MoveToBehaviour>();
            if (moveToBehaviour == null)
            {
                moveToBehaviour = component.AddComponent<MoveToBehaviour>();
            }
            return moveToBehaviour;
        }
    }
}