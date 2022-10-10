using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// For default class initialise with random first name, last name, mark
    /// Use: new Contender(false); if you need init class without frist, last names and mark
    /// </summary>
    internal class Contender : IContenderForPrincess
    {
        private string fristName = null;
        private string lastName = null;
        private int mark = -1; 

        private void InitContender()
        {
            fristName = Randomizer.GetRandomFristName();
            lastName = Randomizer.GetRandomLastName();
            mark = Randomizer.GetRandomMark();
        }

        //Default: init Conteder with random fields
        public Contender()
        {
            InitContender();
        }

        /// <summary>
        /// Initialization Contender random frist name and last name? 
        /// </summary>
        /// <param name="check_init"> true - yes; false - no (init with null) </param>
        public Contender(bool check_init)
        {
            if (check_init == true)
            {
                InitContender();
            }
            else
            {
                fristName = null;
                lastName = null;
                mark = -1;
            }
        }

        public string GetFristName()
        {
            return fristName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public int GetMark()
        {
            return mark;
        }
    }
}
