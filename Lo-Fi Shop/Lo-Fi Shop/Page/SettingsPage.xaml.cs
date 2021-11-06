
using Lo_Fi_Shop.Class;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        PersonClass Music = PersonClass.ReturnPerson();
        public SettingsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            anim.IsAnimationPlaying = true;
            
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
            PersonClass.Write_TXT4(new List<string>{CommonVolume.Value.ToString(), MusicVolume.Value.ToString(), SoundVolume.Value.ToString()});
        }
    }
}