using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public interface IContenderGenerator
    {
        //create list of contenders
        public List<Contender> CreateListContender();

        //return contendersCount
        public int ContendersCount();
    }
}
