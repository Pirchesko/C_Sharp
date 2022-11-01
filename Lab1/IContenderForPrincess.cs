using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    //Interface for cooparation with Princess (without GetMark())
    internal interface IContenderForPrincess
    {
        public string GetFirstName();
        public string GetLastName();
    }
}
