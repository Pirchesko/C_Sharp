using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal interface IHallForPrincess
    {
        //Get result in mark of happy to Princess
        public int GetHappyMark(IContenderForPrincess contender);

        public int GetContendersCount();

        //Getting conteder from hall
        public Contender GetNextContender();
    }
}
