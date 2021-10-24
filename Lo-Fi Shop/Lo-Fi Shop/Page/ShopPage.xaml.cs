
using Lo_Fi_Shop.Class;
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
        public ShopPage()
        {
            PersonClass Player = PersonClass.ReturnPerson();
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            intMoney = Convert.ToInt32(Player.Money.ToString());
            Money.Text = Player.Money.ToString() + "₽";
        }
        protected override bool OnBackButtonPressed()
        {
            // чё то добавить
            return base.OnBackButtonPressed();
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
                SelectItem = Item.InInvItems[0];
                Console.WriteLine(1);
            }
            else if (CPU.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[1];
                Console.WriteLine(2);
            }
            else if (Kuller.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[2];
                Console.WriteLine(3);
            }
            else if (OZU.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[3];
                Console.WriteLine(4);
            }
            else if (MotherBoard.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[4];
                Console.WriteLine(5);
                

            }
            else if (Corpus.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[5];
                Console.WriteLine(6);
            }
            else if (BP.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[6];
                Console.WriteLine(7); 
            }
            else if (HDD.Id == tempBtn.Id)
            {
                SelectItem = Item.InInvItems[7];
                Console.WriteLine(8);
            }
            else
            {
                Console.WriteLine("ИД нет");
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
            Console.WriteLine("1233213213");
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
            PersonClass player =PersonClass.ReturnPerson();
            EmpetyMessage.IsVisible = true;
            BuyInfo.IsVisible = true;
            
            if(player.InventoryPath.Count>=25)
            {
                BuyInfo.Text = "Покупка не удалась. Инвентарь переполнен комплектующими.";
                return;
            }
            if (ComponentName.Text == "Добро пожаловать!")
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
                    PersonClass.Write_TXT(intMoney);
                    BuyInfo.Text = "Покупка успешна!";
                    PersonClass Player = PersonClass.ReturnPerson();
                    Money.Text = Player.Money.ToString() + "₽";
                    InventoryPage.AddToInv(ComponentName.Text);
                // Thread.Sleep(2000);
                
                    Navigation.PushAsync(new Page.PlayPage());
                }
            
            
        }

    }
}