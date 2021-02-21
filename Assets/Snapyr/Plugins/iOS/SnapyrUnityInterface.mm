#import "UnityFramework/Snapyr-Swift.h"
#import "UnityInterface.h"

#pragma mark - Actual Unity C# interface (extern C)

extern "C"
{
    NSDictionary* getJsonDictionary(const char* json)
    {
        NSData* jsonData = [[NSString stringWithUTF8String:json] dataUsingEncoding:NSUTF8StringEncoding];
        NSError* jsonError = nil;
        NSDictionary* result = [NSJSONSerialization JSONObjectWithData:jsonData options:0 error:&jsonError];
        if(jsonError != nil){
            NSLog(@"JSON Serialization Failed %@", jsonError);
            return nil;
        }
        return result;
    }

    void _analyticsInit(const char* writeKey, const char* confJson)
    {
        NSLog(@"Analytics Init Called %s, %s", writeKey, confJson);
        NSDictionary* conf = confJson != nil ? getJsonDictionary(confJson) : nil;
        [SnapyrBridge initSnapyrWithWriteKey:[NSString stringWithUTF8String:writeKey] config:conf callback:^(NSString*) {
            const char* test = "test";
            UnitySendMessage("SnapyrUnity", "OnAction", test);
        }];
    }

    void _analyticsIdentify(const char* id, const char* traitsJson)
    {
        NSLog(@"Analytics Identify Called %s, %s", id, traitsJson);
        NSDictionary* traits = traitsJson != nil ? getJsonDictionary(traitsJson) : nil;
        [SnapyrBridge identifyWithId:[NSString stringWithUTF8String:id] traits:traits];
    }

    void _analyticsTrack(const char* ev, const char* propsJson)
    {
        NSLog(@"Analytics Identify Called %s, %s", ev, propsJson);
        NSDictionary* props = propsJson != nil ? getJsonDictionary(propsJson) : nil;
        [SnapyrBridge trackWithEvent:[NSString stringWithUTF8String:ev] properties:props];
    }

    void _analyticsScreen(const char* name)
    {
        NSLog(@"Analytics Screen Called");
        [SnapyrBridge screenWithScreenTitle:[NSString stringWithUTF8String:name]];
    }

    void _analyticsReset()
    {
        NSLog(@"Analytics Reset Called");
        [SnapyrBridge reset];
    }

    void _analyticsSetDebug(bool on)
    {
        NSLog(@"Analytics Debug Called");
        [SnapyrBridge debugOn:on];
    }
}
