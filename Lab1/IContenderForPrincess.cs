using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastidiousPrincess
{
    /// <summary>
    /// Interface for cooparation with Princess (without GetMark())
    /// </summary>
    public interface IContenderForPrincess
    {
        string FirstName { get; }
        string LastName { get; }
    }
}
