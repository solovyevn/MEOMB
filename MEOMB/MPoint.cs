using System;
using System.Collections.Generic;
using System.Text;

namespace MEOMB
{
    public class MPoint
    {
        public MPoint(double xx, double yy, int resx, int resy)
        {
            x = Convert.ToInt32(xx * resx);
            y = Convert.ToInt32(yy * resy);
        }
        public int x;
        public int y;
    }
}
