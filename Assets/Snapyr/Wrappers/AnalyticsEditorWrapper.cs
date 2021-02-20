using Newtonsoft.Json;
using Snapyr.Types;
using UnityEngine;

namespace Snapyr
{
    public class AnalyticsEditorWrapper : IAnalyticsWrapper
    {
        public void Initialize(string writeKey, AnalyticsConfiguration config)
        {
            Debug.Log("Initialize Called " + writeKey);
        }

        public void Identify(string id, Traits traits)
        {
            Debug.Log("Identify Called " + id + ", " + JsonConvert.SerializeObject(traits));
        }

        public void Track(string ev, Properties props)
        {
            Debug.Log("SnapyrTrack Called " + ev);
        }

        public void Screen(string name)
        {
            Debug.Log("Screen Called " + name);
        }

        public void Reset()
        {
            Debug.Log("Reset Called ");
        }

        public void SetDebugEnabled(bool enabled)
        {
            Debug.Log("Debug mode changed " + enabled);
        }
    }
}