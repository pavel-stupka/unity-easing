using UnityEngine;

namespace UnityEasing  {
	
	/// <summary>
	/// Easing of Unity Color.
	/// </summary>
	public class ColorEasing : Easing<Color>
	{
		public ColorEasing(Color from, Color to, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f) : base(from, to, duration, easingType, delay) { }

		protected override Color ComputeChange(Color from, Color to)
		{
			return new Color
			{
				r = to.r - from.r,
				g = to.g - from.g,
				b = to.b - from.b,
				a = to.a - from.a
			};
		}

		protected override Color ComputeValue(Color value, float time, Color begin, Color change, float duration, EasingFunction easingFunction)
		{
			value.r = easingFunction(time, begin.r, change.r, duration);
			value.g = easingFunction(time, begin.g, change.g, duration);
			value.b = easingFunction(time, begin.b, change.b, duration);
			value.a = easingFunction(time, begin.a, change.a, duration);
			return value;
		}
	}
}

