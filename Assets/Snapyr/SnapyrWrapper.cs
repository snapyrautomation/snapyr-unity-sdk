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

        public void Initialize(string writeKey, SnapyrConfiguration config)
        {
            wrapper.Initialize(writeKey, config);
            SnapyrWrapper.isInitialized = true;
        }

        public void Identify(string id, Traits traits)
        {
            wrapper.Identify(id, traits);
        }

        public void Track(string ev, Properties props)
        {
            wrapper.Track(ev, props);
        }

        public void Screen(string name)
        {
            wrapper.Screen(name);
        }

        public void Reset()
        {
            wrapper.Reset();
        }

        public void SetDebugEnabled(bool enabled)
        {
            wrapper.SetDebugEnabled(enabled);
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
