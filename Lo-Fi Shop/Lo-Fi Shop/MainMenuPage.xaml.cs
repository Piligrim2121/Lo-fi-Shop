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

        //string[] st = new string[10];
        List<Button> AllBtn = new List<Button>();
        public MainMenuPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            PersonClass.First_Write_TXT();
            ImageLogotip.IsAnimationPlaying = true;
            AllBtn.Add((Button)(FindByName("BtnPlay")));
            AllBtn.Add((Button)(FindByName("BtnSetting")));
            AllBtn.Add((Button)(FindByName("BtnAbout")));
            AllBtn.Add((Button)(FindByName("BtnHowToPlay")));
            AllBtn.Add((Button)(FindByName("BtnExit")));
            // var stream = PersonClass.GetStreamFromFile("music.wav");
            PersonClass.player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            //   string [] st = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            //BtnPlay.Text = st[0];
            //if (!PersonClass.Playing)
            //{
            //    PersonClass.player.Load(stream);
            
            Btnwav();
            //}    
        }

        private void Btnwav()
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
       

        /// <summary>
        /// Переход к экрану "Как Играть"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHowToPlay_Clicked(object sender, EventArgs e)
        {
            PersonClass Music = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Convert.ToDouble(Music.Settings[2]) / 10; ;
            ClickSound.Play();

            Navigation.PushAsync(new Page.HowToPlayPage());
            EnableButton_Closed();
            EnableButton_Opened();
        }
        PlayPage GamePlay;
        /// <summary>
        /// Переход к главному  экрану игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_Clicked(object sender, EventArgs e)
        {
            
            PersonClass Music = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Convert.ToDouble(Music.Settings[2]) / 10;
            ClickSound.Play();
            if (PersonClass.FirstTime) {
             GamePlay = new PlayPage();
                PersonClass.FirstTime = false;
            Navigation.PushAsync(GamePlay);
            }
            else
            {
                Navigation.PushAsync(GamePlay);
            }
            EnableButton_Closed();
            EnableButton_Opened();
            // new QuestPage("");
            // Navigation.PushAsync(new Page.TempPage());
        }
        /// <summary>
        /// Переход к экрану "Настройки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetting_Clicked(object sender, EventArgs e)
        {
            PersonClass Music = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Convert.ToDouble(Music.Settings[2]) / 10;
            ClickSound.Play();

            Navigation.PushAsync(new Page.SettingsPage());
            EnableButton_Closed();
            EnableButton_Opened();
        }
        /// <summary>
        /// Переход к экрану "Об авторах"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Clicked(object sender, EventArgs e)
        {
            PersonClass Music = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Convert.ToDouble(Music.Settings[2]) / 10;
            ClickSound.Play();

            Navigation.PushAsync(new Page.AboutAuthorsPage());
            EnableButton_Closed();
            EnableButton_Opened();
        }
        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            PersonClass Music = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Convert.ToDouble(Music.Settings[2]) / 10;
            ClickSound.Play();

            System.Diagnostics.Process.GetCurrentProcess().Kill();
            EnableButton_Closed();
            EnableButton_Opened();
        }
        private async void EnableButton_Opened()
        {
            await Task.Delay(1000);
            for (int i = 0; i < AllBtn.Count; i++)
            {
                AllBtn[i].IsEnabled = true;
            }
        }
        private void EnableButton_Closed()
        {
            for (int i = 0; i < AllBtn.Count; i++)
            {
                AllBtn[i].IsEnabled = false;
            }
        }

        // Метод для фоновой музыки
    }
}
