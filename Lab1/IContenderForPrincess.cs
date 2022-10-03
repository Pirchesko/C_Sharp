using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    //Интерфейс для взаимодействия Принцессой (без GetMark())
    internal interface IContenderForPrincess
    {
        public string GetFristName();
        public string GetLastName();
    }
}
