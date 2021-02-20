#import <Foundation/Foundation.h>
#import "UnityAppController.h"
#import "UnityFramework/Snapyr-Swift.h"

@interface SnapyrBridge : UnityAppController
    @end
extern "C" {
    typedef void (*callbackFunc)(bool);
}
static callbackFunc actionCallback;
