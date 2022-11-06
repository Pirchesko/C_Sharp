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
        private readonly IHallForPrincess _hall;
        //Princess, with the help of her Friend, create list Top contenders
        private List<IContenderForPrincess> _TopContenders = new List<IContenderForPrincess>(); 

        public Princess(IHallForPrincess hall, Friend friend)
        {
            _friend = friend;
            _hall = hall;
        }

        //Princess thinking about current contender and compare with contender, which was accapt with help Friend
        public PrincessMark ThinkAboutContender(IContenderForPrincess contender)
        {
            int i = 0;
            if (_TopContenders.Count != 0) 
            {
                //Compare with all who was accept for create Top list Princess
                while (i < _TopContenders.Count) 
                {
                    if (_friend.CompareContenders(contender, _TopContenders[i]) == CompareType.Better)
                    {
                        _TopContenders.Insert(i, contender);
                        //If first is Top - then contender which need Princess
                        if (i == 0) 
                        {
                            return PrincessMark.Top;
                        }
                        return PrincessMark.NotTop;
                    }
                    i++;
                }
                _TopContenders.Insert(i, contender);
                return PrincessMark.NotTop;
            }
            //If Princess has first accept? Then accaept default
            _TopContenders.Add(contender);
            return PrincessMark.NotTop;
        }

        public int GoToHallAndGetHappyMark(IContenderForPrincess contender)
        {
            return _hall.GetHappyMark(contender);
        }
    }
}
