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
        private const int countContenders = 100;
        //hall which wait contenders
        private List<Contender> hall = new List<Contender>();
        //sorted hall, for get level of happy Princess
        private List<Contender> hallSort = new List<Contender>(); 

        public Hall()
        {
            for(int i = 0; i < countContenders; i++)
            {
                hall.Add(new Contender());
            }

            hallSort.AddRange(from c in hall orderby c.GetMark() select c);
        }

        //Getting conteder from hall
        public Contender GetNextContender()
        {
            if (hall.Count > 0)
            {
                Contender contender = hall[0];
                hall.RemoveAt(0);
                return contender;
            }
            else
            {
                return new Contender(false);
            }
        }

        //Is contender in hall at the moment?
        public bool CheckContederInHall(Contender contender)
        {
            return hall.Exists(x => x.Equals(contender)) ? true : false;
        }

        //Get result in mark of happy to Princess
        public int GetHappyMark(IContenderForPrincess contender)
        {
            ContenderComparer cc = new ContenderComparer();
            //Sort from min to max + 1
            int index = hallSort.BinarySearch((Contender)contender, cc) + 1; 
            if (index <= 50) index = 0;
            return index;
        }
    }
}
