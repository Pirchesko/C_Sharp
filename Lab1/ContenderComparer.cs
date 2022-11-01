using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    //Class for Sort() and BynarySearch()
    internal class ContenderComparer : IComparer<Contender>
    {
        public int Compare(Contender contender1, Contender contender2)
        {
            if (contender1.Mark > contender2.Mark)
            {
                return 1;
            }
            else if (contender1.Mark < contender2.Mark)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
