using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Hall в котором стоят претенденты Contender
    /// </summary>
    internal class Hall
    {
        private const int contenders_count = 100; //количество претендентов
        private List<Contender> hall = new List<Contender>(); //холл в котором толпятся претенденты
        private List<Contender> hall_sort = new List<Contender>(); //отсортированный холл, для подсчёта уровня счастья принцессы

        public Hall()
        {
            for(int i = 0; i < contenders_count; i++)
            {
                hall.Add(new Contender());
            }

            var sorted = from c in hall orderby c.GetMark() select c;
            hall_sort.AddRange(sorted);
        }

        //Выдача человека из Холла
        public Contender GetNextContender()
        {
            Contender contender = hall[0];
            hall.RemoveAt(0);
            return contender;
        }

        //Есть ли данный претендент в Холле?
        public bool CheckContederInHall(Contender contender)
        {
            foreach(Contender contender_ in hall)
            {
                if ((contender_.GetFristName() == contender.GetFristName()) && (contender_.GetLastName() == contender.GetLastName()) && (contender_.GetMark() == contender.GetMark()))
                {
                    return true;
                }
            }
            return false;
        }

        //Выдаём конечный результат в единицах счастья
        public int GetHappyMark(IContenderForPrincess contender)
        {
            ContenderComparer cc = new ContenderComparer();
            int index = hall_sort.BinarySearch((Contender)contender, cc) + 1; //Сортировка произошла от наименьшего к 
            return index;
        }
    }
}
