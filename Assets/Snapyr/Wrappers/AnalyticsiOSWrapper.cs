using System.Runtime.InteropServices;
using Snapyr.Types;
using System.Collections.Generic;

namespace Snapyr.Wrappers
{
    internal class AnalyticsiOSWrapper : IAnalyticsWrapper
    {
        [DllImport("__Internal")]
        private static extern void InitSnapyrAnalytics(string writeKey, bool trackApplicationLifecycleEvents);
        [DllImport("__Internal")]
        private static extern void Identify(string id, string[] traitsNames, string[] traitsVals);
        [DllImport("__Internal")]
        private static extern void SnapyrTrack(string snapyrevent, string[] traitsNames, string[] traitsVals);
        [DllImport("__Internal")]
        private static extern void SnapyrScreen(string name);
        [DllImport("__Internal")]
        private static extern void SnapyrReset();
        [DllImport("__Internal")]
        private static extern void SDebug(bool on);

        public void Initialize(AnalyticsConfiguration config)
        {
#if UNITY_IOS && !UNITY_EDITOR
            InitSnapyrAnalytics(config.writeKey, config.trackApplicationLifecycleEvents);
#endif
        }

        public void Identify(string id, Dictionary<string, string> sparams)
        {
            string[] names = null;
            string[] vals = null;
            if (sparams != null) {
              names = new string[sparams.Count];
              vals = new string[sparams.Count];
              sparams.Keys.CopyTo(names, 0);
              sparams.Values.CopyTo(vals, 0);
            }
#if UNITY_IOS && !UNITY_EDITOR
            Identify(id, names, vals);
#endif
        }

        public void SnapyrTrack(string snapyrevent, Dictionary<string, string> sparams)
        {
            string[] names = null;
            string[] vals = null;
            if (sparams != null) {
              names = new string[sparams.Count];
              vals = new string[sparams.Count];
              sparams.Keys.CopyTo(names, 0);
              sparams.Values.CopyTo(vals, 0);
            }
#if UNITY_IOS && !UNITY_EDITOR
            SnapyrTrack(snapyrevent, names, vals);
#endif

        }

        public void Screen(string name)
        {
#if UNITY_IOS && !UNITY_EDITOR
          SnapyrScreen(name);
#endif
        }

        public void Reset()
        {
#if UNITY_IOS && !UNITY_EDITOR
          SnapyrReset();
#endif
        }

        public void SnapyrDebug(bool on)
        {
#if UNITY_IOS && !UNITY_EDITOR
          SDebug(on);
#endif
        }
    }
}
