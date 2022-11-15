using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    //Interface for cooparation with Princess (without GetMark())
    internal interface IContenderForPrincess
    {
        string FirstName { get; }
        string LastName { get; }
    }
}
