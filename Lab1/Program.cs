using System;
using System.IO;
using System.Reflection;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hall = new Hall();
            var friend = new Friend(hall);
            var princess = new Princess(hall, friend);

            IContenderForPrincess contender;

            //Classic algorithm: skip 37%
            int skip37 = 37;
            for (int i = 0; i < skip37; i++)
            {
                contender = hall.GetNextContender();
                Console.WriteLine($"{contender.GetFirstName()} {contender.GetLastName()}");
                princess.ThinkAboutContender(contender);
            }

            Console.WriteLine("------ 37% skipped! ------");

            //Choose first best contender. if all contenders are not best - then Princess will not married
            for (int i = skip37; i < 100; i++)
            {
                contender = hall.GetNextContender();
                Console.WriteLine($"{contender.GetFirstName()} {contender.GetLastName()}");
                if (princess.ThinkAboutContender(contender) == PrincessMark.top)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine($"{princess.GoToHallAndGetHappyMark(contender)}");
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