using System;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Princess princess = new Princess(); 
            Friend friend = new Friend();
            Hall hall = new Hall();

            IContenderForPrincess contender;
            int i;

            //По классике пропускаем 37%
            for (i = 0; i < 37; i++)
            {
                contender = hall.GetNextContender();
                Console.WriteLine($"{contender.GetFristName()} {contender.GetLastName()} {((Contender)contender).GetMark()}");
                princess.ThinkAboutContender(hall, friend, contender);
            }

            //Затем выбираем первого лучшего. Если такового нет - ничего не делаем и остаёмся без принца
            for (; i < 100; i++)
            {
                contender = hall.GetNextContender();
                Console.WriteLine($"{contender.GetFristName()} {contender.GetLastName()} {((Contender)contender).GetMark()}");
                if (princess.ThinkAboutContender(hall, friend, contender) == PrincessMark.top)
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine($"{hall.GetHappyMark(contender)}");
                    break;
                }
                 
            }

            if (i == 100)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("Принцесса никого не выбрала");
            }
        }
    }
}