using Lo_Fi_Shop.Class;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryPage : ContentPage
    {
        public InventoryPage(bool Da = false)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            
            if (Da)
            {
                Obvodka1.Source = null;
                Obvodka2.Source = "Resource/drawable/Obvodka.png";
                Sell.IsVisible = true;
            }
            
            
            DisplayInvPath();
            if (Inv_Grid.Children.Count > 0)
            {
                CP_Inv.BackgroundImageSource = "Resources/drawable/InventoryDefault.png";

            }
            else if (Inv_Grid.Children.Count == 0)
            {
                CP_Inv.BackgroundImageSource = "Resources/drawable/EmptyInventory.png";

            }
        }
        ImageButton tempBtn;
        public static List<string> InvPart { get; set; }
        private void TestVideoCard_Clicked(object sender, EventArgs e)
        {
            tempBtn = sender as ImageButton;
            
            if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[0].Path)
            {
                Description.Text = "Устройство начального уровня, преобразующее графический образ, хранящийся как содержимое памяти компьютера, в форму, пригодную для дальнейшего вывода на экран монитора."; //Item.InInvItems[0].Description;
                Info_name.Text = Item.InInvItems[0].Name;
                Cost.Text = Item.InInvItems[0].Sell.ToString()+ "₽";
            }
           else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[1].Path)
            {
                Description.Text = "Центральная часть компьютера начального уровня, выполняющая заданные программой преобразования информации и осуществляющая управление всем вычислительным процессом.";
                Info_name.Text = Item.InInvItems[1].Name;
                Cost.Text = Item.InInvItems[1].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[2].Path)
            {
                Description.Text = "Сборка вентилятора с радиатором, устанавливаемая для воздушного охлаждения электронных компонентов компьютера с повышенным тепловыделением (обычно более 5 Вт)";
                Info_name.Text = Item.InInvItems[2].Name;
                Cost.Text = Item.InInvItems[2].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[3].Path)
            {
                Description.Text = "Энергозависимая часть системы компьютерной памяти начального уровня, в которой во время работы компьютера хранится выполняемый машинный код.";
                Info_name.Text = Item.InInvItems[3].Name;
                Cost.Text = Item.InInvItems[3].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[4].Path)
            {

                Description.Text = "Печатная плата начального уровня, являющаяся основой построения модульного устройства.";
                Info_name.Text = Item.InInvItems[4].Name;
                Cost.Text = Item.InInvItems[4].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[5].Path)
            {
                Description.Text = "Базовая несущуя конструкция начального уровня, которая предназначена для последующего наполнения аппаратным обеспечением с целью создания компьютера.";
                Info_name.Text = Item.InInvItems[5].Name;
                Cost.Text = Item.InInvItems[5].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[6].Path)
            {
                Description.Text = "Устройство начального уровня, предназначенное для преобразования напряжения переменного тока от сети в напряжение постоянного тока с целью питания компьютера или компьютер-сервера.";
                Info_name.Text = Item.InInvItems[6].Name;
                Cost.Text = Item.InInvItems[6].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[7].Path)
            {
                Description.Text = "Устройство начального уровня, используемое для хранения цифрового содержимого и других данных на компьютерах.";
                Info_name.Text = Item.InInvItems[7].Name;
                Cost.Text = Item.InInvItems[7].Sell.ToString() + "₽";
            }
            //switch ((sender as ImageButton).GetType().GUID.ToString())
            //{
            //    case "00000000-0000-0000-0000-000000000000":
            //        Console.WriteLine("lol");
            //        break;
            //}
        }

        private void DisplayInvPath()
        {
             Console.WriteLine(Inv_Grid.Children.Count);
            Inv_Grid.Children.Clear();
            Console.WriteLine(Inv_Grid.Children.Count);
            if (Obvodka1.Source != null)
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
                    for (int c = 0; c < Item.InInvItems.Length; c++) {
                        if (i == Item.InInvItems[c].Name)
                        {
                            ImageButton imageButton = new ImageButton {Margin= new Thickness(20,-20,0,-65),Scale =1.0 ,Source = Item.InInvItems[c].Path, BackgroundColor = Color.Transparent };
                            imageButton.Clicked += TestVideoCard_Clicked;
                            Inv_Grid.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5) + 1, ((LenInv / 5) + 1));
                        }
                    }
                    LenInv++;
                }
                LenInv = 0;
            }
            else
            {
                PersonClass Player = PersonClass.ReturnPerson();
                InvPart = Player.InventoryWhole;
                int LenInv = 0;
                foreach (string i in InvPart)
                {
                    if (i == "")
                    {
                        continue;
                    }
                    ImageButton imageButton = new ImageButton { Source = "Resources/drawable/PC.jpg", BackgroundColor = Color.Transparent };
                    imageButton.Clicked += TestVideoCard_Clicked;
                    Inv_Grid.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5) + 1, ((LenInv / 5) + 1));
                    LenInv++;
                }
                LenInv = 0;
            }
        }

        

        public static void AddToInv(string Part)
        {
            //InvPart = new List<string>();    
            PersonClass Player = PersonClass.ReturnPerson();
            InvPart = Player.InventoryPath;
            InvPart.Add(Part);
            PersonClass.Write_TXT(InvPart);       
        }

        private void Obvodka_Clicked(object sender, EventArgs e)
        {
            if (Obvodka1.Source == null)
            {
                Obvodka1.Source = "Resource/drawable/Obvodka.png";
                Obvodka2.Source = null;
                DisplayInvPath();
            }
        }

        private void Obvodka2_Clicked(object sender, EventArgs e)
        {
          
            if (Obvodka2.Source == null)
            {
                
                Obvodka1.Source = null;
                Obvodka2.Source = "Resource/drawable/Obvodka.png";

                DisplayInvPath();
            }
        }

        private void Sell_Clicked(object sender, EventArgs e)
        {
            //2
        }
    }
}
