using Snapyr.Types;
using UnityEngine;

namespace Snapyr.Plugins.Android
{
    public class AndroidSnapyr
    {
        private AndroidJavaClass clazz;

        public AndroidSnapyr()
        {
            clazz = new AndroidJavaClass("com.snapyr.sdk.Snapyr");
        }

        public void Initialize(string writeKey, SnapyrConfiguration config)
        {
            var builder =
                new AndroidJavaObject("com.snapyr.sdk.Snapyr$Builder", AndroidUtils.GetApplicationContext(),
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

            if (config.enableSnapyrPushHandling == true)
            {
                builder.Call<AndroidJavaObject>("enableSnapyrPushHandling");
            }

            if (config.enableDevEnvironment == true)
            {
                // Dev mode (points at dev-api and dev-engine)
                builder.Call<AndroidJavaObject>("enableDevEnvironment");
            }

            var analytics = builder.Call<AndroidJavaObject>("build");
            clazz.CallStatic("setSingletonInstance", analytics);
        }

        private AndroidJavaObject getJavaValue(object input)
        {
            var valueType = input.GetType();

            if (valueType == typeof(string))
            {
                return new AndroidJavaObject("java.lang.String", (string)input);
            }
            else if (valueType == typeof(int))
            {
                return new AndroidJavaObject("java.lang.Integer", (int)input);
            }
            else if (valueType == typeof(double))
            {
                return new AndroidJavaObject("java.lang.Double", (double)input);
            }
            else if (valueType == typeof(bool))
            {
                return new AndroidJavaObject("java.lang.Boolean", (bool)input);
            }

            return null;
        }

        public void Identify(string id, Traits traits)
        {
            if (traits != null)
            {
                traits.PutUserId(id);
                AndroidJavaObject t = new AndroidJavaObject("com.snapyr.sdk.Traits");
                foreach (var name in traits.Keys)
                {
                    if (traits[name] == null)
                    {
                        continue;
                    }

                    var javaVal = getJavaValue(traits[name]);
                    t.Call<AndroidJavaObject>("putValue", name, javaVal);
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
                AndroidJavaObject p = new AndroidJavaObject("com.snapyr.sdk.Properties");
                foreach (var name in props.Keys)
                {
                    if (props[name] == null)
                    {
                        continue;
                    }

                    var javaVal = getJavaValue(props[name]);
                    p.Call<AndroidJavaObject>("putValue", name, javaVal);
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