using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class Interval1D
    {
        public double Min { get; private set; }
        public double Max { get; private set; }

        public Interval1D(double min, double max)
        {
            this.Min = min;
            this.Max = max;
        }

        public bool Intersects(Interval1D that)
        {
            if (this.Max < that.Min) return false;
            if (that.Max < this.Min) return false;
            return true;
        }

        public override string ToString()
        {
            return string.Format("min:{0}, max:{1}", this.Min, this.Max);
        }
    }
}
