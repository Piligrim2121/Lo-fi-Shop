﻿using System;
using Lo_Fi_Shop.Class;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Lo_Fi_Shop.Page;

namespace Lo_Fi_Shop
{
    public partial class MainMenuPage : ContentPage
    {
        /// <summary>
        /// Инициализация компонентов и загрузка главного меню 
        /// </summary>
        public MainMenuPage()
        {
            InitializeComponent();
            PersonClass.First_Write_TXT();
            NavigationPage.SetHasNavigationBar(this, false);
            ImageLogotip.IsAnimationPlaying = true;
            
        }
      
        /// <summary>
        /// Переход к экрану "Как Играть"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHowToPlay_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.HowToPlayPage());
        }
        /// <summary>
        /// Переход к главному  экрану игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_Clicked(object sender, EventArgs e)
        {
        Navigation.PushAsync(new Page.PlayPage());
        // Navigation.PushAsync(new Page.TempPage());
        }
        /// <summary>
        /// Переход к экрану "Настройки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetting_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.SettingsPage());
        }
        /// <summary>
        /// Переход к экрану "Об авторах"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.AboutAuthorsPage());
        }
        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        

        // Метод для фоновой музыки
    }
}
