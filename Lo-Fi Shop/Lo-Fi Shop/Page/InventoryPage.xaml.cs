using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class InventoryPage : ContentPage
{
    public InventoryPage()
    {
        InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (Inv_Grid.Children.Count > 1) {
                CP_Inv.BackgroundImageSource = "Resources/drawable/InventoryDefault.png";
                    }
            else
            {
                CP_Inv.BackgroundImageSource = "Resources/drawable/EmptyInventory.png";
            }

        }

        private void TestVideoCard_Clicked(object sender, EventArgs e)
        {
            switch ((sender as ImageButton).GetType().GUID.ToString()) {
               case "00000000-0000-0000-0000-000000000000":
            Console.WriteLine("lol");
                    break;
                    }
        
        }
    }
}