import Foundation
import Snapyr

public class SnapyrBridge : NSObject {

    @objc public static func initSnapyr(writeKey: String, config: [String : Any], callback: @escaping ((NSString) -> Void)) -> Void {
        let snapyrConf = config["apiHost"] == nil
            ? SnapyrConfiguration(writeKey: writeKey)
            : SnapyrConfiguration(writeKey: writeKey, defaultAPIHost: URL(string: config["apiHost"] as! String));
        if(config["trackApplicationLifecycleEvents"] != nil){
            snapyrConf.trackApplicationLifecycleEvents = config["trackApplicationLifecycleEvents"] as! Bool;
        }
        if(config["shouldUseBluetooth"] != nil){
            snapyrConf.shouldUseBluetooth = config["shouldUseBluetooth"] as! Bool;
        }
        if(config["recordScreenViews"] != nil){
            snapyrConf.recordScreenViews = config["recordScreenViews"] as! Bool;
        }
        if(config["trackInAppPurchases"] != nil){
            snapyrConf.trackInAppPurchases = config["trackInAppPurchases"] as! Bool;
        }
        if(config["trackPushNotifications"] != nil){
            snapyrConf.trackPushNotifications = config["trackPushNotifications"] as! Bool;
        }
        if(config["trackDeepLinks"] != nil){
            snapyrConf.trackDeepLinks = config["trackDeepLinks"] as! Bool;
        }
        if(config["shouldUseLocationServices"] != nil){
            snapyrConf.shouldUseLocationServices = config["shouldUseLocationServices"] as! Bool;
        }
        if(config["enableAdvertisingTracking"] != nil){
            snapyrConf.enableAdvertisingTracking = config["enableAdvertisingTracking"] as! Bool;
        }
        snapyrConf.actionHandler = {
            action in
            print("Action Back",action)
            do {
                let jsonData = try JSONSerialization.data(withJSONObject: action, options: .prettyPrinted)
                let decoded = try JSONSerialization.jsonObject(with: jsonData, options: [])
                if let dictFromJSON = decoded as? [String:String] {
                    let str2 = dictFromJSON.description as NSString
                    callback(str2)
                }
            } catch {
                print(error.localizedDescription)
            }
        }
        Snapyr.setup(with: snapyrConf);
    }

    @objc public static func identify(id: String, traits: [String : Any]) -> Void {
        Snapyr.shared().identify(id, traits: traits)
    }

    @objc public static func track(event: String, properties: [String : Any]) -> Void {
        Snapyr.shared().track(event, properties: properties)
    }

    @objc public static func screen(screenTitle: String) -> Void {
        Snapyr.shared().screen(screenTitle)
    }

    @objc public static func reset() -> Void {
        Snapyr.shared().reset()
    }

    @objc public static func debug(on: Bool) -> Void {
        Snapyr.debug(on)
    }
}
