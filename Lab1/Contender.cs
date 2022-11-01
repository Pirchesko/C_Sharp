using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// For default class initialise with random first name, last name, mark
    /// Use: new Contender(false); if you need init class without first, last names and mark
    /// </summary>
    internal class Contender : IContenderForPrincess
    {
        private string _firstName = null;
        private string _lastName = null;
        private int _mark = -1; 

        private void InitContender()
        {
            _firstName = Randomizer.GetRandomFirstName();
            _lastName = Randomizer.GetRandomWithoutRepeatLastName();
            _mark = Randomizer.GetRandomWithoutRepeatMark();
        }

        //Default: init Conteder with random fields
        public Contender()
        {
            InitContender();
        }

        /// <summary>
        /// Initialization Contender random first name and last name? 
        /// </summary>
        /// <param name="checkInit"> true - yes; false - no (init with null) </param>
        public Contender(bool checkInit)
        {
            if (checkInit == true)
            {
                InitContender();
            }
            else
            {
                _firstName = null;
                _lastName = null;
                _mark = -1;
            }
        }

        public override bool Equals(object obj) 
        {
            Contender contender = (Contender)obj;
            return (contender._firstName == _firstName && contender._lastName == _lastName && contender._mark == _mark);
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public int GetMark()
        {
            return _mark;
        }
    }
}
