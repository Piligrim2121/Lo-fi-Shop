using Lo_Fi_Shop.Class;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainMenuPage());
            
            //MainPage = new MainMenuPage();

        }
      
        protected override void OnStart()
        {
           
        }

        protected override void OnSleep()
        {
            
            PersonClass.player.Pause();
            PersonClass.Sleep = true;
            
        }

        protected override void OnResume()
        {
            PersonClass.Sleep = false;
            PersonClass.Playing = false;

        }
    }
}
