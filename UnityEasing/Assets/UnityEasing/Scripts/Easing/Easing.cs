// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable VirtualMemberCallInConstructor
namespace UnityEasing  {

    /// <summary>
    /// Easing value changed event delegate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public delegate void ValueChangedDelegate<in T>(T value);

    /// <summary>
    /// Easing started event delegate.
    /// </summary>
    public delegate void EasingStartedDelegate();

    /// <summary>
    /// Easing finished event delegate.
    /// </summary>
    public delegate void EasingFinishedDelegate();
    
    /// <summary>
    /// General easing implementation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Easing<T>
    {
        /// <summary>
        /// Whether the easing is running.
        /// </summary>
        public bool Running { get; private set; }
        
        /// <summary>
        /// Initial value.
        /// </summary>
        public T From { get; private set; }
        
        /// <summary>
        /// Target value.
        /// </summary>
        public T To { get; private set; }

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
        /// Seconds remaining before easing starts (countdown).
        /// </summary>
        public float Delay { get; private set; }

        /// <summary>
        /// Easing function being used.
        /// </summary>
        public EasingFunction EasingFunction { get; private set; }

        /// <summary>
        /// Event that is invoked on value change.
        /// </summary>
        public event ValueChangedDelegate<T> ValueChanged;
        
        /// <summary>
        /// Event that is invoked on easing start.
        /// </summary>
        public event EasingStartedDelegate EasingStarted;
        
        /// <summary>
        /// Event that is invoked once easing finishes.
        /// </summary>
        public event EasingFinishedDelegate EasingFinished;

        /// <summary>
        /// Create a new instance but does not start easing.
        /// </summary>
        protected Easing()
        {
            Running = false;
            Value = default;
        }

        /// <summary>
        /// Initializes the values. Must be called from inherited class constructor.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        /// <param name="easingType"></param>
        /// <param name="delay"></param>
        protected Easing(T from, T to, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f)
        {
            Start(from, to, duration, easingType, delay);
        }
        
        /// <summary>
        /// Starts new easing.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        /// <param name="easingType"></param>
        /// <param name="delay"></param>
        public void Start(T from, T to, float duration = 1.0f, EasingType easingType = EasingType.Linear, float delay = 0.0f)
        {
            Running = true;
            From = from;
            To = to;
            Duration = duration;
            Time = 0f;
            EasingFunction = EasingFunctions.Get(easingType);
            Delay = delay;
            
            Value = ComputeValue(From, To, Time, Duration, EasingFunction);
            
            OnEasingStarted();
            OnValueChanged(Value);
        }
        
        /// <summary>
        /// Updates easing value based on the current UnityEngine.Time.deltaTime.
        /// </summary>
        /// <returns>Returns the current updated value.</returns>
        public T Update() 
        {
            return Update(UnityEngine.Time.deltaTime);
        }
        
        /// <summary>
        /// Updates easing values according to the given delta time.
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <returns>Returns the current updated value.</returns>
        public T Update(float deltaTime) 
        {
            if (!Running) return Value;

            var updateTimeByDelta = true;
            
            if (Delay > 0.0f)
            {
                Delay -= deltaTime;
                if (Delay >= 0.0f)
                {
                    return Value;
                }
                updateTimeByDelta = false;
                Time = -Delay;
                Delay = 0.0f;
            }

            if (updateTimeByDelta)
            {
                Time += deltaTime;                
            }

            if (Time >= Duration)
            {
                Time = Duration;
                Running = false;
            }

            Value = ComputeValue(From, To, Time, Duration, EasingFunction);
            OnValueChanged(Value);

            if (!Running)
            {
                OnEasingFinished();
            }

            return Value;
        }

        /// <summary>
        /// Computes the current easing value.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        /// <param name="duration"></param>
        /// <param name="easingFunction"></param>
        /// <returns></returns>
        protected abstract T ComputeValue(T from, T to, float time, float duration, EasingFunction easingFunction);

        /// <summary>
        /// Event invokator.
        /// </summary>
        /// <param name="value"></param>
        protected virtual void OnValueChanged(T value)
        {
            ValueChanged?.Invoke(value);
        }

        /// <summary>
        /// Event invokator.
        /// </summary>
        protected virtual void OnEasingStarted()
        {
            EasingStarted?.Invoke();
        }

        /// <summary>
        /// Event invokator.
        /// </summary>
        protected virtual void OnEasingFinished()
        {
            EasingFinished?.Invoke();
        }
    }
}