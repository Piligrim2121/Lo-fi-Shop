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
            
        }

        protected override void OnResume()
        {
            if (!PersonClass.Playing)
            {
                PersonClass music = PersonClass.ReturnPerson();
                PersonClass.player.Play();
               
                PersonClass.player.Volume = music.Settings[1];
            }
        }
    }
}
