﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lo_Fi_Shop.Class;
using static System.Math;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PlayPage : ContentPage
{
        bool Alive = true;
        bool h = true;
        public Item[] MassAllItems = Item.CreateItems();
        private Random rnd;
        private int MoneyClient;
        private int Level ;
        public PlayPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Get_data();
            Device.StartTimer(TimeSpan.FromSeconds(10), OnTimerTick);
            /*var assembly = typeof(App).GetTypeInfo().Assembly;
            System.IO.Stream audioStream = assembly.GetManifestResourceStream("Resources/drawable/" + "play.mp3");


            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);
            player.Play();*/
            rnd = new Random();
        }
        /// <summary>
        /// Заполнение значений в игровом окне(деньги опыт)
        /// </summary>
        /// 

       

        private void Get_data()
        {
            PersonClass Player = PersonClass.OverwriteData();
            Money.Text = Player.Money.ToString() + "₽";
            Level = Player.Lvl;
            lvl.Text = Level + " lvl";
            //lvl.Text = (Math.Floor(Convert.ToDouble(Player.Exp) / 100 + 1)).ToString() + "lvl";
            //if((Player.Exp - (100 * Level)) / 100 >= Level - 1)
            if (Player.Exp >= (100* Level))
            {
                Level++;
                lvl.Text = Level + " lvl";
                PersonClass.Write_TXT3(Level);
                PersonClass.Write_TXT2(0);
                Player = PersonClass.OverwriteData();
            }
            Exp.Progress = Convert.ToDouble(Player.Exp) / (100 * Level);
        }
        /// <summary> 
        /// Открытие инвентаря
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageShkaf_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.InventoryPage(false));
        }
        /// <summary>
        /// Переход к  странице крафта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageTable_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.CraftPage());
        }
        /// <summary>
        /// Переход к  странице магазина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageKassa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.ShopPage());
        }
        /// <summary>
        /// Открытие доски задач
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableOfQuest_Open(object sender, EventArgs e)
        {
            //ImageTableOfQuestOpen.IsVisible = true;
            Navigation.PushAsync(new Page.QuestPage());
        }
        /// <summary>
        /// Закрытие доски задач
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void TableOfQuest_Clouse(object sender, EventArgs e)
        //{
            //ImageTableOfQuestOpen.IsVisible = false;

        //}

        // Таймер
        private bool OnTimerTick()
        {
            Client.IsVisible = true;
            Sky.IsVisible = true;
            Alive = false;
            return Alive;
        }

        private void Sky_Clicked(object sender, EventArgs e)
        {                  
            Sky.IsVisible = false;
            Dialog.IsVisible = true;
            Answer.IsVisible=true;
            h = true;
            GridBtn.IsVisible= true;
            MoneyClient = rnd.Next(20000, 30000);
            Answer.Text = "Сделаете комп за " + MoneyClient + ", пожуй листа?";
        }

        private void ButtonYes_Clicked(object sender, EventArgs e)
        {
            if (h == true)
            {
                Dialog.IsVisible = false;
                Answer.IsVisible = false;
                GridBtn.IsVisible = false;                                
                Alive = true;
                SkyBuy.IsVisible = true;
                Navigation.PushAsync(new Page.QuestPage(Answer.Text));

            }

            else if (h == false)
            {
                Navigation.PushAsync(new Page.InventoryPage(true));
                //Client.IsVisible = false;
                //Dialog.IsVisible = false;
                //Answer.IsVisible = false;
                //GridBtn.IsVisible = false;
                //int M = Convert.ToInt32(Money.Text.Replace("₽","")) + MoneyClient;
                //Money.Text = M.ToString() + "₽";
                //PersonClass Player = PersonClass.OverwriteData();
                //PersonClass.Write_TXT2(Convert.ToInt32(Player.Exp + 30));
                //if (Player.Exp >= (100 * Level - 1))
                //{
                //    PersonClass.Write_TXT3(Level);
                //    PersonClass.Write_TXT2(0);
                //}
                //PersonClass.Write_TXT(M);
                //Get_data();
                //Alive = true;
                //Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(30, 100)), OnTimerTick);
            }
        }

        private void ButtonNo_Clicked(object sender, EventArgs e)
        {
            if (h == true)
            {
                if (ButtonNo.Text == "Нет")
                {
                    ButtonNo.Text = "Ок";
                    ButtonYes.IsVisible = false;
                    Answer.Text = "Ну ладно, хорошее обслуживание, всем бомжам советовать буду";

                }

                else if (ButtonNo.Text == "Ок")
                {
                    ButtonYes.IsVisible = true;
                    Dialog.IsVisible = false;
                    Answer.IsVisible = false;
                    GridBtn.IsVisible = false;
                    Client.IsVisible = false;
                    ButtonNo.Text = "Нет";
                    Alive = true;
                    Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(30, 100)), OnTimerTick);
                    
                }

            }

            if (h == false)
            {
                if (ButtonNo.Text == "Нет")
                {
                    ButtonNo.Text = "Ок";
                    ButtonYes.IsVisible = false;
                    Answer.Text = "Ну ладно, хорошее обслуживание, всем бомжам советовать буду";
                    ButtonHide.IsVisible = true;

                }

                else if (ButtonNo.Text == "Ок")
                {
                    ButtonYes.IsVisible = true;
                    Dialog.IsVisible = false;
                    Answer.IsVisible = false;
                    ButtonHide.IsVisible = false;
                    GridBtn.IsVisible = false;
                    Client.IsVisible = false;
                    ButtonNo.Text = "Нет";
                    Alive = true;
                    Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(30, 100)), OnTimerTick);
                    
                }
            }
           
        }

        private void SkyBuy_Clicked(object sender, EventArgs e)
        {
            SkyBuy.IsVisible = false;
            Dialog.IsVisible = true;
            Answer.IsVisible = true;
            GridBtn.IsVisible = true;
            
            h = false;
            Answer.Text = "Вы сделали комп за " + MoneyClient + " ?";
        }

        private void ButtonHide_Clicked(object sender, EventArgs e)
        {
            SkyBuy.IsVisible = true;
            ButtonYes.IsVisible = true;
            ButtonHide.IsVisible = false;
            Dialog.IsVisible = false;
            Answer.IsVisible = false;
            GridBtn.IsVisible = false;

            ButtonYes.Text = "Да";
            ButtonNo.Text = "Нет";
        }
    }
}