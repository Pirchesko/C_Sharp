using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Friend
    {
        private Hall hall;
        
        public Friend(Hall hall)
        {
            this.hall = hall;
        }

        /// <summary>
        /// Frist contender is better than second contender?
        /// </summary>
        public CompareType CompareContenders(IContenderForPrincess contender1, IContenderForPrincess contender2) 
        {
            var contender_1 = (Contender)contender1;
            var contender_2 = (Contender)contender2;

            //Friend should be that Princess ask her about contenders, who was with Princess
            if ((hall.CheckContederInHall(contender_1) == true) || (hall.CheckContederInHall(contender_2) == true))
            {
                return CompareType.dont_know;
            }

            //Who better?
            return contender_1.GetMark() > contender_2.GetMark() ? CompareType.better : CompareType.worse;
        }
    }
}
