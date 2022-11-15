using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    /// <summary>
    /// Randomizer give random first name, last name and mark (0, INT_MAX)
    /// Include 2 files: 
    /// first_names.txt - Top 100 popular russian first name;
    /// last_names.txt - Top 500 popular russian last name;
    /// </summary>
    internal class Randomizer
    {
        private const int _FirstNameCount = 100;
        private const int _LastNameCount = 500;
        private const string _FileFirstName = "first_names.txt";
        private const string _FileLastName = "last_names.txt";
        //turn on \ turn off unique peoples (if need more than 500 people) 
        private const bool Unique = true;

        private readonly string _pathFirstName = Path.GetFullPath(_FileFirstName);
        private readonly string _pathLastName = Path.GetFullPath(_FileLastName);

        private readonly Random random = new Random();
        private string[] _listFirstName = new string[_FirstNameCount];
        private string[] _listLastName = new string[_LastNameCount];

        private List<int> _uniqueLastName = new List<int>();
        private List<int> _uniqueMark = new List<int>();

        private void InitList(string[] list, int list_size, string path)
        {
            string line = "";
            int i = 0;
            try
            {
                var sr = new StreamReader(path);
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

        public Randomizer()
        {
            InitList(_listFirstName, _FirstNameCount, _pathFirstName);
            InitList(_listLastName, _LastNameCount, _pathLastName);
        }

        public string GetRandomFirstName()
        {
            int randomFristName = random.Next(0, _FirstNameCount);
            return _listFirstName[randomFristName];
        }

        public string GetRandomWithoutRepeatLastName()
        {
            int randomLastName = random.Next(0, _LastNameCount);
            if (Unique == true)
            {
                //wait unique id of last_name
                while (_uniqueLastName.Exists(x => x.Equals(random)) == true) 
                {
                    randomLastName = random.Next(0, _LastNameCount);
                }
                _uniqueLastName.Add(randomLastName);
            }
            return _listLastName[randomLastName];
        }

        public int GetRandomWithoutRepeatMark()
        {
            int randomMark = random.Next();
            //wait unique mark
            while (_uniqueMark.Exists(x => x.Equals(random)) == true)
            {
                randomMark = random.Next();
            }
            _uniqueMark.Add(randomMark);
            return randomMark;
        }
    }
}
