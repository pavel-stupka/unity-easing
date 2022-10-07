﻿// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable VirtualMemberCallInConstructor
namespace UnityEasing  {
    
    /// <summary>
    /// General easing implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Easing<T>
    {
        /// <summary>
        /// True if the easing is already completed.
        /// </summary>
        public bool Finished { get; private set; }
        
        /// <summary>
        /// Initial value.
        /// </summary>
        public T Begin { get; private set; }
        
        /// <summary>
        /// Change (delta) value.
        /// </summary>
        public T Change { get; private set; }
        
        /// <summary>
        /// Total easing duration.
        /// </summary>
        public float Duration { get; private set; }
        
        /// <summary>
        /// Current easing value.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Current easing time.
        /// </summary>
        public float Time { get; private set; }

        /// <summary>
        /// Easing function being used.
        /// </summary>
        public EasingFunction EasingFunction { get; private set; }
        
        /// <summary>
        /// Initializes the values. Must be called from inherited class constructor.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        /// <param name="easingType"></param>
        protected Easing(T from, T to, float duration, EasingType easingType)
        {
            Finished = false;
            Begin = from;
            Change = ComputeChange(from, to);
            Duration = duration;
            Value = from;
            Time = 0f;
            EasingFunction = EasingFunctions.Get(easingType);
        }
        
        /// <summary>
        /// Updates easing value based on the current UnityEngine.Time.deltaTime.
        /// Returns true if the value was updated, false otherwise. 
        /// </summary>
        /// <returns>Returns true if the value was updated, false otherwise.</returns>
        public bool Update() 
        {
            return Update(UnityEngine.Time.deltaTime);
        }
        
        /// <summary>
        /// Updates easing values. Returns true if the value was updated, false otherwise.
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <returns>Returns true if the value was updated, false otherwise.</returns>
        public bool Update(float deltaTime) 
        {
            if (Finished) return false;

            Time += deltaTime;
            if (Time >= Duration)
            {
                Time = Duration;
                Finished = true;
            }

            Value = ComputeValue(Value, Time, Begin, Change, Duration, EasingFunction);

            return true;
        }

        /// <summary>
        /// Computes a change (delta) value. Usually equeals to: to - from.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        protected abstract T ComputeChange(T from, T to);

        /// <summary>
        /// Computes the current easing value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="time"></param>
        /// <param name="begin"></param>
        /// <param name="change"></param>
        /// <param name="duration"></param>
        /// <param name="easingFunction"></param>
        /// <returns></returns>
        protected abstract T ComputeValue(T value, float time, T begin, T change, float duration, EasingFunction easingFunction);
    }
}