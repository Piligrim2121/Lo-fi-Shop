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