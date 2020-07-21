using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public class AgeFourPieComparer : IEqualityComparer<AgeFourPie>
    {
        public bool Equals(AgeFourPie x, AgeFourPie y)
        {
            return x.AgeDuan == y.AgeDuan
              && x.Sex == y.Sex
              && x.ShuLiang == y.ShuLiang
              && x.name == y.name;
        }

        public int GetHashCode(AgeFourPie obj)
        {
            return 1;
        }
    }
}
