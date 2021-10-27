using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lo_Fi_Shop.Class;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayPage : ContentPage
    {
        bool Alive = true;
        bool h = true;
        public Item[] MassAllItems = Item.CreateItems();
        private Random rnd;
        public static int zakaz;
        public static int MoneyClient;
        private int Level;
        public PlayPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Device.StartTimer(TimeSpan.FromSeconds(10), OnTimerTick);
            Device.StartTimer(TimeSpan.FromSeconds(2), Get_data);
            Device.StartTimer(TimeSpan.FromSeconds(2), Win);
            Device.StartTimer(TimeSpan.FromSeconds(2), Lose);
            /*var assembly = typeof(App).GetTypeInfo().Assembly;
            System.IO.Stream audioStream = assembly.GetManifestResourceStream("Resources/drawable/" + "play.mp3");
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);
            player.Play();*/
            rnd = new Random();
        }
        bool win = false;
        bool lose = false;
        /// <summary>
        /// Проверка условий победы
        /// </summary>
        /// <returns></returns>
        private bool Win()
        {
            if (!win)
            {
                PersonClass Player = PersonClass.ReturnPerson();
                if (Player.Lvl >= 10 && Player.Money >= 1000000)
                {
                    WinButton.IsVisible = true;
                    WinLable.IsVisible = true;
                  
                    WinLable.Text = "Поздравляем, вы победили. Ваш прогресс сохранится, вы можете играть дальше. Ждите новых обновлений!!!";
                    Stonks.IsVisible = true;
                    win = true;
                }
            }
            return !win;
        }
        private bool Lose()
        {
            if (!lose)
            {
                PersonClass Player = PersonClass.ReturnPerson();
                if (Player.Money <=0)
                {
                    WinButton.IsVisible = true;
                    WinLable.IsVisible = true;
                    WinLable.Text = "Вы потратили все свои деньги и проиграли!" +"\n"+"Игра закроется и весь накопленный прогресс будет утерян. Впредь продумывайте свои действия наперёд. ";
                    Kotik.IsVisible = true;
                    lose = true;
                }
            }
            return !lose;
        }
        /// <summary>
        /// Переход в Главное меню
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new MainMenuPage());
            return true;
        }

        /// <summary>
        /// Заполнение значений в игровом окне(деньги опыт)
        /// </summary>
        /// 
        public bool Get_data()
        {
            PersonClass Player = PersonClass.ReturnPerson();
            Money.Text = Player.Money.ToString() + "₽";
            Level = Player.Lvl;
            lvl.Text = Level.ToString();
            //lvl.Text = (Math.Floor(Convert.ToDouble(Player.Exp) / 100 + 1)).ToString() + "lvl";
            //if((Player.Exp - (100 * Level)) / 100 >= Level - 1)
            if (Player.Exp >= (100 * Level))
            {
                Level++;
                lvl.Text = Level.ToString();
                PersonClass.Write_TXT3(Level);
                PersonClass.Write_TXT2(0);
                Player = PersonClass.ReturnPerson();
            }
            Exp.Progress = Convert.ToDouble(Player.Exp) / (100 * Level);
            return true;
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
        /// Запуск таймер
        /// </summary>
        /// <returns></returns>
        private bool OnTimerTick()
        {
            Client.IsVisible = true;
            Sky.IsVisible = true;
            Alive = false;
            return Alive;
        }
        /// <summary>
        /// вывод диалогового окна с покупателем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sky_Clicked(object sender, EventArgs e)
        {
            Sky.IsVisible = false;
            Dialog.IsVisible = true;
            Answer.IsVisible = true;
            h = true;
            GridBtn.IsVisible = true;
            zakaz = rnd.Next(1, 2);
            switch (zakaz)
            {
                case 1:
                    MoneyClient = rnd.Next(26, 35) * 1000;
                    Answer.Text = "Сделаете комп не дороже " + MoneyClient + " рубликов, пожуй листа?";
                    break;
                case 2:
                    MoneyClient = rnd.Next(15, 25) * 1000;
                    Answer.Text = "Сделаете комп дороже " + MoneyClient + " рубликов, пожуй листа?";
                    break;
            }
        }
        /// <summary>
        /// Принятие задание покупателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
        }
        /// <summary>
        /// Отказ задания покупателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    PersonClass Player = PersonClass.ReturnPerson();
                    int LastExp = Player.Exp;
                    Console.WriteLine(LastExp);
                    if ((LastExp - 30) <= 0)
                    {
                        Console.WriteLine(100 * (Level - 1) - LastExp);
                        PersonClass.Write_TXT2(100 * (Level - 1) - LastExp);
                        PersonClass.Write_TXT3(Level - 1);
                    }
                    else
                    {
                        if(!(Player.Lvl == 1 && Player.Exp < 30))
                        PersonClass.Write_TXT2(LastExp - 30);
                    }
                    Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(30, 100)), OnTimerTick);

                }
            }

        }
        /// <summary>
        /// Диалоговое окно о продаже
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkyBuy_Clicked(object sender, EventArgs e)
        {
            SkyBuy.IsVisible = false;
            Dialog.IsVisible = true;
            Answer.IsVisible = true;
            GridBtn.IsVisible = true;

            h = false;
            Answer.Text = "Вы сделали комп за " + MoneyClient + " ?";
        }
        /// <summary>
        /// скрытие диалогвого окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Выход в главное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Door_Clicked(object sender, EventArgs e)
        {
            Door.Source = "DoorOpen.png";
            Navigation.PushAsync(new MainMenuPage());
            Door.Source = "DoorClosed.png";
        }
        /// <summary>
        /// Закрытие окна о победе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinButton_Clicked(object sender, EventArgs e)
        {
            if (lose)
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                File.Delete(Path.Combine(folderPath, "data"));
                File.Delete(Path.Combine(folderPath, "pcs"));
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            WinLable.IsVisible = false;
            WinButton.IsVisible = false;
            Kotik.IsVisible = false;
            Stonks.IsVisible = false;
        }
    }
}