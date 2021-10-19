using Lo_Fi_Shop.Class;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CraftPage : ContentPage
    {
        public CraftPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Players = PersonClass.OverwriteData();
        }
        static PersonClass Players;
        private void Sborka_Clicked(object sender, EventArgs e)
        {
            if (Proverka())
            {
                // удаляем элементы из инвентаря и добавляем комп
            }
        }
        private bool Proverka() // крестик по умолчанию когда не выбран
        {
            if (Proc.Resources.ToString() == "крестик" || Video.Resources.ToString() == "крестик" ||
                Mat.Resources.ToString() == "крестик" || OP.Resources.ToString() == "крестик" ||
                HDD.Resources.ToString() == "крестик" || Pit.Resources.ToString() == "крестик" ||
                Kyler.Resources.ToString() == "крестик" || Korpus.Resources.ToString() == "крестик")
                return false;
            else
                return true;
        }
        private void Sborka_Proc(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach(string i in komponent)
            {
                if (i.Contains("Процессор"))
                {
                    // меняем ресурс на проц
                }
            }
        }
        private void Sborka_Video(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Видеокарта"))
                {
                    // меняем ресурс на 
                }
            }
        }
        private void Sborka_Mat(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Материнская Плата"))
                {
                    // меняем ресурс на 
                }
            }
        }
        private void Sborka_OP(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("ОП"))
                {
                    // меняем ресурс на 
                }
            }
        }
        private void Sborka_HDD(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Диск"))
                {
                    // меняем ресурс на 
                }
            }
        }
        private void Sborka_Pit(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Блок Питания"))
                {
                    // меняем ресурс на 
                }
            }
        }
        private void Sborka_Kyler(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Кулер"))
                {
                    // меняем ресурс на 
                }
            }
        }
        private void Sborka_Korpus(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Корпус"))
                {
                    // меняем ресурс на 
                }
            }
        }
    }
}