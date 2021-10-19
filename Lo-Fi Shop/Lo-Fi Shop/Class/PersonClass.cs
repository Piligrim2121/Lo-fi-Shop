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
        public int Money;
        public int Exp;
        public List<string> InventoryPath;
        public List<string> InventoryWhole;
        public List<int> Settings;
        private PersonClass(int Money, int Exp, List<string> InventoryPath, List<string> InventoryWhole, List<int> Settings)
        {
            this.Money = Money;
            this.Exp = Exp;
            this.InventoryPath = InventoryPath; // без ограничений
            this.InventoryWhole = InventoryWhole; // без ограничений
            this.Settings = Settings; // list с 3 значениями от 1 до 10
        }

        /// <summary>
        /// Чтение данных из файла 
        /// </summary>
        /// <returns></returns>
        public static string Read_TXT()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = (string)Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f)).FirstOrDefault();
            string text = File.ReadAllText(Path.Combine(folderPath, path));
            return text;
        }
        /// <summary>
        /// Сохранения данных в файл
        /// </summary>
        /// <param name="Money">Количество денег для сохранения </param>
        /// <param name="Exp">Количество опыта для сохранения</param>
        /// <param name="Inventory">Список предметов содержащихся в инвентаре</param>
        /// <param name="Settings">Внутри игровые настройки</param>
        public static void Write_TXT(int Money, int Exp, List<string> InventoryParts, List<string> InventoryWhole, List<int> Settings)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "data";
            string SubInv = "";
            foreach(string i in InventoryParts)
            {
                SubInv += (i+",");
            }
            string SubInv2 = "";
            foreach (string i in InventoryWhole)
            {
                SubInv2 += (i + ",");
            }
            string SubSett = "";
            foreach (int i in Settings)
            {
                SubSett += (i.ToString() + ",");
            }
            string text = "Money:" + Money.ToString() + ";Exp:" + Exp.ToString() + ";InventoryParts:" + SubInv + ";InventoryWhole:" + SubInv2 + ";Settings:" + SubSett + ";";
            File.WriteAllText(Path.Combine(folderPath, filename), text);
            OverwriteData();
        }
        /// <summary>
        /// Сохранения данных в файл
        /// </summary>
        /// <param name="Money">Количество денег для сохранения</param>
        public static void Write_TXT(int Money)
        {


            string Data = Read_TXT();
            string[] words = Data.Split(new char[] { ';' });

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "data";
            Console.WriteLine("testtt"+Data);
            string text = "Money:" + Money.ToString() + ";"+words[1]+";"+words[2] + ";" + words[3] + ";" + words[4] + ";";
            File.WriteAllText(Path.Combine(folderPath, filename), text);
           // OverwriteData();
        }

        /// <summary>
        ///  Перезапись файла новыми данными
        /// </summary>
        /// <returns></returns>
        public static PersonClass OverwriteData()
        {
            string Data = Read_TXT();
            int Money = Convert.ToInt32(Data.Split(';')[0].Split(':')[1]);
            int Exp = Convert.ToInt32(Data.Split(';')[1].Split(':')[1]);
            List<string> Inv = new List<string> {  };
            foreach (string i in Data.Split(';')[2].Split(':')[1].Split(','))
            {
                Inv.Add(i);
            }
            List<string> Inv2 = new List<string> { };
            foreach (string i in Data.Split(';')[3].Split(':')[1].Split(','))
            {
                Inv2.Add(i);
            }
            List<int> Settings = new List<int> { };
            foreach(string i in Data.Split(';')[4].Split(':')[1].Split(','))
            {
                Settings.Add(Convert.ToInt32(i));
            }
            PersonClass Player = new PersonClass(Money, Exp, Inv, Inv2, Settings);
            return Player;
        }
        /// <summary>
        /// Создание начальных данных при первом запуске игры
        /// </summary>
        public static void First_Write_TXT()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "data";
            if (!File.Exists(Path.Combine(folderPath, filename)))
            {
                string text = "Money:200000;Exp:0;InventoryParts:0;InventoryWhole:0;Settings:10,10,10;";
                File.WriteAllText(Path.Combine(folderPath, filename), text);
                OverwriteData();
            }
        }

    }
}
