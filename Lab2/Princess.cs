using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Princess : IHostedService
    {
        private readonly Friend _friend;
        private readonly IHallForPrincess _hall;
        //Princess, with the help of her Friend, create list Top contenders
        private List<IContenderForPrincess> _TopContenders = new List<IContenderForPrincess>();

        IHostApplicationLifetime _lifeTime;

        public Princess(IHallForPrincess hall, Friend friend, IHostApplicationLifetime lifeTime)
        {
            _friend = friend;
            _hall = hall;
            _lifeTime = lifeTime;
        }

        //Princess thinking about current contender and compare with contender, which was accapt with help Friend
        private PrincessMark ThinkAboutContender(IContenderForPrincess contender)
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

        private int GoToHallAndGetHappyMark(IContenderForPrincess contender)
        {
            return _hall.GetHappyMark(contender);
        }

        //Algorithm for finding the best candidate (classical skip algorithm is used 37%)
        public void FindBestContender()
        {
            IContenderForPrincess contender;

            //Classic algorithm: skip 37%
            for (int i = 0; i < 0.37 * _hall.GetContendersCount(); i++)
            {
                contender = _hall.GetNextContender();
                Console.WriteLine($"№ {i}:\t{contender.LastName} {contender.FirstName}");
                ThinkAboutContender(contender);
            }

            Console.WriteLine("------ 37% skipped! ------");

            //Choose first best contender. if all contenders are not best - then Princess will not married
            for (int i = (int)(0.37 * _hall.GetContendersCount()); i < _hall.GetContendersCount(); i++)
            {
                contender = _hall.GetNextContender();
                Console.WriteLine($"№ {i}:\t{contender.FirstName} {contender.LastName}");
                if (ThinkAboutContender(contender) == PrincessMark.Top)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine($"{GoToHallAndGetHappyMark(contender)}");
                    break;
                }
                if (i == _hall.GetContendersCount() - 1)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Принцесса никого не выбрала");
                }
            }
            Console.WriteLine();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                FindBestContender();
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
