
using Lo_Fi_Shop.Class;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        PersonClass Music = PersonClass.ReturnPerson();
        ISimpleAudioPlayer ClickSound;
        public SettingsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            anim.IsAnimationPlaying = true;

            CommonVolume.Value = Music.Settings[0];
            MusicVolume.Value = Music.Settings[1];
            SoundVolume.Value = Music.Settings[2];
        }

        private void CommonVolume_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            MusicVolume.Value = CommonVolume.Value;
            SoundVolume.Value = CommonVolume.Value;
        }

        private void SoundVolume_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            PersonClass.player.Volume = Convert.ToDouble(MusicVolume.Value)/10;
            PersonClass.Write_TXT4(new List<string>{Math.Round(CommonVolume.Value).ToString(), Math.Round(MusicVolume.Value).ToString(), Math.Round(SoundVolume.Value).ToString()});
            Console.WriteLine(Math.Round(CommonVolume.Value).ToString(), Math.Round(MusicVolume.Value).ToString(), Math.Round(SoundVolume.Value).ToString());
            
        }

        private void Del_Progress_Clicked(object sender, EventArgs e)
        {
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            ClickSound.Load(stream);
            ClickSound.Volume = Convert.ToDouble(SoundVolume.Value)/10;
            ClickSound.Play();

            Mess_Settings.IsVisible = true;
            SL_Btn.IsVisible = true;
        }

        private void Button_messClicked(object sender, EventArgs e)
        {
            var stream = PersonClass.GetStreamFromFile("ButtSound.mp3");
            Button temp = sender as Button;
            switch (temp.Text)
            {
                case "Хорошо":
                    ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    ClickSound.Load(stream);
                    ClickSound.Volume = Convert.ToDouble(SoundVolume.Value) / 10;
                    ClickSound.Play();

                    string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    File.Delete(Path.Combine(folderPath, "data"));
                    File.Delete(Path.Combine(folderPath, "pcs"));
                    File.Delete(Path.Combine(folderPath, "client"));
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    break;
                case "Отмена":
                    ClickSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    ClickSound.Load(stream);
                    ClickSound.Volume = Convert.ToDouble(SoundVolume.Value) / 10;
                    ClickSound.Play();

                    Mess_Settings.IsVisible = false;
                    SL_Btn.IsVisible = false;
                    break;
            }
        }
    }
}