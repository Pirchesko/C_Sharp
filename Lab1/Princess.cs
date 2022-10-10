using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Princess
    {
        private Hall hall;
        //Princess bay a Friend, create list top contenders
        private List<IContenderForPrincess> topContenders = new List<IContenderForPrincess>(); 

        public Princess(Hall hall)
        {
            this.hall = hall;
        }

        //Princess thinking about current contender and compare with contender, which was accapt with help Friend
        public PrincessMark ThinkAboutContender(Friend friend, IContenderForPrincess contender)
        {
            int i = 0;
            if (topContenders.Count != 0) 
            {
                //Compare with all who was accept for create top list Princess
                while (i < topContenders.Count) 
                {
                    if (friend.CompareContenders(contender, topContenders[i]) == CompareType.better)
                    {
                        topContenders.Insert(i, contender);
                        //If frist is top - then contender which need Princess
                        if (i == 0) 
                        {
                            return PrincessMark.top;
                        }
                        return PrincessMark.notTop;
                    }
                    i++;
                }
                topContenders.Insert(i, contender);
                return PrincessMark.notTop;
            }
            //If Princess has frist accept? Then accaept default
            topContenders.Add(contender);
            return PrincessMark.notTop;
        }
    }
}
