using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Services
{
    internal class PassDetialService
    {
        const int MIN_DRAWER_HEIGHT = 130;
        const int TOP_ELEMENTS_OFFSET = 86;

        public static int CalculateMarksDrawerHeight(int lengthPrintMarks, int lengthMovementMarks, int drawerElementHeight, string? passTypeId, double maxHeightDrawer)
        {
            if (passTypeId != "1" && lengthPrintMarks > 0) lengthPrintMarks = 0;
            int calculatedHeight = (lengthPrintMarks + lengthMovementMarks) * drawerElementHeight;
            return calculatedHeight > (int)maxHeightDrawer ? (int)maxHeightDrawer
                : calculatedHeight < MIN_DRAWER_HEIGHT ? MIN_DRAWER_HEIGHT : calculatedHeight + TOP_ELEMENTS_OFFSET;
        }

        public static int CalculateApproveProgressDrawerHeight(int lengthProgressMarks, bool hasMol ,int drawerElementHeight, double maxHeightDrawer)
        {
            if (hasMol) lengthProgressMarks ++;
            int calculatedHeight = lengthProgressMarks * drawerElementHeight;
            return calculatedHeight > (int)maxHeightDrawer ? (int)maxHeightDrawer
                : calculatedHeight < MIN_DRAWER_HEIGHT ? MIN_DRAWER_HEIGHT : calculatedHeight + TOP_ELEMENTS_OFFSET;
        }
    }
}
 