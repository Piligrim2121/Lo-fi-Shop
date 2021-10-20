using System;
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
        private void Get_data()
        {
            PersonClass Player = PersonClass.OverwriteData();
            Money.Text = Player.Money.ToString() + "₽";
            lvl.Text = (Math.Floor(Convert.ToDouble(Player.Exp) / 10 + 1)).ToString() + "lvl";
            Exp.Progress = (Player.Exp - (Convert.ToInt32(lvl.Text.Replace("lvl", "")) - 1) * 10) / 10;
        }
        /// <summary> 
        /// Открытие инвентаря
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageShkaf_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.InventoryPage());
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
            SkyBuy.IsVisible = true;
            Dialog.IsVisible = true;
            Answer.IsVisible=true;
            GridBtn.IsVisible= true;
            MoneyClient = rnd.Next(50000, 150000);
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
                Navigation.PushAsync(new Page.QuestPage(Answer.Text));
                // Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(50, 100)), OnTimerTick);
                h = false;
            }

            else if (h == false)
            {
                Dialog.IsVisible = false;
                Answer.IsVisible = false;
                GridBtn.IsVisible = false;
                int M = Convert.ToInt32(Money.Text) + MoneyClient;
                Money.Text = M.ToString();
                PersonClass.Write_TXT(M);
                Alive = true;
                Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(50, 100)), OnTimerTick);
                h = true;
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
                    Sky.IsVisible = false;
                    Alive = true;
                    Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(50, 200)), OnTimerTick);
                    h = false;
                }

            }

            if (h == false)
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
                    Sky.IsVisible = false;
                    Alive = true;
                    Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(50, 200)), OnTimerTick);
                    h = true;
                }
            }
           
        }

        private void SkyBuy_Clicked(object sender, EventArgs e)
        {
            SkyBuy.IsVisible = false;
            Dialog.IsVisible = true;
            Answer.IsVisible = true;
            GridBtn.IsVisible = true;
            Answer.Text = "Вы сделали комп за " + MoneyClient + " ?";
        }
    }
}