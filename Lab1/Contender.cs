using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// По дефолту класс инициализируется с рандомными именами, фамилиями, оценкой
    /// Чтобы класс инициализировавлся без имен, фамилий и оценок используйте: new Contender(false)
    /// </summary>
    internal class Contender : IContenderForPrincess
    {
        private string frist_name = null; //Фамилия
        private string last_name = null; //Имя
        private int mark = -1; //Оценка (0 <= mark <= inf)

        private void InitContender()
        {
            frist_name = Randomizer.GetRandomFristName();
            last_name = Randomizer.GetRandomLastName();
            mark = Randomizer.GetRandomMark();
        }

        //По дефолту инициализация Conteder с рандомными именами и фамилиями
        public Contender()
        {
            InitContender();
            //Console.WriteLine($"{frist_name} {last_name}");
        }

        //Инициализировать Contender рандомными именами и фамилиями? true - да; false - нет
        public Contender(bool check_init)
        {
            if (check_init == true)
            {
                InitContender();
            }
            else
            {
                frist_name = null;
                last_name = null;
                mark = -1;
            }
        }

        public string GetFristName()
        {
            return frist_name;
        }

        public string GetLastName()
        {
            return last_name;
        }

        public int GetMark()
        {
            return mark;
        }
    }

    //Класс для Sort() BynarySearch()
    internal class ContenderComparer : IComparer<Contender>
    {
        public int Compare(Contender contender1, Contender contender2)
        {
            if (contender1.GetMark() > contender2.GetMark())
            {
                return 1;
            }
            else if (contender1.GetMark() < contender2.GetMark())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
