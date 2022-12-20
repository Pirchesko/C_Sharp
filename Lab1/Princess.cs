using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Princess : IHostedService
    {
        private readonly Friend _friend;
        private readonly IHallForPrincess _hall;
        //Princess, with the help of her Friend, create list top contenders
        private List<IContenderForPrincess> _topContenders = new List<IContenderForPrincess>();

        IHostApplicationLifetime _lifeTime;

        public Princess(IHallForPrincess hall, Friend friend, IHostApplicationLifetime lifeTime)
        {
            _friend = friend;
            _hall = hall;
            _lifeTime = lifeTime;
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
                    if (_friend.CompareContenders(contender, _topContenders[i]) == CompareType.Better)
                    {
                        _topContenders.Insert(i, contender);
                        //If first is top - then contender which need Princess
                        if (i == 0) 
                        {
                            return PrincessMark.Top;
                        }
                        return PrincessMark.NotTop;
                    }
                    i++;
                }
                _topContenders.Insert(i, contender);
                return PrincessMark.NotTop;
            }
            //If Princess has first accept? Then accaept default
            _topContenders.Add(contender);
            return PrincessMark.NotTop;
        }

        //Get happy mark
        public int GoToHallAndGetHappyMark(IContenderForPrincess contender)
        {
            if (contender == null)
            {
                int happyMarkWhenPrincessNotChooseAnyone = 10;
                return happyMarkWhenPrincessNotChooseAnyone;
            }
            else
            {
                return _hall.GetHappyMark(contender);
            }
        }

        //Algorithm for finding the best candidate (classical skip algorithm is used 37%)
        public IContenderForPrincess FindBestContender()
        {
            IContenderForPrincess contender;

            //Classic algorithm: skip 37%
            for (int i = 0; i < 0.37 * _hall.ContendersCount; i++)
            {
                contender = _hall.GetNextContender();
                Console.WriteLine($"№ {i}:\t{contender.LastName} {contender.FirstName}");
                ThinkAboutContender(contender);
            }

            Console.WriteLine("------ 37% skipped! ------");

            //Choose first best contender. if all contenders are not best - then Princess will not married
            for (int i = (int)(0.37 * _hall.ContendersCount); i < _hall.ContendersCount; i++)
            {
                contender = _hall.GetNextContender();
                Console.WriteLine($"№ {i}:\t{contender.FirstName} {contender.LastName}");
                if (ThinkAboutContender(contender) == PrincessMark.Top)
                {
                    return contender;
                }
                if (i == _hall.ContendersCount - 1)
                {
                    return null;
                }
            }
            return null;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                IContenderForPrincess bestContender;
                bestContender = FindBestContender();
                int happyMark = GoToHallAndGetHappyMark(bestContender);
                Console.WriteLine("---------------------------");
                
                switch (happyMark)
                {
                    case 0:
                        Console.WriteLine("Принцесса вышла замуж за неудачника");
                        break;
                    case 10:
                        Console.WriteLine("Принцесса никого не выбрала");
                        break;
                    default:
                        Console.WriteLine($"{happyMark}");
                        break;
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _lifeTime.StopApplication();
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
