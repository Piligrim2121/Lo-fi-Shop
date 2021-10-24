using Lo_Fi_Shop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Players = PersonClass.ReturnPerson();
            DisplayInvPath();
        }

        static PersonClass Players;
        public static List<string> InvPart { get; set; }
        public static List<string> Items { get; set; }

        public int Cost;

        List<string> UseKomponents = new List<string>();

        private void DisplayInvPath()
        {
            PersonClass Player = PersonClass.ReturnPerson();
            InvPart = Player.InventoryPath;
            int LenInv = 0;
            foreach (string i in InvPart)
            {
                if (i == "")
                {
                    continue;
                }
                else if (i == Item.CreateItems()[0].Name)
                {
                    ImageButton imageButton = new ImageButton { Source = Item.CreateItems()[0].Path, BackgroundColor = Color.Transparent };
                    InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5), ((LenInv / 5) + 1));
                }
                else if (i == Item.CreateItems()[1].Name)
                {
                    ImageButton imageButton = new ImageButton { Source = Item.CreateItems()[1].Path, BackgroundColor = Color.Transparent };
                    InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5), ((LenInv / 5) + 1));
                }
                else if (i == Item.CreateItems()[2].Name)
                {
                    ImageButton imageButton = new ImageButton { Source = Item.CreateItems()[2].Path, BackgroundColor = Color.Transparent };
                    InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5), ((LenInv / 5) + 1));
                }
                else if (i == Item.CreateItems()[3].Name)
                {
                    ImageButton imageButton = new ImageButton { Source = Item.CreateItems()[3].Path, BackgroundColor = Color.Transparent };
                    InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5), ((LenInv / 5) + 1));
                }
                else if (i == Item.CreateItems()[4].Name)
                {
                    ImageButton imageButton = new ImageButton { Source = Item.CreateItems()[4].Path, BackgroundColor = Color.Transparent };
                    InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5), ((LenInv / 5) + 1));
                }
                else if (i == Item.CreateItems()[5].Name)
                {
                    ImageButton imageButton = new ImageButton { Source = Item.CreateItems()[5].Path, BackgroundColor = Color.Transparent };
                    InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5), ((LenInv / 5) + 1));
                }
                else if (i == Item.CreateItems()[6].Name)
                {
                    ImageButton imageButton = new ImageButton { Source = Item.CreateItems()[6].Path, BackgroundColor = Color.Transparent };
                    InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5), ((LenInv / 5) + 1));
                }
                else if (i == Item.CreateItems()[7].Name)
                {
                    ImageButton imageButton = new ImageButton { Source = Item.CreateItems()[7].Path, BackgroundColor = Color.Transparent };
                    InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5), ((LenInv / 5) + 1));
                }
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
                if (Cost <= 50000)
                {
                    name = "Начальный корпус";
                }
                else if ((Cost >= 50000) && (Cost <= 120000))
                {
                    name = "Средний корпус";
                }
                else
                {
                    name = "Дорогой корпус";
                }
                Item item = new Item(name, Cost, "Resources/drawable/PC.jpg");
                PersonClass Player = PersonClass.ReturnPerson();
                InvPart = Player.InventoryWhole;
                InvPart.Add(item.Name);
                PersonClass.Write_TXT2(InvPart);
                string[] Text = PersonClass.Read_TXT().Split(';')[2].Split(':')[1].Split(',');
                foreach (string i in UseKomponents)
                {
                    for (int j = 0; j < Text.Length; j++)
                    {
                        if (Text[j] == i)
                        {
                            Text[j] = null;
                            break;
                        }
                    }
                }
                UseKomponents.Clear();
                List<string> list = Text.ToList<string>();
                for (int j = 0; j < list.Count; j++)
                {
                    if(list[j] == null)
                    {
                        list.RemoveAt(j);
                    }
                }    
                PersonClass.Write_TXT(list);
                Navigation.PushAsync(new Page.PlayPage());
            }
        }
        private bool Proverka() // крестик по умолчанию когда не выбран
        {
            if (Proc.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Video.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Mat.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                OP.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                HDD.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Pit.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Kyler.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Korpus.Source.ToString() == "File: Resource/drawable/ItemPlace.png")
                return false;
            else
                return true;
        }
        private void Sborka_Proc(object sender, EventArgs e)
        {
            List<string> komponent = Players.InventoryPath;
            foreach (string i in komponent)
            {
                if (i.Contains("Начальный Процессор"))
                {
                    Proc.Source = @"Resource/drawable/Easy_Proc.png";
                    Cost += Item.CreateItems()[1].Sell;
                    if (UseKomponents.Contains("Начальный Процессор"))
                        UseKomponents.Remove("Начальный Процессор");
                    UseKomponents.Add(Item.CreateItems()[1].Name);
                }
                else if (i.Contains("Средний Процессор"))
                {
                    //Proc.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогой Процессор"))
                {
                    //Proc.Source = @"Resource/drawable/Viduha.jpg";
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
                    Video.Source = @"Resource/drawable/Easy_Vid.png";
                    Cost += Item.CreateItems()[0].Sell;
                    if (UseKomponents.Contains("Начальная Видеокарта"))
                        UseKomponents.Remove("Начальная Видеокарта");
                    UseKomponents.Add(Item.CreateItems()[0].Name);
                }
                else if (i.Contains("Средняя Видеокарта"))
                {
                    //Video.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогая Видеокарта"))
                {
                    //Video.Source = @"Resource/drawable/Viduha.jpg";
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
                    Mat.Source = @"Resource/drawable/Easy_Mother.png";
                    Cost += Item.CreateItems()[4].Sell;
                    if (UseKomponents.Contains("Начальная Материнская плата"))
                        UseKomponents.Remove("Начальная Материнская плата");
                    UseKomponents.Add(Item.CreateItems()[4].Name);
                }
                else if (i.Contains("Средняя Материнская плата"))
                {
                    //Mat.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогая Материнская плата"))
                {
                    //Mat.Source = @"Resource/drawable/Viduha.jpg";
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
                    OP.Source = @"Resource/drawable/Easy_ram.png";
                    Cost += Item.CreateItems()[3].Sell;
                    if (UseKomponents.Contains("Начальная Оперативная память"))
                        UseKomponents.Remove("Начальная Оперативная память");
                    UseKomponents.Add(Item.CreateItems()[3].Name);
                }
                else if (i.Contains("Средняя Оперативная память"))
                {
                    //OP.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогая Оперативная память"))
                {
                    //OP.Source = @"Resource/drawable/Viduha.jpg";
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
                    HDD.Source = @"Resource/drawable/Easy_mem.png";
                    Cost += Item.CreateItems()[7].Sell;
                    if (UseKomponents.Contains("Начальный Жёсткий диск"))
                        UseKomponents.Remove("Начальный Жёсткий диск");
                    UseKomponents.Add(Item.CreateItems()[7].Name);
                }
                else if (i.Contains("Средний Жёсткий диск"))
                {
                    //HDD.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогой Жёсткий диск"))
                {
                    //HDD.Source = @"Resource/drawable/Viduha.jpg";
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
                    Pit.Source = @"Resource/drawable/Easy_Power.png";
                    Cost += Item.CreateItems()[6].Sell;
                    if (UseKomponents.Contains("Начальный Блок Питания"))
                        UseKomponents.Remove("Начальный Блок Питания");
                    UseKomponents.Add(Item.CreateItems()[6].Name);
                }
                else if (i.Contains("Средний Блок Питания"))
                {
                    //Pit.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогой Блок Питания"))
                {
                    //Pit.Source = @"Resource/drawable/Viduha.jpg";
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
                    Kyler.Source = @"Resource/drawable/Easy_Cooler.png";
                    Cost += Item.CreateItems()[2].Sell;
                    if (UseKomponents.Contains("Начальная Система охлаждения"))
                        UseKomponents.Remove("Начальная Система охлаждения");
                    UseKomponents.Add(Item.CreateItems()[2].Name);
                }
                else if (i.Contains("Средняя Система охлаждения"))
                {
                    //Kyler.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогая Система охлаждения"))
                {
                    //Kyler.Source = @"Resource/drawable/Viduha.jpg";
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
                    Korpus.Source = @"Resource/drawable/Easy_corpus.png";
                    Cost += Item.CreateItems()[5].Sell;
                    if (UseKomponents.Contains("Начальный Корпус"))
                        UseKomponents.Remove("Начальный Корпус");
                    UseKomponents.Add(Item.CreateItems()[5].Name);
                }
                else if (i.Contains("Средний Корпус"))
                {
                    //Korpus.Source = @"Resource/drawable/Viduha.jpg";
                }
                else if (i.Contains("Дорогой Корпус"))
                {
                    //Korpus.Source = @"Resource/drawable/Viduha.jpg";
                }
                else
                {
                    // меняем бэк на красный
                }
            }
        }
    }
}