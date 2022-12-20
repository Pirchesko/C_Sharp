using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public interface IHallForPrincess
    {
        //count contenders
        public int ContendersCount { get; }

        //Get result in mark of happy to Princess (old mark)
        public int GetHappyMark(IContenderForPrincess contender);

        //Getting conteder from hall
        public Contender GetNextContender();
    }
}
