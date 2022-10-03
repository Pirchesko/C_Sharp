using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    //Для сравнения претендентов, принимающихся у принцессы
    enum CompareType
    {
        better,
        worse,
        dont_know
    }

    internal class Friend
    {
        /// <summary>
        /// Первый претендент круче второго претендента?
        /// </summary>
        public CompareType CompareContenders(Hall hall, IContenderForPrincess contender1, IContenderForPrincess contender2) 
        {
            Contender contender1_ = (Contender)contender1;
            Contender contender2_ = (Contender)contender2;

            //Подруга должна быть уверена, что принцесса спрашивает о тех, кто у неё не был
            if ((hall.CheckContederInHall(contender1_) != false) || (hall.CheckContederInHall(contender2_) != false))
            {
                return CompareType.dont_know;
            }

            //Кто лучше??
            if (contender1_.GetMark() > contender2_.GetMark())
            {
                return CompareType.better;
            }
            else
            {
                return CompareType.worse;
            }
        }
    }
}
