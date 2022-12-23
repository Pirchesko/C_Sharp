using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastidiousPrincess
{
    public interface IContenderGenerator
    {
        /// <summary>
        /// Create list of contenders
        /// </summary>
        /// <returns>list with contenders</returns>
        public List<Contender> CreateListContender();
    }
}
