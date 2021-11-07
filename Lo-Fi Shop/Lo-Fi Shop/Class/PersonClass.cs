//using Android.Content.Res;
using Plugin.SimpleAudioPlayer;
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
        /// <summary>
        /// Список комплектующих
        /// </summary>
        public List<string> InventoryPath;
        public static bool Playing = false;
        public static bool FirstTime = true;
        public static bool Sleep = false;
        public static ISimpleAudioPlayer player;
        
        public List<int> Settings;
        public int Lvl;
        /// <summary>
        /// Конструктор класса PersonClass
        /// </summary>
        /// <param name="Money"></param>
        /// <param name="Exp"></param>
        /// <param name="InventoryPath"></param>
        /// <param name="InventoryWhole"></param>
        /// <param name="Settings"></param>
        private PersonClass(int Money, int Exp, List<string> InventoryPath, List<int> Settings, int Lvl)
        {
            this.Money = Money;
            this.Exp = Exp;
            this.InventoryPath = InventoryPath; // без ограничений
            this.Settings = Settings; // list с 3 значениями от 1 до 10
            this.Lvl = Lvl;
            
        }

        /// <summary>
        /// Чтение данных из файла 
        /// </summary>
        /// <returns>Строка содержащиеся в файле</returns>
        public static string Read_TXT(string path)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //string path = (string)Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f)).FirstOrDefault();
            string text = File.ReadAllText(Path.Combine(folderPath, path));
            return text;
        }
        /// <summary>
        /// Запись в файл информации о созданном ПК
        /// </summary>
        /// <param name="PC">Список компонентов входящих в ПК</param>
        public static void Write_PC(List<Item> PC)
        {
            string text2="";
            string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename2 = "pcs";
            for(int i =0; i<Item.PC.Count; i++)
            {
                
                 text2 = "Name:" + Item.PC[i].Name+";"+"Cost:"+Item.PC[i].Sell+";"+"Source:"+Item.PC[i].Path+";"+"Description:"+Item.PC[i].Description+";"+"*";
            }
            File.AppendAllText(Path.Combine(folderPath2, filename2), text2);
        }

      public static Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("Lo-Fi_Shop." + filename);

            return stream;
        }
        /// <summary>
        /// Удаление ПК
        /// </summary>
        /// <param name="PC"></param>
        public static void Delet_PC(List<string> PC)
        {
            string text2 = "";
            string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename2 = "pcs";
            for (int i = 0; i < PC.Count; i++)
            {
                text2 += "Name:" + PC[i].Split(';')[0].Split(':')[1] + ";" + "Cost:" + PC[i].Split(';')[1].Split(':')[1] + ";" + "Source:" + PC[i].Split(';')[2].Split(':')[1] + ";" + "Description:" + PC[i].Split(';')[3].Split(':')[1] + ";" + "*";
            }
            File.WriteAllText(Path.Combine(folderPath2, filename2), text2);
        }
        /// <summary>
        /// Сохранения данных в файл
        /// </summary>
        /// <param name="Money">Количество денег для сохранения </param>
        /// <param name="Exp">Количество опыта для сохранения</param>
        /// <param name="InventoryParts">Список с названием компонентов</param>
        /// <param name="InventoryWhole">Список с названием готовых ПК</param>
        /// <param name="Settings">Внутри игровые настройки(list с 3 значениями от 1 до 10)</param>
        public static void Write_TXT(int Money, int Exp, List<string> InventoryParts, List<int> Settings, int Lvl)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "data";
            string SubInv = "";
            foreach(string i in InventoryParts)
            {
                SubInv += (i+",");
            }
            string SubSett = "";
            foreach (int i in Settings)
            {
                SubSett += (i.ToString() + ",");
            }
            string text = "Money:" + Money.ToString() + ";Exp:" + Exp.ToString() + ";InventoryParts:" + SubInv + ";Settings:" + SubSett + ";Lvl:" + Lvl;
            File.WriteAllText(Path.Combine(folderPath, filename), text);
            ReturnPerson();
        }
        /// <summary>
        /// Сохранение данных в файл
        /// </summary>
        /// <param name="InventoryParts">Список с названиями компонентов</param>
        public static void Write_TXT(List<string> InventoryParts)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "data";
            string Data = Read_TXT(filename);
            string[] words = Data.Split(new char[] { ';' });
            string SubInv = "";
            foreach (string i in InventoryParts)
            {
                if (i != "" && i != null)
                    if (SubInv.Length == 0)
                        SubInv += i;
                    else
                        SubInv += ("," + i);
            }
            string text = words[0] + ";" + words[1] + ";InventoryParts:" + SubInv + ";" + words[3] + ";" + words[4] +";";
            File.WriteAllText(Path.Combine(folderPath, filename), text);
            //ReturnPerson();
        }

        public static void Write_TXT(int Money)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "data";
            string Data = Read_TXT(filename);
            string[] words = Data.Split(new char[] { ';' });

            Console.WriteLine("testtt" + Data);
            string text = "Money:" + Money.ToString() + ";" + words[1] + ";" + words[2] + ";" + words[3] + ";" + words[4] + ";";
            File.WriteAllText(Path.Combine(folderPath, filename), text);
            // ReturnPerson();
        }
        /// <summary>
        /// Сохранения данных в файл
        /// </summary>
        /// <param name="Exp">Количество Опыта   для сохранения</param>
        public static void Write_TXT2(int Exp)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "data";

            string Data = Read_TXT(filename);
            string[] words = Data.Split(new char[] { ';' });
            Console.WriteLine("testtt" + Data);
            string text = words[0] + ";Exp:" + Exp + ";" + words[2] + ";" + words[3] + ";" + words[4] + ";";
            File.WriteAllText(Path.Combine(folderPath, filename), text);
            // ReturnPerson();
        }

        public static void Write_TXT3(int Lvl)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "data";
            string Data = Read_TXT(filename);
            string[] words = Data.Split(new char[] { ';' });
            Console.WriteLine("testtt" + Data);
            string text = words[0] + ";" + words[1] + ";" + words[2] + ";" + words[3] + ";Lvl:" + Lvl + ";";
            File.WriteAllText(Path.Combine(folderPath, filename), text);
            // ReturnPerson();
        }
        public static void Write_TXT4(List<string> Settings)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = "data";
            string Data = Read_TXT(filename);
            string[] words = Data.Split(new char[] { ';' });
            Console.WriteLine("testtt" + Data);
            string SubSett = "";
            foreach(string i in Settings)
            {
                if (i != "" && i != null)
                    if (SubSett.Length == 0)
                        SubSett += i;
                    else
                        SubSett += ("," + i);
            }
            Console.WriteLine(SubSett);
            string text = words[0] + ";" + words[1] + ";" + words[2] + ";" + "Settings:"+ SubSett + ";"+ words[4]+ ";";
            File.WriteAllText(Path.Combine(folderPath, filename), text);
            // ReturnPerson();
        }
        /// <summary>
        ///  Преобразование данных файла в характеристики игрока
        /// </summary>
        /// <returns>Класс игрока</returns>
        public static PersonClass ReturnPerson()
        {
            string Data = Read_TXT("data");
            int Money = Convert.ToInt32(Data.Split(';')[0].Split(':')[1]);
            int Exp = Convert.ToInt32(Data.Split(';')[1].Split(':')[1]);
            List<string> Inv = new List<string> { };
            foreach (string i in Data.Split(';')[2].Split(':')[1].Split(','))
            {
                Inv.Add(i);
            }
            List<int> Settings = new List<int> { };
            foreach(string i in Data.Split(';')[3].Split(':')[1].Split(','))
            {
                Settings.Add(Convert.ToInt32(i));
            }
            int Lvl = Convert.ToInt32(Data.Split(';')[4].Split(':')[1]);
            PersonClass Player = new PersonClass(Money, Exp, Inv, Settings, Lvl);
            return Player;
        }
        public static void Write_Client(string Name, string Order, int amount)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string text = "";            
            if (Name != "delete")
            {
                text = Name + ";" + Order + ";" + amount.ToString() + ";"+Page.PlayPage.zakaz+";";
            }
            File.WriteAllText(Path.Combine(folderPath, "client"), text);
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
                string text = "Money:200000;Exp:0;InventoryParts:;Settings:10,10,10;Lvl:1;";
                File.WriteAllText(Path.Combine(folderPath, filename), text);
                ReturnPerson();
            }
            if (!File.Exists(Path.Combine(folderPath, "pcs")))
            {
                File.WriteAllText(Path.Combine(folderPath, "pcs"), "");
                ReturnPerson();
            }
            if (!File.Exists(Path.Combine(folderPath, "client")))
            {
                File.WriteAllText(Path.Combine(folderPath, "client"), "");
                ReturnPerson();
            }
        } 
    }
}
