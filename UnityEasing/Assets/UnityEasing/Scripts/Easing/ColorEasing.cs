using UnityEngine;

namespace UnityEasing  {
	
	/// <summary>
	/// Easing of Unity Color.
	/// </summary>
	public class ColorEasing : Easing<Color>
	{
		public ColorEasing() { }
		
		public ColorEasing(Color from, Color to, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f) : base(from, to, duration, easingType, delay) { }

		protected override Color ComputeValue(Color value, float time, Color from, Color to, float duration, EasingFunction easingFunction)
		{
			return Color.Lerp(from, to, easingFunction(time / duration));
		}
	}
}

