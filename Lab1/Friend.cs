using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FastidiousPrincess
{
    public class Friend
    {
        private readonly IHall _hall;
        
        public Friend(IHall hall)
        {
            _hall = hall;
        }

        /// <summary>
        /// First contender is better than second contender?
        /// </summary>
        public CompareType CompareContenders(IContenderForPrincess contender1, IContenderForPrincess contender2) 
        {
            //Friend should be that Princess ask her about contenders, who was with Princess
            if ((_hall.CheckContederInHall(contender1) == true) || (_hall.CheckContederInHall(contender1) == true))
            {
                throw new Exception("Подруга не может сравнивать претендентов, которые ещё не были у принцессы.");
            }

            return (_hall.GetMarkByName(contender1) > _hall.GetMarkByName(contender2)) ? CompareType.Better : CompareType.Worse;
        }
    }
}
