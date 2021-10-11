using Snapyr.Types;
using Snapyr.Utils;
using UnityEngine;

namespace Snapyr
{
    public class SnapyrEditorWrapper : ISnapyrWrapper
    {
        public void Initialize(string writeKey, SnapyrConfiguration config)
        {
            // throw new System.Exception("Intentional error for testing");
            Debug.Log("Initialize Called " + writeKey + Json.toString(config));
        }

        public void Identify(string id, Traits traits)
        {
            Debug.Log("Identify Called " + id + ", " + Json.toString(traits));
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
