using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public interface IHall
    {
        //Get mark with search by FristName and LastName
        public int GetMarkByName(IContenderForPrincess contender);

        //Is contender in hall at the moment?
        public bool CheckContederInHall(IContenderForPrincess contender);

        //Getting conteder from hall
        public Contender GetNextContender();
    }
}
