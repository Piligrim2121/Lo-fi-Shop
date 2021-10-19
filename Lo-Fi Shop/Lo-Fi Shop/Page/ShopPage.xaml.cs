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
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            PersonClass Player = PersonClass.OverwriteData();
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
            }
            else if (CPU.Id == tempBtn.Id)
            {
                Console.WriteLine(2);
            }
            else if (Kuller.Id == tempBtn.Id)
            {
                Console.WriteLine(3);
            }
            else if (OZU.Id == tempBtn.Id)
            {
                Console.WriteLine(4);
            }
            else if (MotherBoard.Id == tempBtn.Id)
            {
                Console.WriteLine(5);
            }
            else if (Corpus.Id == tempBtn.Id)
            {
                Console.WriteLine(6);
            }
            else if (BP.Id == tempBtn.Id)
            {
                Console.WriteLine(7);

            }
            else if (HDD.Id == tempBtn.Id)
            {
                Console.WriteLine(8);
            }
            else Console.WriteLine("ИД нет");
            
        }

        private void BuyBtn_Clicked(object sender, EventArgs e)
        {
            if (intMoney - intSell < 0)
            {
                Console.WriteLine("У пользователя недостаточно денег для данной операции");
            }
            else 
            {
                Console.WriteLine("Совершаю покупку");
            }
        }

    }
}