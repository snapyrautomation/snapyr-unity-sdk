namespace Snapyr.Types
{
    public class AnalyticsConfiguration
    {
        public bool trackApplicationLifecycleEvents { get; private set; }
        public string writeKey {get; private set; }

        public AnalyticsConfiguration(string writeKey)
        {
            this.writeKey = writeKey;
            trackApplicationLifecycleEvents = false;
        }

        public AnalyticsConfiguration(string writeKey, bool trackApplicationLifecycleEvents)
        {
            this.trackApplicationLifecycleEvents = trackApplicationLifecycleEvents;
            this.writeKey = writeKey;
        }
    }
}