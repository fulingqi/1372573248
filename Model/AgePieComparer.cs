using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class AgePieComparer : IEqualityComparer<AgePie>
    {
        public bool Equals(AgePie x, AgePie y)
        {
            return x.AgeDuan == y.AgeDuan
              && x.Sex == y.Sex
              && x.ShuLiang == y.ShuLiang;
        }

        public int GetHashCode(AgePie obj)
        {
            return 1;
        }
    }
}
