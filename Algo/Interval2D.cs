using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public class Interval2D
    {
        public Interval1D X { get; private set; }
        public Interval1D Y { get; private set; }

        public Interval2D(Interval1D x, Interval1D y)
        {
            this.X = x;
            this.Y = y;
        }


    }
}
