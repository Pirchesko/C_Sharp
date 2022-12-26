using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastidiousPrincess
{
    /// <summary>
    /// Class create for Sort() and BynarySearch()
    /// </summary>
    public class ContenderComparer : IComparer<Contender>
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
