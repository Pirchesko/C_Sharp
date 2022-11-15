using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Friend
    {
        private readonly IHallForPrincess _hall;

        public Friend(IHallForPrincess hall)
        {
            _hall = hall;
        }

        /// <summary>
        /// First contender is Better than second contender?
        /// </summary>
        public CompareType CompareContenders(IContenderForPrincess contender1, IContenderForPrincess contender2) 
        {
            //Friend should be that Princess ask her about contenders, who was with Princess
            if ((((Hall)_hall).CheckContederInHall(contender1) == true) || (((Hall)_hall).CheckContederInHall(contender1) == true))
            {
                throw new Exception("Подруга не может сравнивать претендентов, которые ещё не были у принцессы.");
            }

            return (((Hall)_hall).GetMarkByName(contender1) > ((Hall)_hall).GetMarkByName(contender2)) ? CompareType.Better : CompareType.Worse;
        }
    }
}
