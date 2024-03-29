#import <Foundation/Foundation.h>
#import "SnapyrPayload.h"

NS_ASSUME_NONNULL_BEGIN

NS_SWIFT_NAME(IdentifyPayload)
@interface SnapyrIdentifyPayload : SnapyrPayload

@property (nonatomic, readonly, nullable) JSON_DICT traits;

- (instancetype)initWithUserId:(NSString *)userId
                   anonymousId:(NSString *_Nullable)anonymousId
                        traits:(JSON_DICT _Nullable)traits
                       context:(JSON_DICT)context
                  integrations:(JSON_DICT)integrations;

@end

NS_ASSUME_NONNULL_END
