using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal interface IHallForPrincess
    {
        //Get result in mark of happy to Princess (old mark)
        public int GetOldHappyMark(IContenderForPrincess contender);

        //Get result in mark of happy to Princess (new mark)
        public int GetNewHappyMark(IContenderForPrincess contender);
    }
}
