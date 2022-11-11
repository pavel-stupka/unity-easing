using UnityEngine;

namespace UnityEasing {

	/// <summary>
	/// Vector3 easing.
	/// </summary>
	public class Vector3Easing : Easing<Vector3>
	{
		public Vector3Easing() { }
		
		public Vector3Easing(Vector3 from, Vector3 to, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f) : base(from, to, duration, easingType, delay) { }
		
		protected override Vector3 ComputeValue(Vector3 from, Vector3 to, float time, float duration, EasingFunction easingFunction)
		{
			return Vector3.Lerp(from, to, easingFunction(time / duration));
		}
	}
}

