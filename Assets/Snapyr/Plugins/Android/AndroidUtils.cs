using UnityEngine;

namespace Snapyr.Plugins.Android
{
    public class AndroidUtils
    {
        public static AndroidJavaClass GetUnityPlayerClass() => new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        public static AndroidJavaObject GetCurrentActivity() =>
            GetUnityPlayerClass().GetStatic<AndroidJavaObject>("currentActivity");

        public static AndroidJavaObject GetApplicationContext() =>
            GetCurrentActivity().Call<AndroidJavaObject>("getApplicationContext");
    }
}