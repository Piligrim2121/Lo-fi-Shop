using System;
using Lo_Fi_Shop.Class;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Lo_Fi_Shop.Page;
using System.IO;
using System.Reflection;
using Plugin.SimpleAudioPlayer;

namespace Lo_Fi_Shop
{
    public partial class MainMenuPage : ContentPage
    {
        /// <summary>
        /// Инициализация компонентов и загрузка главного меню 
        /// </summary>
        ISimpleAudioPlayer ClickSound;
        PersonClass Music = PersonClass.ReturnPerson();
        //string[] st = new string[10];
        
        public MainMenuPage()
        {
            InitializeComponent();
            
           
            PersonClass.First_Write_TXT();
            NavigationPage.SetHasNavigationBar(this, false);
            ImageLogotip.IsAnimationPlaying = true;
           // var stream = PersonClass.GetStreamFromFile("music.wav");
            PersonClass.player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            //   string [] st = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            //BtnPlay.Text = st[0];
            //if (!PersonClass.Playing)
            //{

            //    PersonClass.player.Load(stream);
            //    Btnwav();
            //}
            if (PersonClass.Playing == false)
            {
                PersonClass Player = PersonClass.ReturnPerson();
                string[] radio = new string[] { "music.wav", "StudyBeat.mp3", "MyEyes.mp3", "BackHome.mp3", "FirstGirl.mp3", "StarWars.mp3", "SayAnything.mp3", "TinyEvil.mp3", "LilPeep.mp3", "Chillhop.mp3" };
                Random r = new Random();
                var stream = PersonClass.GetStreamFromFile(radio[r.Next(0, 10)]);
               // PersonClass.player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                PersonClass.player.Load(stream);
                PersonClass.player.Volume = Player.Settings[1];
                PersonClass.player.Play();

            }
            PersonClass.Playing = true;
            
        }

        private void Btnwav()
        {
           
            PersonClass.player.Volume = Music.Settings[1];
            PersonClass.player.Play();
        }
       

        /// <summary>
        /// Переход к экрану "Как Играть"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHowToPlay_Clicked(object sender, EventArgs e)
        {
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Music.Settings[2];
            ClickSound.Play();

            Navigation.PushAsync(new Page.HowToPlayPage());
        }
        /// <summary>
        /// Переход к главному  экрану игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_Clicked(object sender, EventArgs e)
        {
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Music.Settings[2];
            ClickSound.Play();

            Navigation.PushAsync(new Page.PlayPage());
            new QuestPage("");
        // Navigation.PushAsync(new Page.TempPage());
        }
        /// <summary>
        /// Переход к экрану "Настройки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetting_Clicked(object sender, EventArgs e)
        {
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Music.Settings[2];
            ClickSound.Play();

            Navigation.PushAsync(new Page.SettingsPage());
        }
        /// <summary>
        /// Переход к экрану "Об авторах"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Clicked(object sender, EventArgs e)
        {
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Music.Settings[2];
            ClickSound.Play();

            Navigation.PushAsync(new Page.AboutAuthorsPage());
        }
        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Music.Settings[2];
            ClickSound.Play();

            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        

        // Метод для фоновой музыки
    }
}
