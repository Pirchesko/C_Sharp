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
        private readonly Hall _hall;
        
        public Friend(Hall hall)
        {
            _hall = hall;
        }

        /// <summary>
        /// First contender is better than second contender?
        /// </summary>
        public CompareType CompareContenders(IContenderForPrincess contender1, IContenderForPrincess contender2) 
        {
            if ((contender1 is Contender) && (contender2 is Contender))
            {
                var cont1 = (Contender)contender1;
                var cont2 = (Contender)contender2;

                //Friend should be that Princess ask her about contenders, who was with Princess
                if ((_hall.CheckContederInHall(cont1) == true) || (_hall.CheckContederInHall(cont2) == true))
                {
                    return CompareType.dont_know;
                }

                //Who better?
                return cont1.GetMark() > cont2.GetMark() ? CompareType.better : CompareType.worse;
            }

            return CompareType.dont_know;
        }
    }
}
