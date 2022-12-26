using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastidiousPrincess
{
    public interface IHall
    {
        /// <summary>
        /// Get mark with search by FristName and LastName
        /// </summary>
        /// <param name="contender"></param>
        /// <returns>mark contender</returns>
        public int GetMarkByName(IContenderForPrincess contender);

        /// <summary>
        /// Is contender in hall at the moment?
        /// </summary>
        /// <param name="contender"></param>
        /// <returns>true if contender in hall at the moment</returns>
        public bool CheckContederInHall(IContenderForPrincess contender);

        /// <summary>
        /// Getting conteder from hall
        /// </summary>
        /// <returns>next contender from hall</returns>
        /// <exception cref="Exception"></exception>
        public Contender GetNextContender();
    }
}
