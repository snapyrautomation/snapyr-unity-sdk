using System;
using Snapyr.Types;
using Snapyr.Wrappers;
using UnityEngine;

namespace Snapyr
{
    public class SnapyrUnity : MonoBehaviour
    {
        #region Singleton implementation

        private static SnapyrUnity _instance;
        public static SnapyrUnity Instance {
        get {
           if (_instance == null) {
               var obj = new GameObject("SnapyrUnity");
               _instance = obj.AddComponent<SnapyrUnity>();
           }
           return _instance;
       }
     }

     void Awake() {
        if (_instance != null) {
            Destroy(gameObject);
            return;
         }
        DontDestroyOnLoad(gameObject);
     }
     #endregion

     #region Delegates

     public System.Action<string> onSnapyrAction;
     public void OnAction(string data) {
        Debug.LogError("OnAction Callback: " + data);
        if (onSnapyrAction != null) {
            onSnapyrAction.Invoke(data);
        }
      }
    }

    #endregion

}
