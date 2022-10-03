using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    /// <summary>
    /// Randomizer отвечает за выдачу рандомного имени, фамилии, общей оценки текущего претендента
    /// Подготовлено 2 файла: 
    /// frist_names.txt - топ 100 популярных русских имён;
    /// last_names.txt - топ 500 популярных русских фамилий;
    /// </summary>
    internal static class Randomizer
    {
        private const string first_name_path = "D:\\Files\\Visual Studio\\C#\\Lab1\\frist_names.txt";
        private const string last_name_path = "D:\\Files\\Visual Studio\\C#\\Lab1\\last_names.txt";
        private const int first_name_count = 100;
        private const int last_name_count = 500;

        private static Random rnd = new Random();
        private static string[] first_name_list = new string[first_name_count];
        private static string[] last_name_list = new string[last_name_count];

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
            InitList(first_name_list, first_name_count, first_name_path);
            InitList(last_name_list, last_name_count, last_name_path);
        }

        public static string GetRandomFristName()
        {
            return first_name_list[rnd.Next(0, first_name_count)];
        }

        public static string GetRandomLastName()
        {
            return last_name_list[rnd.Next(0, last_name_count)];
        }

        public static int GetRandomMark()
        {
            return rnd.Next();
        }
    }
}
