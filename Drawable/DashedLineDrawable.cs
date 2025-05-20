using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passes.Drawable
{
    class DashedLineDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Color.FromArgb("#3F5468");
            canvas.StrokeSize = 1;
            canvas.StrokeDashPattern = new float[] { 4, 4 };
            canvas.DrawLine(0, 5, 0, dirtyRect.Height);
        }
    }
}
