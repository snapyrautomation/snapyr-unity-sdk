using Snapyr.Types;

namespace Snapyr
{
    internal interface IAnalyticsWrapper
    {
        void Initialize(string writeKey, AnalyticsConfiguration config);
        void Identify(string id, Traits traits);
        void Track(string ev, Properties props);
        void Screen(string name);
        void Reset();
        void SetDebugEnabled(bool enabled);
    }
}
