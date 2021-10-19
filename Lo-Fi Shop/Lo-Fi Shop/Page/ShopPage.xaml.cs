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




       
        
        public ShopPage()
        {
            PersonClass Player = PersonClass.OverwriteData();
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
           
             intMoney = Convert.ToInt32(Player.Money.ToString());
            Money.Text = Player.Money.ToString() + "₽";
            //Exp.Text = Player.Exp.ToString() + "exp";
           
        }

        private void Item_Clicked(object sender, EventArgs e)
        {
            
            ImageButton tempBtn = sender as ImageButton;
            if (VideoCard.Id == tempBtn.Id)
            {
                Console.WriteLine(1);
                intSell = 30000;
            }
            else if (CPU.Id == tempBtn.Id)
            {
                Console.WriteLine(2);
                intSell = 10000;
            }
            else if (Kuller.Id == tempBtn.Id)
            {
                Console.WriteLine(3);
                intSell = 800;
            }
            else if (OZU.Id == tempBtn.Id)
            {
                Console.WriteLine(4);
                intSell = 1500;
            }
            else if (MotherBoard.Id == tempBtn.Id)
            {
                Console.WriteLine(5);
                intSell = 9000;
            }
            else if (Corpus.Id == tempBtn.Id)
            {
                Console.WriteLine(6);
                intSell = 500;
            }
            else if (BP.Id == tempBtn.Id)
            {
                Console.WriteLine(7);
                intSell = 5500;

            }
            else if (HDD.Id == tempBtn.Id)
            {
                Console.WriteLine(8);
                intSell = 4500;
            }
            else Console.WriteLine("ИД нет");
            
        }

        private void EmpetyMessage_Clicked(object sender, EventArgs e)
        {
            EmpetyMessage.IsVisible = false;
            BuyInfo.IsVisible = false;
           
        }

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
                Console.WriteLine("Совершаю покупку");
                BuyInfo.Text = "Покупка Успешна!";
                PersonClass Player = PersonClass.OverwriteData();
                Money.Text = Player.Money.ToString() + "₽";
                Navigation.PushAsync(new Page.PlayPage());
            }
        }

    }
}