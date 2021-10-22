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
            if (Inv_Grid.Children.Count > 1)
            {
                CP_Inv.BackgroundImageSource = "Resources/drawable/InventoryDefault.png";
               
            }
            else
            {
                CP_Inv.BackgroundImageSource = "Resources/drawable/EmptyInventory.png";
                
            }
            if (Da)
            {
                Obvodka1.Source = null;
                Obvodka2.Source = "Resource/drawable/Obvodka.png";
                Sell.IsVisible = true;
            }
            DisplayInvPath();
        }
        public static List<string> InvPart { get; set; }
        private void TestVideoCard_Clicked(object sender, EventArgs e)
        {
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
                PersonClass Player = PersonClass.OverwriteData();
                InvPart = Player.InventoryPath;
                int LenInv = 0;
                foreach (string i in InvPart)
                {
                    if (i == "")
                    {
                        continue;
                    }
                    ImageButton imageButton = new ImageButton { Source = "Resources/drawable/Viduha.jpg", BackgroundColor = Color.Transparent };
                    imageButton.Clicked += TestVideoCard_Clicked;
                    Inv_Grid.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5) + 1, ((LenInv / 5) + 1));
                    LenInv++;
                }
                LenInv = 0;
            }
            else
            {
                PersonClass Player = PersonClass.OverwriteData();
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
            InvPart = new List<string>();
            PersonClass Player = PersonClass.OverwriteData();
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
