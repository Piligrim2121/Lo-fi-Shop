//using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.IO;
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
            _Settings = Settings; // list с 3 значениями
        }

        public static string Read_TXT()
        {
            // код чтения из файл
            string text = "123";
            return text;
        }
        public static void Write_TXT(int Money, int Exp, List<string> Inventory, List<int> Settings)
        {
            // код сохранения в файл
        }
        public static void OverwriteData()
        {
            // код сохранения и вывода данных в конструктор
        }
    }
}
