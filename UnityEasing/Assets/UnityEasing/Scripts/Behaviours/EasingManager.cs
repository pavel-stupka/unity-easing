using System.Collections.Generic;
using UnityEngine;

namespace UnityEasing
{
    public class EasingManager : MonoBehaviour
    {
        private readonly HashSet<Easing<dynamic>> easings = new HashSet<Easing<dynamic>>();

        private static EasingManager instance;

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

        public bool AddEasing(Easing<dynamic> easing)
        {
            return easings.Add(easing);
        }

        public bool RemoveEasing(Easing<dynamic> easing)
        {
            return easings.Remove(easing);
        }

        private void Update()
        {
            foreach (var easing in easings)
            {
                easing.Update();
            }
        }
    }
}