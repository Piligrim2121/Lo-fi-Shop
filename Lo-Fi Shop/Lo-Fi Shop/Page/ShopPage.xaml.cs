﻿using Lo_Fi_Shop.Class;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage
    {
        private int intMoney = 0, intSell = 0;

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
        private void Item_Clicked(object sender, EventArgs e)
        {
            ImageButton tempBtn = sender as ImageButton;
            if (VideoCard.Id == tempBtn.Id)
            {
                Console.WriteLine(1);
                intSell = 30000;
                ComponentName.Text = "Видеокарта";
            }
            else if (CPU.Id == tempBtn.Id)
            {
                Console.WriteLine(2);
                intSell = 10000;
                ComponentName.Text = "Процессор";

            }
            else if (Kuller.Id == tempBtn.Id)
            {
                Console.WriteLine(3);
                intSell = 800;
                ComponentName.Text = "Система охлаждения";

            }
            else if (OZU.Id == tempBtn.Id)
            {
                Console.WriteLine(4);
                intSell = 1500;
                ComponentName.Text = "Оперативная память";

            }
            else if (MotherBoard.Id == tempBtn.Id)
            {
                Console.WriteLine(5);
                intSell = 9000;
                ComponentName.Text = "Материнская плата";

            }
            else if (Corpus.Id == tempBtn.Id)
            {
                Console.WriteLine(6);
                intSell = 500;
                ComponentName.Text = "Корпус";

            }
            else if (BP.Id == tempBtn.Id)
            {
                Console.WriteLine(7);
                intSell = 5500;
                ComponentName.Text = "Блок Питания";
            }
            else if (HDD.Id == tempBtn.Id)
            {
                Console.WriteLine(8);
                intSell = 4500;
                ComponentName.Text = "Жёсткий диск";

            }
            else
            {
                Console.WriteLine("ИД нет");
                ComponentName.Text = "";
                intSell = 0;
            }

            ComponentPrice.Text = intSell.ToString() + "₽";
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
                intMoney = intMoney - intSell;
                PersonClass.Write_TXT(intMoney);
                BuyInfo.Text = "Покупка Успешна!";
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