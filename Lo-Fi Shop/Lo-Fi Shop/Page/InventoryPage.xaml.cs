using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lo_Fi_Shop.Class;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryPage : ContentPage
    {
        public InventoryPage()
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


        public static void AddToInv(string Part)
        {
            InvPart = new List<string>();
            PersonClass Player = PersonClass.OverwriteData();
            InvPart = Player.InventoryPath;
            InvPart.Add(Part);
            PersonClass.Write_TXT(InvPart);
        }
    }
}