using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lo_Fi_Shop.Class;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Plugin.SimpleAudioPlayer;
using System.Threading;

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
        public static string AddClientMoney="";
        List<ImageButton> AllBtn = new List<ImageButton>();
        ISimpleAudioPlayer PlaySound;

        public PlayPage()
        {
            InitializeComponent();
            Get_data();
            addMoney.IsVisible = true;
            addMoney.Text = AddClientMoney;
            AddClientMoney = "";
            NavigationPage.SetHasNavigationBar(this, false);
            Device.StartTimer(TimeSpan.FromSeconds(2), Get_data);
            Device.StartTimer(TimeSpan.FromSeconds(2), Win);
            Device.StartTimer(TimeSpan.FromSeconds(2), Lose);
            Device.StartTimer(TimeSpan.FromSeconds(2), Radio);
            //Device.StartTimer(TimeSpan.FromSeconds(2), Anim);
            //Thread.Sleep(500);
            //Device.StartTimer(TimeSpan.FromSeconds(2), Anim2);
            AllBtn.Add((ImageButton)(FindByName("ImageShkaf")));
            AllBtn.Add((ImageButton)(FindByName("ImageTable")));
            AllBtn.Add((ImageButton)(FindByName("ImageTableOfQuest")));
            AllBtn.Add((ImageButton)(FindByName("ImageKassa")));
            AllBtn.Add((ImageButton)(FindByName("Door")));
            rnd = new Random();
            ProverkaClient();
        }
        private void ProverkaClient()
        {
            if (PersonClass.Read_TXT("client") == "")
            {
                Device.StartTimer(TimeSpan.FromSeconds(10), OnTimerTick);
            }
            else
            {
                string[] DataClient = PersonClass.Read_TXT("client").Split(';');
                Client.Source = DataClient[0];
                switch (Client.Source.ToString().Replace("File: ", ""))
                {
                    case @"Resources/drawable/Petka.png":
                        Client.ScaleX = 1;
                        Client.Scale = 0.8;
                        break;
                    case @"Resources/drawable/Vasyok.png":
                        Client.ScaleX = 0.8;
                        Client.Scale = 1;
                        break;
                    case @"Resources/drawable/Arthurka.png":
                        Client.ScaleX = 1;
                        Client.Scale = 0.8;
                        break;
                }
                Answer.Text = DataClient[1];
                MoneyClient = Convert.ToInt32(DataClient[2]);
                Client.IsVisible = true;
                SkyBuy.IsVisible = true;
                Page.QuestPage.zadacha = DataClient[1];
                zakaz = Convert.ToInt32(DataClient[3]);
            }
        }
        bool win = false;
        bool lose = false;
        /// <summary>
        /// Проверка условий победы
        /// </summary>
        /// <returns></returns>
        private bool Win()
        {
            addMoney.IsVisible = false;
            if (!win)
            {
                PersonClass Player = PersonClass.ReturnPerson();
                if (Player.Lvl >= 10 && Player.Money >= 1000000)
                {
                    var stream = PersonClass.GetStreamFromFile("songWin.mp3");
                    PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    PlaySound.Load(stream);
                    PlaySound.Volume = Player.Settings[2];
                    PlaySound.Play();

                    WinButton.IsVisible = true;
                    WinLable.IsVisible = true;
                  
                    WinLable.Text = "Поздравляем, вы победили. Ваш прогресс сохранится, вы можете играть дальше. Ждите новых обновлений!!!";
                    Stonks.IsVisible = true;
                    win = true;
                }
            }
            return !win;
        }
        //public bool Anim()
        //{
        //    Sky.TranslateTo(0, 40, 450);
        //    SkyBuy.TranslateTo(0, 25, 450);
        //    return true;
        //}
        //public bool Anim2()
        //{
        //    SkyBuy.TranslateTo(0, 0, 450);
        //    Sky.TranslateTo(0, 25, 450);
        //    return true;
        //}
        List<int> playedTracs = new List<int>();;
        public bool Radio()
        {
            if (PersonClass.Sleep==false)
            {
                if (PersonClass.Playing == false)
                {
                    if (PersonClass.player.IsPlaying==false)
                    {
                        PersonClass Player = PersonClass.ReturnPerson();
                        string[] radio = new string[] { "music.wav", "StudyBeat.mp3", "MyEyes.mp3", "BackHome.mp3", "FirstGirl.mp3", "StarWars.mp3", "SayAnything.mp3", "TinyEvil.mp3", "LilPeep.mp3", "Chillhop.mp3" };
                        Random r = new Random();
                        int rndint = r.Next(0, radio.Length - 1);
                        Console.WriteLine("rndint " + rndint);
                        bool povtor = true;
                        while (povtor && playedTracs.Count != 0)
                        {
                            Console.WriteLine("dlin " + playedTracs.Count + " radio " + radio.Length);
                            foreach (int item in playedTracs)
                            {

                                Console.WriteLine(rndint + "  " + item);
                                if (rndint == item)
                                {
                                    povtor = true;
                                    break;
                                }
                                else povtor = false;
                            }
                            if (povtor) rndint = r.Next(0, radio.Length - 1);
                            Console.WriteLine("Rnext " + rndint);
                        }
                        playedTracs.Add(rndint);
                        Console.WriteLine($"{playedTracs.Count} == {radio.Length - 1}");
                        if (playedTracs.Count == radio.Length - 1)
                            playedTracs.Clear();

                        Console.WriteLine("dlin2: " + playedTracs.Count);
                        foreach (int item in playedTracs)
                            Console.Write(" " + item);



                        var stream = PersonClass.GetStreamFromFile(radio[rndint]);
                        PersonClass.player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                        PersonClass.player.Load(stream);
                        PersonClass.player.Volume = Player.Settings[1];
                        PersonClass.player.Play();
                    }
                }
            }
            return true;
        }
        private bool Lose()
        {
            if (!lose)
            {
                PersonClass Player = PersonClass.ReturnPerson();
                if (Player.Money <=0)
                {
                   
                    var stream = PersonClass.GetStreamFromFile("songGameOver.mp3");
                    PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    PlaySound.Load(stream);
                    PlaySound.Volume = Player.Settings[2];
                    PlaySound.Play();

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
            Navigation.PopToRootAsync();
            //Navigation.PushAsync(new MainMenuPage());
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
            PersonClass Player = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("songInventory.mp3");
            PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            PlaySound.Load(stream);
            PlaySound.Volume = Player.Settings[2];
            PlaySound.Play();

            Navigation.PushAsync(new Page.InventoryPage(false));
            EnableButton_Closed();
            EnableButton_Opened();
            //Task.Delay(3000).Wait();
            //ImageShkaf.IsEnabled = true;
           
        }
        /// <summary>
        /// Переход к  странице крафта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageTable_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.CraftPage());

            PersonClass Player = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("CraftOpenSound.mp3");
            PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            PlaySound.Load(stream);
            PlaySound.Volume = Player.Settings[2];
            PlaySound.Play();

            EnableButton_Closed();
            EnableButton_Opened();

        }
        
        /// <summary>
        /// Переход к  странице магазина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageKassa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page.ShopPage());

            PersonClass Player = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("KassaOpenSound.mp3");
            PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            PlaySound.Load(stream);
            PlaySound.Volume = Player.Settings[2];
            PlaySound.Play();

            EnableButton_Closed();
            EnableButton_Opened();
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

            PersonClass Player = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("TableOfQuestSound.mp3");
            PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            PlaySound.Load(stream);
            PlaySound.Volume = Player.Settings[2];
            PlaySound.Play();

            EnableButton_Closed();
            EnableButton_Opened();

        }
        /// <summary>
        /// Запуск таймер
        /// </summary>
        /// <returns></returns>
        public bool OnTimerTick()
        {
            PersonClass Player = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("ClientDoorSound.mp3");
            PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            PlaySound.Load(stream);
            PlaySound.Volume = Player.Settings[2];
            PlaySound.Play();

            Random r = new Random();
            switch(r.Next(0, 3))
            {
                case 0:
                    Client.Source = @"Resources/drawable/Petka.png";
                    Client.ScaleX = 1;
                    Client.Scale = 0.8;
                    break;
                case 1:
                    Client.Source = @"Resources/drawable/Vasyok.png";
                    Client.ScaleX = 0.8;
                    Client.Scale = 1;
                    break;
                case 2:
                    Client.Source = @"Resources/drawable/Arthurka.png";
                    Client.ScaleX = 1;
                    Client.Scale = 0.8;
                    break;
            }
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

            PersonClass Player = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("DialogueSound.mp3");
            PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            PlaySound.Load(stream);
            PlaySound.Volume = Player.Settings[2];
            PlaySound.Play();

            zakaz = rnd.Next(1, 3);
            switch (zakaz)
            {
                case 1:
                    if(Convert.ToInt32(lvl.Text) <= 2)
                    {
                        MoneyClient = rnd.Next(26, 35) * 1000;
                        Answer.Text = "Сделаете комп не дороже " + MoneyClient + " рубликов, пожуй листа?";  
                    }
                    else if (Convert.ToInt32(lvl.Text) <= 5)
                    {
                        MoneyClient = rnd.Next(26, 80) * 1000;
                        Answer.Text = "Сделаете комп не дороже " + MoneyClient + " рубликов, пожуй листа?";
                    }
                    else
                    {
                        MoneyClient = rnd.Next(26, 180) * 1000;
                        Answer.Text = "Сделаете комп не дороже " + MoneyClient + " рубликов, пожуй листа?";
                    }
                    break;
                case 2:
                    if (Convert.ToInt32(lvl.Text) <= 2)
                    {
                        MoneyClient = rnd.Next(15, 20) * 1000;
                        Answer.Text = "Сделаете комп дороже " + MoneyClient + " рубликов, пожуй листа? Доплачу 5к за сборку";
                    }
                    else if (Convert.ToInt32(lvl.Text) <= 5)
                    {
                        MoneyClient = rnd.Next(15, 60) * 1000;
                        Answer.Text = "Сделаете комп дороже " + MoneyClient + " рубликов, пожуй листа? Доплачу 5к за сборку";
                    }
                    else
                    {
                        MoneyClient = rnd.Next(15, 150) * 1000;
                        Answer.Text = "Сделаете комп дороже " + MoneyClient + " рубликов, пожуй листа? Доплачу 5к за сборку";
                    }
                    break;
            }
            EnableButton_Closed();
            EnableButton_Opened();
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

                PersonClass Player = PersonClass.ReturnPerson();
                var stream = PersonClass.GetStreamFromFile("QuestSound.mp3");
                PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                PlaySound.Load(stream);
                PlaySound.Volume = Player.Settings[2];
                PlaySound.Play();
                PersonClass.Write_Client(Client.Source.ToString(), Answer.Text, MoneyClient);
            }

            else if (h == false)
            {
                Navigation.PushAsync(new Page.InventoryPage(true));

                PersonClass Player = PersonClass.ReturnPerson();
                var stream = PersonClass.GetStreamFromFile("songInventory.mp3");
                PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                PlaySound.Load(stream);
                PlaySound.Volume = Player.Settings[2];
                PlaySound.Play();
            }

            

            EnableButton_Closed();
            EnableButton_Opened();
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

                    PersonClass Player = PersonClass.ReturnPerson();
                    var stream = PersonClass.GetStreamFromFile("DialogueSound.mp3");
                    PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    PlaySound.Load(stream);
                    PlaySound.Volume = Player.Settings[2];
                    PlaySound.Play();

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
                    PersonClass.Write_Client("delete", "", 0);

                    PersonClass Player = PersonClass.ReturnPerson();
                    var stream = PersonClass.GetStreamFromFile("ClientCloseDoorSound.mp3");
                    PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    PlaySound.Load(stream);
                    PlaySound.Volume = Player.Settings[2];
                    PlaySound.Play();

                    Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(10, 40)), OnTimerTick);
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

                    PersonClass Player = PersonClass.ReturnPerson();
                    var stream = PersonClass.GetStreamFromFile("DialogueSound.mp3");
                    PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    PlaySound.Load(stream);
                    PlaySound.Volume = Player.Settings[2];
                    PlaySound.Play();

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
                    new Page.QuestPage("");
                    PersonClass.Write_Client("delete", "", 0);

                    var stream = PersonClass.GetStreamFromFile("FailSound.mp3");
                    PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    PlaySound.Load(stream);
                    PlaySound.Volume = Player.Settings[2];
                    PlaySound.Play();

                    Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(30, 100)), OnTimerTick);

                }
            }
            EnableButton_Closed();
            EnableButton_Opened();
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

            PersonClass Player = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("DialogueSound.mp3");
            PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            PlaySound.Load(stream);
            PlaySound.Volume = Player.Settings[2];
            PlaySound.Play();

            h = false;
            Answer.Text = "Вы уже сделали комп?";
            EnableButton_Closed();
            EnableButton_Opened();
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
            EnableButton_Closed();
            EnableButton_Opened();
        }
        /// <summary>
        /// Выход в главное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Door_Clicked(object sender, EventArgs e)
        {
            //Door.Source = "DoorOpen.png";
            //Navigation.PushAsync(new MainMenuPage());
            Navigation.PopToRootAsync();
            //Door.Source = "DoorClosed.png";
            //var existingPages = Navigation.NavigationStack.ToList();
            //foreach (var page in existingPages)
            //{
            //    Navigation.RemovePage(page);
            //}
            EnableButton_Closed();
            EnableButton_Opened();
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
                File.Delete(Path.Combine(folderPath, "client"));
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            WinLable.IsVisible = false;
            WinButton.IsVisible = false;
            Kotik.IsVisible = false;
            Stonks.IsVisible = false;
            EnableButton_Closed();
            EnableButton_Opened();
        }
        private async void EnableButton_Opened()
        {
            await Task.Delay(1000);
            for(int i = 0; i < AllBtn.Count; i++)
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
        private void Okno_Clicked(object sender, EventArgs e)
        {
            PersonClass Player = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("WindowSound.mp3");
            PlaySound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            PlaySound.Load(stream);
            PlaySound.Volume = Player.Settings[2];
            PlaySound.Play();
        }
    }
}