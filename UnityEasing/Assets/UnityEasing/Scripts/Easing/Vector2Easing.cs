using UnityEngine;

namespace UnityEasing {

	/// <summary>
	/// Vector2 easing.
	/// </summary>
	public class Vector2Easing : Easing<Vector2>
	{
		public Vector2Easing(Vector2 from, Vector2 to, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f) : base(from, to, duration, easingType, delay) { }

		protected override Vector2 ComputeChange(Vector2 from, Vector2 to)
		{
			return to - from;
		}

		protected override Vector2 ComputeValue(Vector2 value, float time, Vector2 begin, Vector2 change, float duration, EasingFunction easingFunction)
		{
			value.x = easingFunction(time, begin.x, change.x, duration);
			value.y = easingFunction(time, begin.y, change.y, duration);
			return value;
		}
	}
}

