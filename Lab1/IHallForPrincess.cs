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
        public int GetHappyMark(IContenderForPrincess contender);

        //Get contenders count in hall
        public int GetContendersCount();

        //Getting conteder from hall
        public Contender GetNextContender();
    }
}
