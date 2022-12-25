using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastidiousPrincess
{
    public interface IHallForPrincess
    {
        /// <summary>
        /// Get mark with search by FristName and LastName
        /// </summary>
        /// <param name="contender"></param>
        /// <returns>mark contender</returns>
        /// <exception cref="Exception"></exception>
        public int GetHappyMark(IContenderForPrincess contender);

        /// <summary>
        /// Getting conteder from hall
        /// </summary>
        /// <returns>next contender from hall</returns>
        /// <exception cref="Exception"></exception>
        public Contender GetNextContender();

        /// <summary>
        /// Create list contender for hall
        /// </summary>
        public void InitHall();
    }
}
