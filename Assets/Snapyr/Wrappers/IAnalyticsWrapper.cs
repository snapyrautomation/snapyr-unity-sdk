using Snapyr.Types;
using System.Collections.Generic;

namespace Snapyr
{
    internal interface IAnalyticsWrapper
    {
        void Initialize(AnalyticsConfiguration config);
        void SnapyrTrack(string snapyrevent, Dictionary<string, string> sparams);
        void Identify(string id, Dictionary<string, string> sparams);
        void Screen(string name);
        void Reset();
        void SnapyrDebug(bool on);
    }
}
