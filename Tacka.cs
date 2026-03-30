using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon___Properties
{
    internal class Tacka
    {
        public float x, y;

        public Tacka()
        {
            x = 0;
            y = 0;
        }

        public Tacka(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public double d()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public static bool jednaka(Tacka A, Tacka B)
        {
            return (A.x == B.x) & (A.y == B.y);
        }
    }
}
