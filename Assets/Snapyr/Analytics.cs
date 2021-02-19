using System;
using Snapyr.Types;
using Snapyr.Wrappers;
using UnityEngine;
using System.Collections.Generic;

namespace Snapyr
{
    public class AnalyticsWrapper : IAnalyticsWrapper
    {
        private static readonly AnalyticsWrapper instance = new AnalyticsWrapper();

        public static AnalyticsWrapper I => instance;

        private IAnalyticsWrapper platform;

        static AnalyticsWrapper()
        {

        }
        private AnalyticsWrapper()
        {
            platform = getPlatform();
        }

        public void Initialize(AnalyticsConfiguration config)
        {
            platform.Initialize(config);
        }

        public void Identify(string id, Dictionary<string, string> sparams)
        {
            platform.Identify(id, sparams);
        }

        public void SnapyrTrack(string snapyrevent, Dictionary<string, string> sparams)
        {
            platform.SnapyrTrack(snapyrevent, sparams);
        }

        public void Screen(string name)
        {
          platform.Screen(name);
        }

        public void Reset()
        {
            platform.Reset();
        }

        public void SnapyrDebug(bool on)
        {
            platform.SnapyrDebug(on);
        }


        private IAnalyticsWrapper getPlatform()
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
