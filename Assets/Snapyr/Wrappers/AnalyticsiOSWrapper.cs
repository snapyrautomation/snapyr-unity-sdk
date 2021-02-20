using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Snapyr.Types;
using UnityEngine;

namespace Snapyr.Wrappers
{
    internal class AnalyticsiOSWrapper : IAnalyticsWrapper
    {
        [DllImport("__Internal")]
        private static extern void _analyticsInit(string writeKey, string configJson);

        [DllImport("__Internal")]
        private static extern void _analyticsIdentify(string id, string traitsJson);

        [DllImport("__Internal")]
        private static extern void _analyticsTrack(string ev, string propsJson);

        [DllImport("__Internal")]
        private static extern void _analyticsScreen(string name);

        [DllImport("__Internal")]
        private static extern void _analyticsReset();

        [DllImport("__Internal")]
        private static extern void _analyticsSetDebug(bool enabled);


        public void Initialize(string writeKey, AnalyticsConfiguration config)
        {
            _analyticsInit(writeKey, config != null ? JsonConvert.SerializeObject(config) : null);
        }

        public void Identify(string id, Traits traits)
        {
            _analyticsIdentify(id, traits != null ? JsonConvert.SerializeObject(traits) : null);
        }

        public void Track(string ev, Properties props)
        {
            _analyticsTrack(ev, props != null ? JsonConvert.SerializeObject(props) : null);
        }

        public void Screen(string name)
        {
            _analyticsScreen(name);
        }

        public void Reset()
        {
            _analyticsReset();
        }

        public void SetDebugEnabled(bool enabled)
        {
            _analyticsSetDebug(enabled);
        }
    }
}