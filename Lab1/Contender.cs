using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    /// <summary>
    /// For default class initialise with random first name, last name, mark
    /// Use: new Contender(false); if you need init class without first, last names and mark
    /// </summary>
    public class Contender : IContenderForPrincess
    {
        public string FirstName { get; private set; } = null;
        public string LastName { get; private set; } = null;
        public int Mark { get; private set; } = -1;

        public Contender(string firstName, string lastName, int mark)
        {
            FirstName = firstName;
            LastName = lastName;
            Mark = mark;
        }

        public override bool Equals(object obj)
        {
            Contender contender = (Contender)obj;
            return (contender.FirstName == FirstName && contender.LastName == LastName && contender.Mark == Mark);
        }
    }
}
