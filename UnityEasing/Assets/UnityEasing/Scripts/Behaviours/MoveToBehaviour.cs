using UnityEngine;

namespace UnityEasing
{
    /// <summary>
    /// Moves current GameObject's transform.
    /// </summary>
    public class MoveToBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Progress easing used to interpolate the position.
        /// </summary>
        private readonly FloatEasing progressEasing = new();
        
        /// <summary>
        /// Start position.
        /// </summary>
        private Vector3 startPosition;
        
        /// <summary>
        /// Target position.
        /// </summary>
        private Vector3 targetPosition;
        
        /// <summary>
        /// Target position defined using a transform (has a priority over targetPosition, ie. target defined by Vector3).
        /// </summary>
        private Transform targetTransform;
        
        /// <summary>
        /// Space of movement.
        /// </summary>
        private Space movementSpace;

        /// <summary>
        /// Executes a movement with a target position defined by Vector3.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="duration"></param>
        /// <param name="easingType"></param>
        /// <param name="delay"></param>
        /// <param name="space"></param>
        public void MoveTo(Vector3 target, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f, Space space = Space.World)
        {
            movementSpace = space;
            startPosition = movementSpace == Space.World ? transform.position : transform.localPosition;
            targetPosition = target;
            targetTransform = null;
            progressEasing.Start(0.0f, 1.0f, duration, easingType, delay);
        }

        /// <summary>
        /// Executes a movement with a target position defined by transform position.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="duration"></param>
        /// <param name="easingType"></param>
        /// <param name="delay"></param>
        /// <param name="space"></param>
        public void MoveTo(Transform target, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f, Space space = Space.World)
        {
            movementSpace = space;
            startPosition = movementSpace == Space.World ? transform.position : transform.localPosition;
            targetPosition = Vector3.zero;
            targetTransform = target;
            progressEasing.Start(0.0f, 1.0f, duration, easingType, delay);
        }

        /// <summary>
        /// Frame update.
        /// </summary>
        private void Update()
        {
            if (progressEasing.Running)
            {
                progressEasing.Update();
                ApplyProgress();
            }
        }

        /// <summary>
        /// Sets the current position.
        /// </summary>
        private void ApplyProgress()
        {
            // Movement end position.
            var endPosition = targetPosition;
            if (targetTransform != null)
            {
                endPosition = movementSpace == Space.World ? targetTransform.position : targetTransform.localPosition;
            }
            
            // Current positino.
            var position = Vector3.Lerp(startPosition, endPosition, progressEasing.Value);

            // Apply current position.
            if (movementSpace == Space.World)
            {
                transform.position = position;
            }
            else
            {
                transform.localPosition = position;
            }

            // If the easing is done, reset target transform.
            if (!progressEasing.Running)
            {
                targetTransform = null;
            }
        }
    }
}