using Snapyr;
using Snapyr.Types;
using UnityEngine;
using System.Collections.Generic;

public class SdkTest : MonoBehaviour
{
    Dictionary<string, string> testparam = new Dictionary<string, string>();
    Dictionary<string, string> testparami = new Dictionary<string, string>();
    int callnum = 0;
    int callnumi = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(">>>>>>> Starting Snapyr SDK Test <<<<<<<");
        AnalyticsWrapper.I.Initialize(new AnalyticsConfiguration("4IIPRssIBRGzcQdkrYJhMtcXwB4a6AKf"));
    }

    public void handleIdentifyButtonClick()
    {
        Debug.Log("IDENTIFY CLICKED " + callnumi);
        if (callnumi == 0) {
          testparami.Add("name1", "value1");
          AnalyticsWrapper.I.Identify("testevent0",testparami);
        } else if (callnumi == 1) {
          testparami.Add("name2", "value2");
          AnalyticsWrapper.I.Identify("testevent1",testparami);
        }  else {
          AnalyticsWrapper.I.Identify("testevent"+callnumi,null);
        }
        callnumi++;
    }

    public void handleTrackButtonClick()
    {
        Debug.Log("Track CLICKED" + callnum);
        if (callnum == 0) {
          testparam.Add("name1", "value1");
          AnalyticsWrapper.I.SnapyrTrack("testevent0",testparam);
        } else if (callnum == 1) {
          testparam.Add("name2", "value2");
          AnalyticsWrapper.I.SnapyrTrack("testevent1",testparam);
        } else {
          AnalyticsWrapper.I.SnapyrTrack("testevent"+callnum,null);
        }
        callnum++;
    }

    public void handleScreenButtonClick()
    {
        Debug.Log("Screen CLICKED");
        AnalyticsWrapper.I.Screen("testscreen");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
