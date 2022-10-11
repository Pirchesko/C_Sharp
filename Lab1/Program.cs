using System;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hall hall = new Hall();
            Princess princess = new Princess(hall); 
            Friend friend = new Friend(hall);

            IContenderForPrincess contender;

            //Classic algorithm: skip 37%
            for (int i = 0; i < 37; i++)
            {
                contender = hall.GetNextContender();
                Console.WriteLine($"{contender.GetFristName()} {contender.GetLastName()}");
                princess.ThinkAboutContender(friend, contender);
            }

            Console.WriteLine("------ 37% skipped! ------");

            //Choose frist best contender. if all contenders are not best - then Princess will not married
            for (int i = 37; i < 100; i++)
            {
                contender = hall.GetNextContender();
                Console.WriteLine($"{contender.GetFristName()} {contender.GetLastName()}");
                if (princess.ThinkAboutContender(friend, contender) == PrincessMark.top)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine($"{hall.GetHappyMark(contender)}");
                    break;
                }
                if (i == 99)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Принцесса никого не выбрала");
                }
            }
        }
    }
}