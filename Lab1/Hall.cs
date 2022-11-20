using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    /// <summary>
    /// Hall which live Contenders
    /// </summary>
    internal class Hall : IHallForPrincess
    {
        //count contenders
        private const int _ContendersCount = 100;
        //hall which wait contenders
        private List<Contender> _hall = new List<Contender>();
        //sorted hall, for get level of happy Princess
        private List<Contender> _hallSort = new List<Contender>(); 

        public Hall()
        {
            for(int i = 0; i < _ContendersCount; i++)
            {
                _hall.Add(new Contender());
            }

            _hallSort.AddRange(from c in _hall orderby c.Mark select c);
        }

        //Getting conteder from hall
        public Contender GetNextContender()
        {
            if (_hall.Count > 0)
            {
                Contender contender = _hall[0];
                _hall.RemoveAt(0);
                return contender;
            }
            else
            {
                throw new Exception("В коридоре больше нету претендентов!");
            }
        }

        public int GetContendersCount()
        {
            return _ContendersCount;
        }

        //Is contender in hall at the moment?
        public bool CheckContederInHall(IContenderForPrincess contender)
        {
            return _hall.Exists(x => x.Equals(contender));
        }

        //Get mark with search by FristName and LastName
        public int GetMarkByName(IContenderForPrincess contender)
        {
            foreach (var cont in _hallSort)
            {
                if ((cont.FirstName == contender.FirstName) && (cont.LastName == contender.LastName))
                {
                    return cont.Mark;
                }
            }
            throw new Exception("Такого претендента не существовало");
        }

        //Get result in mark of happy to Princess (old mark)
        public int GetOldHappyMark(IContenderForPrincess contender)
        {
            var cc = new ContenderComparer();
            //Sort from min to max + 1
            int index = _hallSort.BinarySearch((Contender)contender, cc) + 1; 
            if (index <= 50) index = 0;
            return index;
        }

        //Get result in mark of happy to Princess (new mark)
        public int GetNewHappyMark(IContenderForPrincess contender)
        {
            int mark = GetOldHappyMark(contender);
            switch (mark)
            {
                case 100: return 20;
                case 98: return 50;
                case 96: return 100;
                default: return 0;
            }
        }
    }
}
