using System;
using Snapyr.Types;

namespace Snapyr.Wrappers
{
    internal class AnalyticsAndroidWrapper : IAnalyticsWrapper
    {
        public void Initialize(string writeKey, AnalyticsConfiguration config)
        {
            throw new NotImplementedException();
        }

        public void Identify(string id, Traits traits)
        {
            throw new NotImplementedException();
        }

        public void Track(string ev, Properties props)
        {
            throw new NotImplementedException();
        }

        public void Screen(string name)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void SetDebugEnabled(bool enabled)
        {
            throw new NotImplementedException();
        }
    }
}