using Snapyr.Types;
using UnityEngine;

namespace Snapyr.Plugins.Android
{
    public class AndroidAnalytics
    {
        private AndroidJavaClass clazz;

        public AndroidAnalytics()
        {
            clazz = new AndroidJavaClass("com.snapyr.analytics.Analytics");
        }

        public void Initialize(string writeKey, AnalyticsConfiguration config)
        {
            var builder =
                new AndroidJavaObject("com.snapyr.analytics.Analytics.Builder", new object[2]
                {
                    AndroidUtils.GetApplicationContext(),
                    writeKey
                });
            if (config.trackApplicationLifecycleEvents == true)
            {
                builder.Call("trackApplicationLifecycleEvents");
            }
            if (config.recordScreenViews == true)
            {
                builder.Call("recordScreenViews");
            }
            if (config.trackDeepLinks == true)
            {
                builder.Call("trackDeepLinks");
            }
            clazz.CallStatic("setSingletonInstance", builder.Call<AndroidJavaObject>("build"));
        }
    }
}