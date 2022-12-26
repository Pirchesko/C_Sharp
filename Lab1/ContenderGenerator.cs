using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastidiousPrincess
{
    /// <summary>
    /// Generate random ContendersCount contenders
    /// </summary>
    public class ContenderGenerator : IContenderGenerator
    {
        /// <summary>
        /// Create list of contenders
        /// </summary>
        /// <returns>list with contenders</returns>
        public List<Contender> CreateListContender()
        {
            var contenders = new List<Contender>();
            for (int i = 0; i < Constants.ContendersCount; i++)
            {
                string firstName = Randomizer.GetRandomFirstName();
                string lastName = Randomizer.GetRandomWithoutRepeatLastName();
                int mark = Randomizer.GetRandomWithoutRepeatMark();
                contenders.Add(new Contender(firstName, lastName, mark));
            }
            return contenders;
        }
    }
}
