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
public partial class AboutAuthorsPage : ContentPage
{
    public AboutAuthorsPage()
    {
        InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            ImageLogotip.IsAnimationPlaying = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.TempPage());
        }
    }
}