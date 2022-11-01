using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Princess
    {
        private readonly Friend _friend;
        private readonly Hall _hall;
        //Princess bay a Friend, create list top contenders
        private List<IContenderForPrincess> _topContenders = new List<IContenderForPrincess>(); 

        public Princess(Hall hall, Friend friend)
        {
            _friend = friend;
            _hall = hall;
        }

        //Princess thinking about current contender and compare with contender, which was accapt with help Friend
        public PrincessMark ThinkAboutContender(IContenderForPrincess contender)
        {
            int i = 0;
            if (_topContenders.Count != 0) 
            {
                //Compare with all who was accept for create top list Princess
                while (i < _topContenders.Count) 
                {
                    if (_friend.CompareContenders(contender, _topContenders[i]) == CompareType.better)
                    {
                        _topContenders.Insert(i, contender);
                        //If first is top - then contender which need Princess
                        if (i == 0) 
                        {
                            return PrincessMark.top;
                        }
                        return PrincessMark.notTop;
                    }
                    i++;
                }
                _topContenders.Insert(i, contender);
                return PrincessMark.notTop;
            }
            //If Princess has first accept? Then accaept default
            _topContenders.Add(contender);
            return PrincessMark.notTop;
        }

        public int GoToHallAndGetHappyMark(IContenderForPrincess contender)
        {
            return _hall.GetHappyMark(contender);
        }
    }
}
