// ReSharper disable MemberCanBePrivate.Global
using System;
using UnityEngine;

namespace UnityEasing {
    
    /// <summary>
    /// General easing funtion delegate.
    /// <param name="t">Current time.</param>
    /// <param name="b">Initial (begin) value.</param>
    /// <param name="c">Change value (target value - initial value).</param>
    /// <param name="d">Duration (total time).</param>
    /// </summary>
    public delegate float EasingFunction(float t, float b, float c, float d);

    /// <summary>
    /// Easing functions implementations.
    /// </summary>
    public static class EasingFunctions {

        /// <summary>
        /// Returns an appropriate easing function implementation according to the requeted type.
        /// </summary>
        /// <param name="easingType">Easing function requested type.</param>
        /// <returns>Easing function implementation.</returns>
        public static EasingFunction Get(EasingType easingType)
        {
            return easingType switch
            {
                EasingType.Linear => Linear,
                EasingType.InCubic => InCubic,
                EasingType.OutCubic => OutCubic,
                EasingType.InOutCubic => InOutCubic,
                EasingType.InQuad => InQuad,
                EasingType.OutQuad => OutQuad,
                EasingType.InOutQuad => InOutQuad,
                EasingType.OutElastic => OutElastic,
                EasingType.InElastic => InElastic,
                EasingType.InOutElastic => InOutElastic,
                _ => Linear
            };
        }

        /// <summary>
        /// Linear easing function.
        /// </summary>
        public static float Linear(float t, float b, float c, float d) 
        {
            return c * t / d + b;
        }

        /// <summary>
        /// InCubic easing function.
        /// </summary>
        public static float InCubic(float t, float b, float c, float d) 
        {
            t /= d;
            return c * t * t * t + b;
        }

        /// <summary>
        /// OutCubic easing function.
        /// </summary>
        public static float OutCubic(float t, float b, float c, float d) 
        {
            t /= d;
            t--;
            return c * (t * t * t + 1) + b;
        }

        /// <summary>
        /// InOutCubic easing function.
        /// </summary>
        public static float InOutCubic(float t, float b, float c, float d) 
        {
            t /= d / 2;

            if (t < 1)
            {
                return c / 2 * t * t * t + b;
            }
            
            t -= 2;
            return c / 2 * ( t * t * t + 2) + b;
        }

        /// <summary>
        /// InQuad easing function.
        /// </summary>
        public static float InQuad(float t, float b, float c, float d) 
        {
            t /= d;
            return c * t * t + b;
        }

        /// <summary>
        /// OutQuad easing function.
        /// </summary>
        public static float OutQuad(float t, float b, float c, float d) 
        {
            t /= d;
            return -c * t * (t - 2) + b;
        }

        /// <summary>
        /// InOutQuad easing function.
        /// </summary>
        public static float InOutQuad(float t, float b, float c, float d) 
        {
            t /= d/2;
            if (t < 1)
            {
                return c / 2 * t * t + b;
            }
            
            t--;
            return -c / 2 * (t * (t - 2) - 1) + b;
        }

        /// <summary>
        /// OutElastic easing function.
        /// </summary>
        public static float OutElastic(float t, float b, float c, float d) 
        {
            if (Math.Abs((t /= d) - 1) < Mathf.Epsilon)
            {
                return b + c;                
            }

            var p = d * .3f;
            var s = p / 4;

            return ( c * Mathf.Pow( 2, -10 * t ) * Mathf.Sin( ( t * d - s ) * ( 2 * Mathf.PI ) / p ) + c + b );
        }

        /// <summary>
        /// InElastic easing function.
        /// </summary>
        public static float InElastic(float t, float b, float c, float d) 
        {
            if (Math.Abs((t /= d) - 1) < Mathf.Epsilon)
            {
                return b + c;                
            }

            var p = d * .3f;
            var s = p / 4;

            return -( c * Mathf.Pow( 2, 10 * ( t -= 1 ) ) * Mathf.Sin( ( t * d - s ) * ( 2 * Mathf.PI ) / p ) ) + b;
        }

        /// <summary>
        /// InOutElastic easing function.
        /// </summary>
        public static float InOutElastic(float t, float b, float c, float d) 
        {
            if (Math.Abs((t /= d / 2) - 2) < Mathf.Epsilon)
            {
                return b + c;                
            }

            var p = d * ( .3f * 1.5f );
            var s = p / 4;

            if (t < 1)
            {
                return -.5f * ( c * Mathf.Pow( 2, 10 * ( t -= 1 ) ) * Mathf.Sin( ( t * d - s ) * ( 2 * Mathf.PI ) / p ) ) + b;                
            }

            return c * Mathf.Pow( 2, -10 * ( t -= 1 ) ) * Mathf.Sin( ( t * d - s ) * ( 2 * Mathf.PI ) / p ) * .5f + c + b;
        }
    }
}
