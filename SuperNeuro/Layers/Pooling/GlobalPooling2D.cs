﻿using SuperchargedArray;
using SuperNeuro.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperNeuro.Layers
{
    public class GlobalPooling2D : BaseLayer
    {
        public PoolingPoolType PoolingType { get; set; }

        public GlobalPooling2D(PoolingPoolType poolingType)
            : base("globalpooling2d")
        {
            PoolingType = poolingType;
        }

        public override void Forward(SuperArray x)
        {
            base.Forward(x);
            if (PoolingType == PoolingPoolType.Max)
            {
                Output = Ops.Max(x, new uint[] { 2, 3 });
            }
            else
            {
                Output = Ops.Mean(x, new uint[] { 2, 3 });
            }
        }

        public override void Backward(SuperArray outputgrad)
        {
            Input.Grad = outputgrad;
        }
    }
}
