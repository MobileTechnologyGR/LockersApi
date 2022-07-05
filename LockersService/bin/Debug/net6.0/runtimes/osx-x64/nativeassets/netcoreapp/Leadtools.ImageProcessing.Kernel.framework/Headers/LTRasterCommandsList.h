// *************************************************************
// Copyright (c) 1991-2021 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
//
//  LTRasterCommandsList.h
//  Leadtools.ImageProcessing.Kernel
//

#import <Leadtools/LTRasterCommand.h>

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTRasterCommandsList : NSMutableArray<LTRasterCommand *>

// Used only if there is one or more commands with a "destinationImage" property run successfully
@property (nonatomic, strong, readonly, nullable) LTRasterImage *resultImage;

- (BOOL)run:(LTRasterImage *)image error:(NSError **)error;
- (BOOL)run:(LTRasterImage *)image commandCompleted:(void (^ __nullable)(LTRasterCommand *, BOOL *))commandCompletedHandler error:(NSError **)error;

@end

NS_ASSUME_NONNULL_END
