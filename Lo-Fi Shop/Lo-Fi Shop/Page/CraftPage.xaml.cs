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
            DisplayInvPath();
        }

        static PersonClass Players;
        public static List<string> InvPart { get; set; }
        public static List<string> Items { get; set; }

        public int Cost;
        private void DisplayInvPath()
        {
            PersonClass Player = PersonClass.OverwriteData();
            InvPart = Player.InventoryPath;
            int LenInv = 0;
            foreach (string i in InvPart)
            {
                if (i == "")
                {
                    continue;
                }
                ImageButton imageButton = new ImageButton { Source = "Resources/drawable/Viduha.jpg" };
                InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5) + 1, ((LenInv / 5) + 1));
                LenInv++;
            }
            LenInv = 0;
        }
        private void Sborka_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(Cost.ToString());
            if (Proverka())
            {
                InvPart = new List<string>();
                string name = "";
                if (Cost <= 30000)
                {
                    name = "Начальный корпус";
                }
                else if ((Cost >= 30000) && (Cost <= 100000))
                {
                    name = "Средний корпус";
                }
                else
                {
                    name = "Дорогой корпус";
                }
                Item item = new Item(name, Cost);
                PersonClass Player = PersonClass.OverwriteData();
                InvPart = Player.InventoryWhole;
                InvPart.Add(item.Name);
                PersonClass.Write_TXT2(InvPart);

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
                if (i.Contains("Начальный Процессор"))
                {
                    Proc.Source = @"Resource/drawable/Viduha.jpg";
                    Cost += Item.CreateItems()[1].Sell;
                }
                else if (i.Contains("Средний Процессор"))
                {
                    Proc.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогой Процессор"))
                {
                    Proc.Source = @"Resource/drawable/Viduha.jpg";
                }
                else
                {
                    // меняем бэк на красный
                }
            }
        }
        private void Sborka_Video(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Начальная Видеокарта"))
                {
                    Video.Source = @"Resource/drawable/Viduha.jpg";
                    Cost += Item.CreateItems()[0].Sell;
                }
                else if (i.Contains("Средняя Видеокарта"))
                {
                    Video.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогая Видеокарта"))
                {
                    Video.Source = @"Resource/drawable/Viduha.jpg";
                }
                else
                {
                    // меняем бэк на красный
                }
            }
        }
        private void Sborka_Mat(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Начальная Материнская плата"))
                {
                    Mat.Source = @"Resource/drawable/Viduha.jpg";
                    Cost += Item.CreateItems()[5].Sell;
                }
                else if (i.Contains("Средняя Материнская плата"))
                {
                    Mat.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогая Материнская плата"))
                {
                    Mat.Source = @"Resource/drawable/Viduha.jpg";
                }
                else
                {
                    // меняем бэк на красный
                }
            }
        }
        private void Sborka_OP(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Начальная Оперативная память"))
                {
                    OP.Source = @"Resource/drawable/Viduha.jpg";
                    Cost += Item.CreateItems()[3].Sell;
                }
                else if (i.Contains("Средняя Оперативная память"))
                {
                    OP.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогая Оперативная память"))
                {
                    OP.Source = @"Resource/drawable/Viduha.jpg";
                }
                else
                {
                    // меняем бэк на красный
                }
            }
        }
        private void Sborka_HDD(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Начальный Жёсткий диск"))
                {
                    HDD.Source = @"Resource/drawable/Viduha.jpg";
                    Cost += Item.CreateItems()[7].Sell;
                }
                else if (i.Contains("Средний Жёсткий диск"))
                {
                    HDD.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогой Жёсткий диск"))
                {
                    HDD.Source = @"Resource/drawable/Viduha.jpg";
                }
                else
                {
                    // меняем бэк на красный
                }
            }
        }
        private void Sborka_Pit(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Начальный Блок Питания"))
                {
                    Pit.Source = @"Resource/drawable/Viduha.jpg";
                    Cost += Item.CreateItems()[6].Sell;
                }
                else if (i.Contains("Средний Блок Питания"))
                {
                    Pit.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогой Блок Питания"))
                {
                    Pit.Source = @"Resource/drawable/Viduha.jpg";
                }
                else
                {
                    // меняем бэк на красный
                }
            }
        }
        private void Sborka_Kyler(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Начальная Система охлаждения"))
                {
                    Kyler.Source = @"Resource/drawable/Viduha.jpg";
                    Cost += Item.CreateItems()[2].Sell;
                }
                else if (i.Contains("Средняя Система охлаждения"))
                {
                    Kyler.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогая Система охлаждения"))
                {
                    Kyler.Source = @"Resource/drawable/Viduha.jpg";
                }
                else
                {
                    // меняем бэк на красный
                }
            }
        }
        private void Sborka_Korpus(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Начальный Корпус"))
                {
                    Korpus.Source = @"Resource/drawable/Viduha.jpg";
                    Cost += Item.CreateItems()[5].Sell;
                }
                else if (i.Contains("Средний Корпус"))
                {
                    Korpus.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогой Корпус"))
                {
                    Korpus.Source = @"Resource/drawable/Viduha.jpg";
                }
                else
                {
                    // меняем бэк на красный
                }
            }
        }
    }
}