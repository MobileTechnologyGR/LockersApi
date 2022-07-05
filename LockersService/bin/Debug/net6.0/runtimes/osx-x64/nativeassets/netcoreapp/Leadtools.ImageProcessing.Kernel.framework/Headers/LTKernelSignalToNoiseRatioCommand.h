// *************************************************************
// Copyright (c) 1991-2021 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
//
//  LTKernelSignalToNoiseRatioCommand.h
//  Leadtools.ImageProcessing.Kernel
//

#import <Leadtools/LTRasterCommand.h>

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTKernelSignalToNoiseRatioCommand : LTRasterCommand

@property (nonatomic, assign, readonly) double ratio;

@end

NS_ASSUME_NONNULL_END
