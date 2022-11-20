using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal interface IHall
    {
        //Get result in mark of happy to Princess (old mark)
        public int GetOldHappyMark(IContenderForPrincess contender);

        //Get result in mark of happy to Princess (new mark)
        public int GetNewHappyMark(IContenderForPrincess contender);

        //Getting conteder from hall
        public Contender GetNextContender();

        //Get mark with search by FristName and LastName
        public int GetMarkByName(IContenderForPrincess contender);

        //Is contender in hall at the moment?
        public bool CheckContederInHall(IContenderForPrincess contender);
    }
}
