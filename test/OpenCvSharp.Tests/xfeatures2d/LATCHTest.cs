﻿using System;
using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D
{
    // ReSharper disable once InconsistentNaming
    
    public class LATCHTest : TestBase
    {
        [Fact]
        public void CreateAndDispose()
        {
            var surf = LATCH.Create();
            surf.Dispose();
        }

        [Fact]
        public void Compute()
        {
            using (var color = Image("lenna.png", ImreadModes.Color))
            using (var gray = Image("lenna.png", ImreadModes.GrayScale))
            using (var descriptors = new Mat())
            using (var lucid = LATCH.Create())
            using (var surf = SURF.Create(500))
            {
                var keypoints = surf.Detect(gray);
                lucid.Compute(color, ref keypoints, descriptors);
            }
        }

        [Fact]
        public void DescriptorSize()
        {
            using (var alg = LATCH.Create())
            {
                var sz = alg.DescriptorSize;
                Assert.Equal(32, sz);
            }
        }

        [Fact]
        public void DefaultNorm()
        {
            using (var alg = LATCH.Create())
            {
                var defnorm = alg.DefaultNorm;
                Assert.Equal(6, defnorm);
            }
        }
    }
}
