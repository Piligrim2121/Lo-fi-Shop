//using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;

namespace Lo_Fi_Shop.Class
{
    class PersonClass
    {
        private int _Money;
        private int _Exp;
        private List<string> _Inventory;
        private List<int> _Settings;
        private PersonClass(int Money, int Exp, List<string> Inventory, List<int> Settings)
        {
            _Money = Money;
            _Exp = Exp;
            _Inventory = Inventory; // без ограничений
            _Settings = Settings; // list с 3 значениями от 1 до 10
        }

        // код чтения из файл
        public static string Read_TXT()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = (string)Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f)).FirstOrDefault();
            string text = File.ReadAllText(Path.Combine(folderPath, path));
            return text;
        }
        public static void Write_TXT(int Money, int Exp, List<string> Inventory, List<int> Settings)
        {
            // код сохранения в файл
        }
        // код сохранения и вывода данных в конструктор
        public static void OverwriteData()
        {
            string Data = Read_TXT();
            int Money = Convert.ToInt32(Data.Split(';')[0].Split(':')[1]);
            int Exp = Convert.ToInt32(Data.Split(';')[1].Split(':')[1]);
            List<string> Inv = new List<string> {  };
            foreach (string i in Data.Split(';')[2].Split(':')[1].Split(','))
            {
                Inv.Add(i);
            }
            List<int> Settings = new List<int> { };
            foreach(string i in Data.Split(';')[2].Split(':')[1].Split(','))
            {
                Settings.Add(Convert.ToInt32(i));
            }
            PersonClass Player = new PersonClass(Money, Exp, Inv, Settings);
        }
    }
}
