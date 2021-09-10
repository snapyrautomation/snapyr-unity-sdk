using System;
using Snapyr.Types;
using Snapyr.Wrappers;
using UnityEngine;

namespace Snapyr
{
    public class SnapyrWrapper : ISnapyrWrapper
    {
        private static readonly SnapyrWrapper instance = new SnapyrWrapper();

        public static bool isInitialized = false;

        public static SnapyrWrapper I => instance;

        private ISnapyrWrapper wrapper;

        static SnapyrWrapper()
        {

        }
        private SnapyrWrapper()
        {
            wrapper = createWrapper();
        }

        private void handleNotInitialized(string callName) {
            Debug.LogWarning("Snapyr SDK is not initialized; skipping call: " + callName);
        }

        public void Initialize(string writeKey, SnapyrConfiguration config)
        {
            try {
                wrapper.Initialize(writeKey, config);
                SnapyrWrapper.isInitialized = true;
            } catch (Exception e) {
                Debug.LogWarning("Could not initialize Snapyr SDK: " + e.Message);
                Debug.LogWarning(e.Message);
            }
        }

        public void Identify(string id, Traits traits)
        {
            if (!SnapyrWrapper.isInitialized) {
                handleNotInitialized("Identify");
                return;
            }

            try {
                wrapper.Identify(id, traits);
            } catch (Exception e) {
                Debug.LogWarning("Encountered SDK exception when attempting operation: Identify: " + e.Message);
                Debug.LogWarning(e.Message);
            }
        }

        public void Track(string ev, Properties props)
        {
            if (!SnapyrWrapper.isInitialized) {
                handleNotInitialized("Track");
                return;
            }

            try {
                wrapper.Track(ev, props);
            } catch (Exception e) {
                Debug.LogWarning("Encountered SDK exception when attempting operation: Track: " + e.Message);
                Debug.LogWarning(e.Message);
            }
        }

        public void Screen(string name)
        {
            if (!SnapyrWrapper.isInitialized) {
                handleNotInitialized("Screen");
                return;
            }
            
            try {
                wrapper.Screen(name);
            } catch (Exception e) {
                Debug.LogWarning("Encountered SDK exception when attempting operation: Screen: " + e.Message);
                Debug.LogWarning(e.Message);
            }
        }

        public void Reset()
        {
            if (!SnapyrWrapper.isInitialized) {
                handleNotInitialized("Reset");
                return;
            }
            
            try {
                wrapper.Reset();
            } catch (Exception e) {
                Debug.LogWarning("Encountered SDK exception when attempting operation: Reset: " + e.Message);
            }
        }

        public void SetDebugEnabled(bool enabled)
        {
            if (!SnapyrWrapper.isInitialized) {
                handleNotInitialized("SetDebugEnabled");
                return;
            }
            
            try {
                wrapper.SetDebugEnabled(enabled);
            } catch (Exception e) {
                Debug.LogWarning("Encountered SDK exception when attempting operation: SetDebugEnabled: " + e.Message);
                Debug.LogWarning(e.Message);
            }
        }

        private ISnapyrWrapper createWrapper()
        {
#if UNITY_EDITOR
            return new SnapyrEditorWrapper();
#endif
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
#if UNITY_ANDROID
                    return new SnapyrAndroidWrapper();
#endif
                case RuntimePlatform.IPhonePlayer:
#if UNITY_IOS
                    return new SnapyriOSWrapper();
#endif
                default:
                    throw new Exception("Invalid Platform");
            }
        }
    }
}
