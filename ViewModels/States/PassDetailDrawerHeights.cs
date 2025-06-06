﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels.States
{
    internal class PassDetailDrawerHeights
    {
        public static int PassMarksElementHeight { get; set; } = 157;
        public static int PassApproveProgressElementHeight { get; set; } = 134;
        public static double PassDetailDrawerMaxHeight { get; set; } = 750;

        public static double HeightOfDrawerEnabledOrDisabled(double height)
        {
            return height == 0 ? PassDetailDrawerMaxHeight : 0;
        }

    }
}
