using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class Point2D
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double DistanceTo(Point2D that)
        {
            var dx = this.X - that.X;
            var dy = this.Y = that.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
