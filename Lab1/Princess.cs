using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Оценка принцессы: top - лучший, что попал к ней сразу; иначе - not_top
    /// </summary>
    enum PrincessMark
    {
        top,
        not_top
    }

    internal class Princess
    {
        private List<IContenderForPrincess> top_contenders = new List<IContenderForPrincess>(); //Принцесса на основе подруги, составляет свой список самых лучших претендентов
        //private IContenderForPrincess contender = new Contender(false); //Интерфейс претендента, не позволяющий вызвать метод GetMark()

        //Принцесса размышляет о текущим претенденте и сравнивает его с теми кто у неё был с помощью подруги
        public PrincessMark ThinkAboutContender(Hall hall, Friend friend, IContenderForPrincess contender)
        {
            int i = 0;
            if (top_contenders.Count != 0) 
            {
                while (i < top_contenders.Count) //Сравниваем со всеми кто был, чтобы определить иерархию у принцессы
                {
                    if (friend.CompareContenders(hall, contender, top_contenders[i]) == CompareType.better)
                    {
                        top_contenders.Insert(i, contender);
                        if (i == 0) //Если с первого раза и сразу лучший - значит это тот, кто ей нужен (по тактике 37%)
                        {
                            return PrincessMark.top;
                        }
                        return PrincessMark.not_top;
                    }
                    i++;
                }
                top_contenders.Insert(i, contender);
                return PrincessMark.not_top;
            }
            else //Если никого не было у принцессы, добавляем по умолчанию
            {
                top_contenders.Add(contender);
                return PrincessMark.not_top;
            }
        }
    }
}
