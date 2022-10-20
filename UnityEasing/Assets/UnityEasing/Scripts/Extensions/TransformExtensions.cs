using Unity.VisualScripting;
using UnityEngine;

namespace UnityEasing
{
    /// <summary>
    /// Extensions for Unity Transform component.
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Executes a movement with a target position defined by Vector3.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="duration"></param>
        /// <param name="easingType"></param>
        /// <param name="delay"></param>
        /// <param name="space"></param>
        public static void MoveTo(this Transform transform, Vector3 target, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f, Space space = Space.World)
        {
            var moveToBehaviour = GetMoveToBehaviour(transform);
            moveToBehaviour.MoveTo(target, duration, easingType, delay, space);
        }

        /// <summary>
        /// Executes a movement with a target position defined by transform position.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="duration"></param>
        /// <param name="easingType"></param>
        /// <param name="delay"></param>
        /// <param name="space"></param>
        public static void MoveTo(this Transform transform, Transform target, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f, Space space = Space.World)
        {
            var moveToBehaviour = GetMoveToBehaviour(transform);
            moveToBehaviour.MoveTo(target, duration, easingType, delay, space);
        }

        /// <summary>
        /// Gets (and creates is necessary) the MoveToBehaviour component on target transform.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
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