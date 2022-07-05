// *************************************************************
// Copyright (c) 1991-2021 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
//
//  LTKernelDetectBusinessCardCommand.h
//  Leadtools.ImageProcessing.Kernel
//

#import <Leadtools/LTRasterCommand.h>
#import <Leadtools/LTPrimitives.h>

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTKernelDetectBusinessCardCommand : LTRasterCommand

@property (nonatomic, strong, readonly, nullable) NSArray<NSValue *> *businessCardArea; // LeadPoint[4]

@end

NS_ASSUME_NONNULL_END
