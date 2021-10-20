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
            Console.WriteLine(Players.InventoryPath.Count);
        }
        static PersonClass Players;
        private void Sborka_Clicked(object sender, EventArgs e)
        {
            if (Proverka())
            {
                Console.WriteLine(Proverka().ToString());
            }
        }
        private bool Proverka() // крестик по умолчанию когда не выбран
        {
            if (Proc.Source.ToString() == "File: Resource/drawable/Sborka.png" 
                || Video.Resources.ToString() == "File: Resource/drawable/Sborka.png" ||
                Mat.Resources.ToString() == "File: Resource/drawable/Sborka.png" ||
                OP.Resources.ToString() == "File: Resource/drawable/Sborka.png" ||
                HDD.Resources.ToString() == "File: Resource/drawable/Sborka.png" ||
                Pit.Resources.ToString() == "File: Resource/drawable/Sborka.png" ||
                Kyler.Resources.ToString() == "File: Resource/drawable/Sborka.png" ||
                Korpus.Resources.ToString() == "File: Resource/drawable/Sborka.png")
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
                    Proc.Source = @"Resource/drawable/Viduha.jpg";
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
                    Video.Source = @"Resource/drawable/Viduha.jpg";
                }
            }
        }
        private void Sborka_Mat(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Материнская плата"))
                {
                    Mat.Source = @"Resource/drawable/Viduha.jpg";
                }
            }
        }
        private void Sborka_OP(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Оперативная память"))
                {
                    OP.Source = @"Resource/drawable/Viduha.jpg";
                }
            }
        }
        private void Sborka_HDD(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Жёсткий диск"))
                {
                    HDD.Source = @"Resource/drawable/Viduha.jpg";
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
                    Pit.Source = @"Resource/drawable/Viduha.jpg";
                }
            }
        }
        private void Sborka_Kyler(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Система охлаждения"))
                {
                    Kyler.Source = @"Resource/drawable/Viduha.jpg";
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
                    Korpus.Source = @"Resource/drawable/Viduha.jpg";
                }
            }
        }
    }
}