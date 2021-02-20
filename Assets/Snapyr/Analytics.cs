using System;
using Snapyr.Types;
using Snapyr.Wrappers;
using UnityEngine;

namespace Snapyr
{
    public class AnalyticsWrapper : IAnalyticsWrapper
    {
        private static readonly AnalyticsWrapper instance = new AnalyticsWrapper();

        public static AnalyticsWrapper I => instance;

        private IAnalyticsWrapper wrapper;

        static AnalyticsWrapper()
        {

        }
        private AnalyticsWrapper()
        {
            wrapper = createWrapper();
        }

        public void Initialize(string writeKey, AnalyticsConfiguration config)
        {
            wrapper.Initialize(writeKey, config);
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

        private IAnalyticsWrapper createWrapper()
        {
#if UNITY_EDITOR
            return new AnalyticsEditorWrapper();
#endif
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    return new AnalyticsAndroidWrapper();
                case RuntimePlatform.IPhonePlayer:
                    return new AnalyticsiOSWrapper();
                default:
                    throw new Exception("Invalid Platform");
            }
        }
    }
}
