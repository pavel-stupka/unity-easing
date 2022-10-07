using UnityEngine;

namespace UnityEasing
{
    public class FloatEasingBehaviour : MonoBehaviour
    {
        private FloatEasing easing;

        public void Init(float from, float to, float duration, EasingType easingType = EasingType.Linear, float delay = 0f)
        {
            easing = new FloatEasing(from, to, duration, easingType);
        }

        private void Update()
        {
            if (easing != null)
            {
                if (easing.Update())
                {
                    // TODO
                }
                else
                {
                    easing = null;
                }
            }
        }
    }
}