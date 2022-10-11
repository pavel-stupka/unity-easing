using UnityEngine;

namespace UnityEasing {

	/// <summary>
	/// Vector3 easing.
	/// </summary>
	public class Vector3Easing : Easing<Vector3>
	{
		public Vector3Easing(Vector3 from, Vector3 to, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f) : base(from, to, duration, easingType, delay) { }

		protected override Vector3 ComputeChange(Vector3 from, Vector3 to)
		{
			return to - from;
		}

		protected override Vector3 ComputeValue(Vector3 value, float time, Vector3 begin, Vector3 change, float duration, EasingFunction easingFunction)
		{
			value.x = easingFunction(time, begin.x, change.x, duration);
			value.y = easingFunction(time, begin.y, change.y, duration);
			value.z = easingFunction(time, begin.z, change.z, duration);
			return value;
		}
	}
}

