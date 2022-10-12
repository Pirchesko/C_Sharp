using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Randomizer give random first name, last name and mark (0, INT_MAX)
    /// Include 2 files: 
    /// first_names.txt - top 100 popular russian first name;
    /// last_names.txt - top 500 popular russian last name;
    /// </summary>
    internal static class Randomizer
    {
        private const int _countFirstName = 100;
        private const int _countLastName = 500;
        private const string _fileFirstName = "first_names.txt";
        private const string _fileLastName = "last_names.txt";
        //turn on \ turn off unique peoples (if need more than 500 people) 
        private const bool unique = true;

        private static readonly string _pathFirstName = Path.GetFullPath(_fileFirstName);
        private static readonly string _pathLastName = Path.GetFullPath(_fileLastName);

        private static readonly Random rnd = new Random();
        private static string[] _listFirstName = new string[_countFirstName];
        private static string[] _listLastName = new string[_countLastName];

        private static List<int> _uniqueLastName = new List<int>();
        private static List<int> _uniqueMark = new List<int>();

        private static void InitList(string[] list, int list_size, string path)
        {
            string line = "";
            int i = 0;
            try
            {
                StreamReader sr = new StreamReader(path);
                while ((line = sr.ReadLine()) != null)
                {
                    list[i] = line;
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in Randomizer: " + e.Message);
            }
        }

        static Randomizer()
        {
            InitList(_listFirstName, _countFirstName, _pathFirstName);
            InitList(_listLastName, _countLastName, _pathLastName);
        }

        public static string GetRandomFirstName()
        {
            int random = rnd.Next(0, _countFirstName);
            return _listFirstName[random];
        }

        public static string GetRandomWithoutRepeatLastName()
        {
            int random = rnd.Next(0, _countLastName);
            if (unique == true)
            {
                //wait unique id of last_name
                while (_uniqueLastName.Exists(x => x.Equals(random)) == true) 
                {
                    random = rnd.Next(0, _countLastName);
                }
                _uniqueLastName.Add(random);
            }
            return _listLastName[random];
        }

        public static int GetRandomWithoutRepeatMark()
        {
            int random = rnd.Next();
            //wait unique mark
            while (_uniqueMark.Exists(x => x.Equals(random)) == true)
            {
                random = rnd.Next();
            }
            _uniqueMark.Add(random);
            return random;
        }
    }
}
