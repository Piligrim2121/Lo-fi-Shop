
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
public partial class PlayPage : ContentPage
{

        
        public PlayPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }   

        private void ImageShkaf_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.InventoryPage());
        }

        private void ImageTable_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.CraftPage());
        }

        private void ImageKassa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.ShopPage());
        }

        private void TableOfQuest_Open(object sender, EventArgs e)
        {
            ImageTableOfQuestOpen.IsVisible = true;
        }

        private void TableOfQuest_Clouse(object sender, EventArgs e)
        {
            ImageTableOfQuestOpen.IsVisible = false;

        }


       
    }
}