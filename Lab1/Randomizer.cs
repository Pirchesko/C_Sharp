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
    /// frist_names.txt - top 100 popular russian first name;
    /// last_names.txt - top 500 popular russian last name;
    /// </summary>
    internal static class Randomizer
    {
        private const string pathFristName = "D:\\Files\\Visual Studio\\C#\\Lab1\\frist_names.txt";
        private const string pathLastName = "D:\\Files\\Visual Studio\\C#\\Lab1\\last_names.txt";
        private const int countFristName = 100;
        private const int countLastName = 500;
        //turn on \ turn off unique peoples (if need more than 500 people) 
        private const bool unique = true; 

        private static Random rnd = new Random();
        private static string[] listFristName = new string[countFristName];
        private static string[] listLastName = new string[countLastName];

        private static List<int> uniqueLastName = new List<int>();
        private static List<int> uniqueMark = new List<int>();

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
            InitList(listFristName, countFristName, pathFristName);
            InitList(listLastName, countLastName, pathLastName);
        }

        public static string GetRandomFristName()
        {
            int random = rnd.Next(0, countFristName);
            return listFristName[random];
        }

        public static string GetRandomLastName()
        {
            int random = rnd.Next(0, countLastName);
            if (unique == true)
            {
                //wait unique id of last_name
                while (uniqueLastName.Exists(x => x.Equals(random)) == true) 
                {
                    random = rnd.Next(0, countLastName);
                }
                uniqueLastName.Add(random);
            }
            return listLastName[random];
        }

        public static int GetRandomMark()
        {
            int random = rnd.Next();
            //wait unique mark
            while (uniqueMark.Exists(x => x.Equals(random)) == true)
            {
                random = rnd.Next();
            }
            uniqueMark.Add(random);
            return random;
        }
    }
}
