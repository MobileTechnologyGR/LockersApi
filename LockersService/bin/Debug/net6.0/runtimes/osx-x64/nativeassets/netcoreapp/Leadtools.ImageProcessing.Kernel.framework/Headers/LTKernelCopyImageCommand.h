// *************************************************************
// Copyright (c) 1991-2021 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
//
//  LTKernelCopyImageCommand.h
//  Leadtools.ImageProcessing.Kernel
//

#import <Leadtools/LTRasterCommand.h>
#import <Leadtools/LTRasterImage.h>

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTKernelCopyImageCommand : LTRasterCommand

@property (nonatomic, strong, readonly, nullable) LTRasterImage *destinationImage;

@end

NS_ASSUME_NONNULL_END
