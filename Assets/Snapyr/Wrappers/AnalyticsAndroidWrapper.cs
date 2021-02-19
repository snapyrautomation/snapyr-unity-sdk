using Snapyr.Types;
using UnityEngine;
using System.Collections.Generic;

namespace Snapyr.Wrappers
{
    internal class AnalyticsAndroidWrapper : IAnalyticsWrapper
    {
        public AnalyticsAndroidWrapper()
        {
        }

        public void Initialize(AnalyticsConfiguration config)
        {
            throw new System.NotImplementedException();
        }

        public void Identify(string id, Dictionary<string, string> sparams)
        {
            Debug.Log("Identify Called " + id);
        }

        public void SnapyrTrack(string snapyrevent, Dictionary<string, string> sparams)
        {
            Debug.Log("SnapyrTrack Called " + snapyrevent);
        }

        public void Screen(string name)
        {
            Debug.Log("Screen Called " + name);
        }

        public void Reset()
        {
            Debug.Log("Reset Called ");
        }

        public void SnapyrDebug(bool on)
        {
            Debug.Log("SnapyrDebug Called ");
        }
    }
}
