// *************************************************************
// Copyright (c) 1991-2021 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
//
//  LTKernelManualPerspectiveCorrectionCommand.h
//  Leadtools.ImageProcessing.Kernel
//

#import <Leadtools/LTRasterCommand.h>
#import <Leadtools/LTRasterImage.h>
#import <Leadtools/LTPrimitives.h>

NS_ASSUME_NONNULL_BEGIN

NS_CLASS_AVAILABLE(10_10, 8_0)
@interface LTKernelManualPerspectiveCorrectionCommand : LTRasterCommand

@property (nonatomic, strong, readonly, nullable) LTRasterImage *destinationImage;

@property (nonatomic, strong, nullable)           NSArray<NSValue *> *inputPoints; // LeadPoint[4]
@property (nonatomic, strong, nullable)           NSArray<NSValue *> *mappingPoints; // LeadPoint[4]

@end

NS_ASSUME_NONNULL_END
