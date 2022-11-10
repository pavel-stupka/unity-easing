namespace UnityEasing  {
	
	/// <summary>
	/// Float easing.
	/// </summary>
	public class FloatEasing : Easing<float>
	{
		public FloatEasing() { }

		public FloatEasing(float from, float to, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f) : base(from, to, duration, easingType, delay) { }

		protected override float ComputeValue(float value, float time, float from, float to, float duration, EasingFunction easingFunction)
		{
			return (to - from) * easingFunction(time / duration) + from;
		}
	}
}

