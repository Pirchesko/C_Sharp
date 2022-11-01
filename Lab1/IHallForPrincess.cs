using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal interface IHallForPrincess
    {
        //Get result in mark of happy to Princess
        public int GetHappyMark(IContenderForPrincess contender);
    }
}
