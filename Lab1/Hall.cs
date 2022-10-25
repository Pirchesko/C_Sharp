using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Hall which live Contenders
    /// </summary>
    internal class Hall
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

            _hallSort.AddRange(from c in _hall orderby c.GetMark() select c);
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
                return new Contender(false);
            }
        }

        public int GetContendersCount()
        {
            return _ContendersCount;
        }

        //Is contender in hall at the moment?
        public bool CheckContederInHall(Contender contender)
        {
            return _hall.Exists(x => x.Equals(contender));
        }

        //Get result in mark of happy to Princess
        public int GetHappyMark(IContenderForPrincess contender)
        {
            var cc = new ContenderComparer();
            //Sort from min to max + 1
            int index = _hallSort.BinarySearch((Contender)contender, cc) + 1; 
            if (index <= 50) index = 0;
            return index;
        }
    }
}
