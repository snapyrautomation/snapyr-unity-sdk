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
                new AndroidJavaObject("com.snapyr.analytics.Analytics$Builder", AndroidUtils.GetApplicationContext(),
                    writeKey
                );
            if (config.trackApplicationLifecycleEvents == true)
            {
                builder.Call<AndroidJavaObject>("trackApplicationLifecycleEvents");
            }

            if (config.recordScreenViews == true)
            {
                builder.Call<AndroidJavaObject>("recordScreenViews");
            }

            if (config.trackDeepLinks == true)
            {
                builder.Call<AndroidJavaObject>("trackDeepLinks");
            }

            var analytics = builder.Call<AndroidJavaObject>("build");
            clazz.CallStatic("setSingletonInstance", analytics);
        }

        public void Identify(string id, Traits traits)
        {
            Debug.Log("Identify Called!!!");
            if (traits != null)
            {
                traits.PutUserId(id);
                AndroidJavaObject t = new AndroidJavaObject("com.snapyr.analytics.Traits");
                foreach (var name in traits.Keys)
                {
                    t.Call<AndroidJavaObject>("putValue", name, traits[name]);
                }
                getAnalyticsWithContext().Call("identify", t);
            }
            else
            {
                getAnalyticsWithContext().Call("identify", id);
            }
        }

        public void Track(string ev, Properties props)
        {
            if (props != null)
            {
                AndroidJavaObject p = new AndroidJavaObject("com.snapyr.analytics.Properties");
                foreach (var name in props.Keys)
                {
                    p.Call<AndroidJavaObject>("putValue", name, props[name]);
                }
                getAnalyticsWithContext().Call("track", ev, p);
            }
            else
            {
                getAnalyticsWithContext().Call("track", ev);
            }
        }

        public void Screen(string name)
        {
            getAnalyticsWithContext().Call("screen", name);
        }

        public void Reset()
        {
            getAnalyticsWithContext().Call("reset");
        }

        private AndroidJavaObject getAnalyticsWithContext() =>
            clazz.CallStatic<AndroidJavaObject>("with", AndroidUtils.GetApplicationContext());
    }
}
