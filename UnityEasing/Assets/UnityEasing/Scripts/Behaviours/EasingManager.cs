using System.Collections.Generic;
using UnityEngine;

namespace UnityEasing
{
    /// <summary>
    /// Main class to manage the easing updates.
    /// </summary>
    public class EasingManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton.
        /// </summary>
        private static EasingManager instance;

        /// <summary>
        /// Singleton implementation.
        /// </summary>
        public static EasingManager Instacnce
        {
            get
            {
                if (instance != null) return instance;
                var go = new GameObject("Easing Manager");
                DontDestroyOnLoad(go);
                instance = go.AddComponent<EasingManager>();
                return instance;
            }
        }
        
        /// <summary>
        /// Set of easing instances.
        /// </summary>
        private readonly HashSet<Easing<dynamic>> easings = new();

        /// <summary>
        /// Adds new easing to be manager by this instance.
        /// </summary>
        /// <param name="easing"></param>
        /// <returns></returns>
        public bool AddEasing(Easing<dynamic> easing)
        {
            return easings.Add(easing);
        }

        /// <summary>
        /// Removes managed instance.
        /// </summary>
        /// <param name="easing"></param>
        /// <returns></returns>
        public bool RemoveEasing(Easing<dynamic> easing)
        {
            return easings.Remove(easing);
        }

        /// <summary>
        /// Frame update.
        /// </summary>
        private void Update()
        {
            foreach (var easing in easings)
            {
                easing.Update();
            }
        }
    }
}