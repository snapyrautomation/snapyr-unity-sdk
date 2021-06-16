namespace Snapyr.Types
{
    public class SnapyrConfiguration
    {
        public string apiHost { get; set; }

        public bool? trackApplicationLifecycleEvents { get; set; }

        public bool? shouldUseBluetooth { get; set; }

        public bool? recordScreenViews { get; set; }

        public bool? trackInAppPurchases { get; set; }

        public bool? trackPushNotifications { get; set; }

        public bool? trackDeepLinks { get; set; }

        public bool? shouldUseLocationServices { get; set; }

        public bool? enableAdvertisingTracking { get; set; }

        public bool? enableSnapyrPushHandling { get; set; }

        public bool? enableDevEnvironment { get; set; }

        public class Builder
        {
            private SnapyrConfiguration config = new SnapyrConfiguration();

            public Builder apiHost(string value)
            {
                config.apiHost = value;
                return this;
            }

            public Builder trackApplicationLifecycleEvents(bool value)
            {
                config.trackApplicationLifecycleEvents = value;
                return this;
            }

            public Builder shouldUseBluetooth(bool value)
            {
                config.shouldUseBluetooth = value;
                return this;
            }

            public Builder recordScreenViews(bool value)
            {
                config.recordScreenViews = value;
                return this;
            }

            public Builder trackInAppPurchases(bool value)
            {
                config.trackInAppPurchases = value;
                return this;
            }

            public Builder trackPushNotifications(bool value)
            {
                config.trackPushNotifications = value;
                return this;
            }

            public Builder trackDeepLinks(bool value)
            {
                config.trackDeepLinks = value;
                return this;
            }

            public Builder shouldUseLocationServices(bool value)
            {
                config.shouldUseLocationServices = value;
                return this;
            }

            public Builder enableAdvertisingTracking(bool value)
            {
                config.enableAdvertisingTracking = value;
                return this;
            }

            public Builder enableSnapyrPushHandling(bool value)
            {
                config.enableSnapyrPushHandling = value;
                return this;
            }

            public Builder enableDevEnvironment(bool value)
            {
                config.enableDevEnvironment = value;
                return this;
            }

            public SnapyrConfiguration build() => config;
        }
    }
}