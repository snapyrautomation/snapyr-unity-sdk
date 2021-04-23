using Snapyr.Types;

namespace Snapyr
{
    internal interface ISnapyrWrapper
    {
        void Initialize(string writeKey, SnapyrConfiguration config);
        void Identify(string id, Traits traits);
        void Track(string ev, Properties props);
        void Screen(string name);
        void Reset();
        void SetDebugEnabled(bool enabled);
    }
}
