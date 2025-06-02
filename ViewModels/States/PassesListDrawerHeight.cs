using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels.States
{
    internal class PassesListDrawerHeight
    {
        public static double PassDetailDrawerMaxHeight { get; set; } = 380;

        public static double HeightOfDrawerEnabledOrDisabled(double height)
        {
            return height == 0 ? PassDetailDrawerMaxHeight : 0;
        }
    }
}
