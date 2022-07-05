// *************************************************************
// Copyright (c) 1991-2021 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
//
//  LTKernelPerspectiveDeskewCommand.h
//  Leadtools.ImageProcessing.Kernel
//

#if defined(PERSPECTIVE_DESKEW_FILTER_SUPPORT)

#import <Leadtools/LTRasterCommand.h>
#import <Leadtools/LTRasterImage.h>

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTKernelPerspectiveDeskewCommand : LTRasterCommand

@property (nonatomic, strong, readonly, nullable) LTRasterImage *destinationImage;

@end

NS_ASSUME_NONNULL_END

#endif //#if defined(PERSPECTIVE_DESKEW_FILTER_SUPPORT)
