using Lo_Fi_Shop.Class;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryPage : ContentPage
    {
        public InventoryPage(bool Da = false)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


            if (Da)
            {
                Obvodka1.Source = null;
                Obvodka2.Source = "Resource/drawable/Obvodka.png";
            }
            else
            {
                Obvodka1.Source = "Resource/drawable/Obvodka.png";
            }
            Prod = Da;


            DisplayInvPath();
            if (Inv_Grid.Children.Count > 0)
            {
                CP_Inv.BackgroundImageSource = "Resources/drawable/InventoryDefault.png";

            }
            else if (Inv_Grid.Children.Count == 0)
            {
                CP_Inv.BackgroundImageSource = "Resources/drawable/EmptyInventory.png";

            }
        }
        ImageButton tempBtn;
        public static List<string> InvPart { get; set; }
        bool Prod = false;
        private void TestVideoCard_Clicked(object sender, EventArgs e)
        {
            tempBtn = sender as ImageButton;

            if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[0].Path)
            {
                Description.Text = Item.InInvItems[0].Description;
                Info_name.Text = Item.InInvItems[0].Name;
                Cost.Text = Item.InInvItems[0].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[1].Path)
            {
                Description.Text = Item.InInvItems[1].Description;
                Info_name.Text = Item.InInvItems[1].Name;
                Cost.Text = Item.InInvItems[1].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[2].Path)
            {
                Description.Text = Item.InInvItems[2].Description;
                Info_name.Text = Item.InInvItems[2].Name;
                Cost.Text = Item.InInvItems[2].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[3].Path)
            {
                Description.Text = Item.InInvItems[3].Description;
                Info_name.Text = Item.InInvItems[3].Name;
                Cost.Text = Item.InInvItems[3].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[4].Path)
            {

                Description.Text = Item.InInvItems[4].Description;
                Info_name.Text = Item.InInvItems[4].Name;
                Cost.Text = Item.InInvItems[4].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[5].Path)
            {
                Description.Text = Item.InInvItems[5].Description;
                Info_name.Text = Item.InInvItems[5].Name;
                Cost.Text = Item.InInvItems[5].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[6].Path)
            {
                Description.Text = Item.InInvItems[6].Description;
                Info_name.Text = Item.InInvItems[6].Name;
                Cost.Text = Item.InInvItems[6].Sell.ToString() + "₽";
            }
            else if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[7].Path)
            {
                Description.Text = Item.InInvItems[7].Description;
                Info_name.Text = Item.InInvItems[7].Name;
                Cost.Text = Item.InInvItems[7].Sell.ToString() + "₽";
            }
            //switch ((sender as ImageButton).GetType().GUID.ToString())
            //{
            //    case "00000000-0000-0000-0000-000000000000":
            //        Console.WriteLine("lol");
            //        break;
            //}
        }
        private void PC_Clicked(object sender, EventArgs e)
        {

        }

        private void DisplayInvPath()
        {
            Description.Text = "";
            Info_name.Text = "";
            Cost.Text = "";
            //int lol=-20;
            Inv_Grid.Children.Clear();
            if (Obvodka1.Source != null)
            {
                PersonClass Player = PersonClass.ReturnPerson();
                InvPart = Player.InventoryPath;

                int LenInv = 0;
                foreach (string i in InvPart)
                {
                    if (i == "")
                    {
                        continue;
                    }
                    for (int c = 0; c < Item.InInvItems.Length; c++)
                    {
                        if (i == Item.InInvItems[c].Name)
                        {
                            Color color = Color.Transparent;
                            //if (LenInv <= 8)
                            //    color = Color.Red;
                            ImageButton imageButton = new ImageButton { Margin = new Thickness(20, 0, 0, 0), Source = Item.InInvItems[c].Path, BackgroundColor = color };
                            //if(LenInv%5==0)
                            //lol += 20;
                            imageButton.Clicked += TestVideoCard_Clicked;
                            Inv_Grid.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5) + 1, ((LenInv / 5)));
                        }
                    }
                    LenInv++;
                }
                LenInv = 0;
            }
            else
            {
               
                PersonClass Player = PersonClass.ReturnPerson();
                InvPart = Player.InventoryWhole;
                int LenInv = 0;
                foreach (string i in InvPart)
                {
                    if (i == "")
                    {
                        continue;
                    }
                    for (int c = 0; c < Item.CreatePC().Length; c++) {
                        if (i == Item.CreatePC()[c].Name) {
                            ImageButton imageButton = new ImageButton { Source = Item.CreatePC()[c].Path, BackgroundColor = Color.Transparent };
                            imageButton.Clicked += PC_Clicked;
                            Inv_Grid.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5) + 1, ((LenInv / 5)));
                        }
                    }
                      
                    LenInv++;
                }
                LenInv = 0;
            }
        }
        public static void AddToInv(string Part)
        {
            //InvPart = new List<string>();    
            PersonClass Player = PersonClass.ReturnPerson();
            InvPart = Player.InventoryPath;
            InvPart.Add(Part);
            PersonClass.Write_TXT(InvPart);
        }

        private void Obvodka_Clicked(object sender, EventArgs e)
        {
            
            if (Obvodka1.Source == null)
            {
                if (!Prod)
                {
                    Description.Text = "";
                    Info_name.Text = "";
                    Cost.Text = "";
                    Obvodka1.Source = "Resource/drawable/Obvodka.png";
                    Obvodka2.Source = null;
                    
                    DisplayInvPath();
                }
            }
        }

        private void Obvodka2_Clicked(object sender, EventArgs e)
        {

            if (Obvodka2.Source == null)
            {
                Description.Text = "";
                Info_name.Text = "";
                Cost.Text = "";
                Obvodka1.Source = null;
                Obvodka2.Source = "Resource/drawable/Obvodka.png";
                
                DisplayInvPath();
            }
        }

        private void Sell_Clicked(object sender, EventArgs e)
        {
            if (Prod)
            {
                // проверка на выбранный пк потом:

                //Client.IsVisible = false;
                //Dialog.IsVisible = false;
                //Answer.IsVisible = false;
                //GridBtn.IsVisible = false;
                //int M = Convert.ToInt32(Money.Text.Replace("₽","")) + MoneyClient;
                //Money.Text = M.ToString() + "₽";
                //PersonClass Player = PersonClass.OverwriteData();
                //PersonClass.Write_TXT2(Convert.ToInt32(Player.Exp + 30));
                //if (Player.Exp >= (100 * Level - 1))
                //{
                //    PersonClass.Write_TXT3(Level);
                //    PersonClass.Write_TXT2(0);
                //}
                //PersonClass.Write_TXT(M);
                //Get_data();
                //Alive = true;
                //Device.StartTimer(TimeSpan.FromSeconds(rnd.Next(30, 100)), OnTimerTick);
            }
            else
            {
                // Продаем выбранный компонент за 70% от себестоимости
            }
        }
    }
}
