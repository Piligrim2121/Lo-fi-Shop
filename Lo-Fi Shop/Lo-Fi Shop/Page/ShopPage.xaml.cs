
using Lo_Fi_Shop.Class;
using Plugin.SimpleAudioPlayer;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage
    {

        private Item SelectItem;
        private int intMoney;
        ISimpleAudioPlayer kassa_sound;
        public ShopPage()
        {

            PersonClass Player = PersonClass.ReturnPerson();
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            intMoney = Convert.ToInt32(Player.Money.ToString());
            Money.Text = Player.Money.ToString() + "₽";
           
            if (Player.Lvl >= 3)
            {
                for (int i = 36; i < 44; i++)
                    Shop_Grid.Children[i].IsVisible = false;
            }
            if (Player.Lvl >= 6)
            {
                for (int i = 28; i < 36; i++)
                    Shop_Grid.Children[i].IsVisible = false;
            }
        }
        //protected override bool OnBackButtonPressed()
        //{
        //    // чё то добавить
        //    //return base.OnBackButtonPressed
        //    Navigation.PushAsync(new Page.PlayPage());
        //    return true;
        //}

        /// <summary>
        /// Выбор предмета для покупки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ImageButton tempBtn;
        private void Item_Clicked(object sender, EventArgs e)
        {
            tempBtn = sender as ImageButton;

            PersonClass Player = PersonClass.ReturnPerson();
            var stream = PersonClass.GetStreamFromFile("ClickSound.mp3");
            kassa_sound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            kassa_sound.Load(stream);
            kassa_sound.Volume = Player.Settings[2];
            kassa_sound.Play();

            if (VideoCard.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[0];
                ComponentName.TextColor = Color.White;
                Console.WriteLine(1);
            }
            else if (CPU.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[1];
                ComponentName.TextColor = Color.White;
                Console.WriteLine(2);
            }
            else if (Kuller.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[2];
                ComponentName.TextColor = Color.White;
                Console.WriteLine(3);
            }
            else if (OZU.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[3];
                ComponentName.TextColor = Color.White;
                Console.WriteLine(4);
            }
            else if (MotherBoard.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[4];
                ComponentName.TextColor = Color.White;
                Console.WriteLine(5);


            }
            else if (Corpus.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[5];
                ComponentName.TextColor = Color.White;
                Console.WriteLine(6);
            }
            else if (BP.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[6];
                ComponentName.TextColor = Color.White;
                Console.WriteLine(7);
            }
            else if (HDD.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[7];
                ComponentName.TextColor = Color.White;
                Console.WriteLine(8);
            }
            //Medium
          else if (MediumVideoCard.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[8];
                ComponentName.TextColor = Color.LightBlue;
                Console.WriteLine(1);
            }
            else if (MediumCPU.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[9];
                ComponentName.TextColor = Color.LightBlue;
                Console.WriteLine(2);
            }
            else if (MediumKuller.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[10];
                ComponentName.TextColor = Color.LightBlue;
                Console.WriteLine(3);
            }
            else if (MediumOZU.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[11];
                ComponentName.TextColor = Color.LightBlue;
                Console.WriteLine(4);
            }
            else if (MediumMotherBoard.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[12];
                ComponentName.TextColor = Color.LightBlue;
                Console.WriteLine(5);


            }
            else if (MediumCorpus.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[13];
                ComponentName.TextColor = Color.LightBlue;
                Console.WriteLine(6);
            }
            else if (MediumBP.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[14];
                ComponentName.TextColor = Color.LightBlue;
                Console.WriteLine(7);
            }
            else if (MediumHDD.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[15]; 
                ComponentName.TextColor = Color.LightBlue;
                Console.WriteLine(8);
            }
            //Hard
           else if (HardVideoCard.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[16];
                ComponentName.TextColor = Color.Gold;
                Console.WriteLine(1);
            }
            else if (HardCPU.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[17];
                ComponentName.TextColor = Color.Gold;
                Console.WriteLine(2);
            }
            else if (HardKuller.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[18];
                ComponentName.TextColor = Color.Gold;
                Console.WriteLine(3);
            }
            else if (HardOZU.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[19];
                ComponentName.TextColor = Color.Gold;
                Console.WriteLine(4);
            }
            else if (HardMotherBoard.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[20];
                ComponentName.TextColor = Color.Gold;
                Console.WriteLine(5);


            }
            else if (HardCorpus.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[21];
                ComponentName.TextColor = Color.Gold;
                Console.WriteLine(6);
            }
            else if (HardBP.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[22];
                ComponentName.TextColor = Color.Gold;
                Console.WriteLine(7);
            }
            else if (HardHDD.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[23];
                ComponentName.TextColor = Color.Gold;
                Console.WriteLine(8);
            }
            else
            {
                Console.WriteLine("ИД нет");
                ComponentName.TextColor = Color.White;
                ComponentName.Text = default;
                return;
            }

            ComponentPrice.Text = SelectItem.Sell.ToString() + "₽";
            ComponentName.Text = SelectItem.Name;
            Console.WriteLine(SelectItem.Name + SelectItem.Sell + SelectItem.Path);
        }
        /// <summary>
        /// Закрытие сообщения о покупке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpetyMessage_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("<попытка закрытия окна  пользователем>");

            EmpetyMessage.IsVisible = false;
            BuyInfo.IsVisible = false;
            messageShow = false;

        }
        private bool MessageHide()
        {
            Console.WriteLine("<попытка закрытия окна  таймером>");
            if (messageShow)
            {
                EmpetyMessage.IsVisible = false;
                BuyInfo.IsVisible = false;
                messageShow = false;
            }

            return false;
        }
        bool messageShow;
        /// <summary>
        /// Покупка предмета и перенос его в инвентарь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyBtn_Clicked(object sender, EventArgs e)
        {
            messageShow = true;
            PersonClass player = PersonClass.ReturnPerson();
            EmpetyMessage.IsVisible = true;
            BuyInfo.IsVisible = true;

            if (player.InventoryPath.Count >= 25)
            {
                BuyInfo.Text = "Покупка не удалась. Инвентарь переполнен комплектующими.";
                return;
            }
            if ((ComponentName.Text == "Добро пожаловать!")||(ComponentName.Text== "Недоступно на текущем уровне"))
            {
                BuyInfo.Text = "Покупка не удалась. Не выбран предмет для покупки.";
                return;
            }
            if (intMoney - SelectItem.Sell < 0)
            {
                Console.WriteLine("У пользователя недостаточно денег для данной операции");
                BuyInfo.Text = "Покупка не удалась - недостаточно средств";
            }
            else
            {

                intMoney = intMoney - SelectItem.Sell;
                ChangeMoney.Text = "-" + SelectItem.Sell.ToString() + "₽";
                ChangeMoney.IsVisible = true;
                Device.StartTimer(TimeSpan.FromSeconds(2), () => {
                    ChangeMoney.IsVisible = false;
                    return false;
                });
                PersonClass.Write_TXT(intMoney);
                
                var stream = PersonClass.GetStreamFromFile("songKassa.mp3");
                kassa_sound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                kassa_sound.Load(stream);
                kassa_sound.Volume = player.Settings[2];
                kassa_sound.Play();
                BuyInfo.Text = "Покупка успешна!";
                PersonClass Player = PersonClass.ReturnPerson();
                Money.Text = Player.Money.ToString() + "₽";
                InventoryPage.AddToInv(ComponentName.Text);
                //Navigation.PushAsync(new Page.PlayPage());
            }
            Device.StartTimer(TimeSpan.FromSeconds(2), MessageHide);

        }

        private void ClosedLVL(object sender, EventArgs e)
        {
            ComponentName.TextColor = Color.White;
            ComponentName.Text = "Недоступно на текущем уровне";
            ComponentPrice.Text = "";
        }
    }
}