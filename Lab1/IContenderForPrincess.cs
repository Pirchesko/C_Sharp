using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    //Interface for cooparation with Princess (without GetMark())
    internal interface IContenderForPrincess
    {
        string FirstName { get; }
        string LastName { get; }
    }
}
