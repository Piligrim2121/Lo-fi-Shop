using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lo_Fi_Shop.Class;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PlayPage : ContentPage
{
    public PlayPage()
    {
        InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Get_data();

        }
        /// <summary>
        /// Заполнение значений в игровом окне(деньги опыт)
        /// </summary>
        private void Get_data()
        {
            PersonClass Player = PersonClass.OverwriteData();
            Money.Text = Player.Money.ToString() + "₽";
            Exp.Text = Player.Exp.ToString() + "exp";
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
            ImageTableOfQuestOpen.IsVisible = true;
        }
        /// <summary>
        /// Закрытие доски задач
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableOfQuest_Clouse(object sender, EventArgs e)
        {
            ImageTableOfQuestOpen.IsVisible = false;

        }
    }
}