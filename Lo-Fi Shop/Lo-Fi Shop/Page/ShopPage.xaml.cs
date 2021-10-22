using Lo_Fi_Shop.Class;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage
    {
        private int intMoney = 0, intSell = 0;
        private Item SelectItem;
        public ShopPage()
        {
            PersonClass Player = PersonClass.OverwriteData();
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            intMoney = Convert.ToInt32(Player.Money.ToString());
            Money.Text = Player.Money.ToString() + "₽";
        }

        /// <summary>
        /// Выбор предмета для покупки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ImageButton tempBtn;
        private void Item_Clicked(object sender, EventArgs e)
        {
            tempBtn = sender as ImageButton;
            if (VideoCard.Id == tempBtn.Id)
            {
                SelectItem = Item.items[0];
                Console.WriteLine(1);
                intSell = 10000;
                ComponentName.Text = "Начальная Видеокарта";
            }
            else if (CPU.Id == tempBtn.Id)
            {
                SelectItem = Item.items[1];
                Console.WriteLine(2);
                intSell = 6000;
                ComponentName.Text = "Начальный Процессор";

            }
            else if (Kuller.Id == tempBtn.Id)
            {
                Console.WriteLine(3);
                intSell = 300;
                ComponentName.Text = "Начальная Система охлаждения";

            }
            else if (OZU.Id == tempBtn.Id)
            {
                Console.WriteLine(4);
                intSell = 1500;
                ComponentName.Text = "Начальная Оперативная память";

            }
            else if (MotherBoard.Id == tempBtn.Id)
            {
                Console.WriteLine(5);
                intSell = 3000;
                ComponentName.Text = "Начальная Материнская плата";

            }
            else if (Corpus.Id == tempBtn.Id)
            {
                Console.WriteLine(6);
                intSell = 1100;
                ComponentName.Text = "Начальный Корпус";

            }
            else if (BP.Id == tempBtn.Id)
            {
                Console.WriteLine(7);
                intSell = 900;
                ComponentName.Text = "Начальный Блок Питания";
            }
            else if (HDD.Id == tempBtn.Id)
            {
                Console.WriteLine(8);
                intSell = 2500;
                ComponentName.Text = "Начальный Жёсткий диск";

            }
            else
            {
                Console.WriteLine("ИД нет");
                ComponentName.Text = "";
                intSell = 0;
            }

            ComponentPrice.Text = SelectItem.Sell.ToString();
            ComponentName.Text = SelectItem.Name;
        }
        /// <summary>
        /// Закрытие сообщения о покупке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpetyMessage_Clicked(object sender, EventArgs e)
        {
            EmpetyMessage.IsVisible = false;
            BuyInfo.IsVisible = false;
        }
        /// <summary>
        /// Покупка предмета и перенос его в инвентарь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuyBtn_Clicked(object sender, EventArgs e)
        {
            EmpetyMessage.IsVisible = true;
            BuyInfo.IsVisible = true;
            if (intMoney - intSell < 0)
            {
                Console.WriteLine("У пользователя недостаточно денег для данной операции");
                BuyInfo.Text = "Покупка не удалась - недостаточно средств";
            }
            else
            {
                intMoney-= intSell;
                PersonClass.Write_TXT(intMoney);
                BuyInfo.Text = "Покупка успешна!";
                PersonClass Player = PersonClass.OverwriteData();
                Money.Text = Player.Money.ToString() + "₽";
                string TempTXT = ComponentName.Text;
                InventoryPage.AddToInv(TempTXT);
                // Thread.Sleep(2000);
                Navigation.PushAsync(new Page.PlayPage());
            }
        }

    }
}