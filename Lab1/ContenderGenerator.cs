using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    /// <summary>
    /// Only create ContendersCount contenders
    /// </summary>
    public class ContenderGenerator : IContenderGenerator
    {
        //count contenders
        private const int _ContendersCount = 100;

        //create list of contenders
        public List<Contender> CreateListContender()
        {
            var contenders = new List<Contender>();
            for (int i = 0; i < _ContendersCount; i++)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = Randomizer.GetRandomWithoutRepeatMark();
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }

        //return contendersCount
        public int ContendersCount()
        {
            return _ContendersCount;
        }
    }
}
