using System;
using Snapyr.Plugins.Android;
using Snapyr.Types;

namespace Snapyr.Wrappers
{
    internal class SnapyrAndroidWrapper : ISnapyrWrapper
    {
        private AndroidSnapyr analytics;

        public void Initialize(string writeKey, SnapyrConfiguration config)
        {
            analytics = new AndroidSnapyr();
            analytics.Initialize(writeKey, config);
        }

        public void Identify(string id, Traits traits)
        {
            analytics.Identify(id, traits);
        }

        public void Track(string ev, Properties props)
        {
            analytics.Track(ev, props);
        }

        public void Screen(string name)
        {
            analytics.Screen(name);
        }

        public void Reset()
        {
            analytics.Reset();
        }

        public void SetDebugEnabled(bool enabled)
        {

        }
    }
}
