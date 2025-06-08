using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.ViewModels.Helpers
{
    internal class ElementHeightHelper
    {
        public static double GetHeight()
        {
            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
            return displayInfo.Height / displayInfo.Density * 0.8;
        }
    }
}
