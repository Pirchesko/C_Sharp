using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// For default class initialise with random first name, last name, mark
    /// Use: new Contender(false); if you need init class without first, last names and mark
    /// </summary>
    internal class Contender : IContenderForPrincess
    {
        public string FirstName { get; private set; } = null;
        public string LastName { get; private set; } = null;
        public int Mark { get; private set; } = -1;
        private Randomizer _random;

        private void InitContender()
        {
            FirstName = _random.GetRandomFirstName();
            LastName = _random.GetRandomWithoutRepeatLastName();
            Mark = _random.GetRandomWithoutRepeatMark();
        }

        //Default: init Conteder with random fields
        public Contender(Randomizer random)
        {
            _random = random;
            InitContender();
        }

        /// <summary>
        /// Initialization Contender random first name and last name? 
        /// </summary>
        /// <param name="checkInit"> true - yes; false - no (init with null) </param>
        public Contender(Randomizer random, bool checkInit)
        {
            _random = random;
            if (checkInit == true)
            {
                InitContender();
            }
            else
            {
                FirstName = null;
                LastName = null;
                Mark = -1;
            }
        }

        public override bool Equals(object obj) 
        {
            Contender contender = (Contender)obj;
            return (contender.FirstName == FirstName && contender.LastName == LastName && contender.Mark == Mark);
        }
    }
}
