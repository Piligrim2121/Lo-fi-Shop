using Lo_Fi_Shop.Class;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static List<Item> InvPC { get; set; }
        bool Prod = false;
        /// <summary>
        /// Вывод информации о компонентах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElementCliced(object sender, EventArgs e)
        {
            tempBtn = sender as ImageButton;
            for (int i = 0; i < Item.InInvItems.Length; i++)
            {
                if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[i].Path)
                {
                    Description.Text = Item.InInvItems[i].Description;
                    Info_name.Text = Item.InInvItems[i].Name;
                    Cost.Text = Item.InInvItems[i].Sell.ToString() + "₽";
                }
            }
            DopB = true;
        }
       /// <summary>
       /// Отображение информации о собранном ПК
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void PC_Clicked(object sender, EventArgs e)
        {
            tempBtn = sender as ImageButton;
            for (int i = 0; i < InvPC.Count; i++)
            {
                if (tempBtn.Source.ToString().Replace("File: ", "") == InvPC[i].Path)
                {
                    Description.Text = InvPC[i].Description;
                    Info_name.Text = InvPC[i].Name;
                    Cost.Text = InvPC[i].Sell.ToString() + "₽";
                }
            }
            DopB = true;
        }
        /// <summary>
        /// Отображение содержимого инвентаря
        /// </summary>
        private void DisplayInvPath()
        {
            InvPC = new List<Item>();
            Description.Text = "";
            Info_name.Text = "";
            Cost.Text = "";
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
                            ImageButton imageButton = new ImageButton { Margin = new Thickness(20, 0, 0, 0), Source = Item.InInvItems[c].Path, BackgroundColor = color };
                            imageButton.Clicked += ElementCliced;
                            Inv_Grid.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5) + 1, ((LenInv / 5)));
                        }
                    }
                    LenInv++;
                }
                LenInv = 0;
            }
            else
            {
                string pcs = PersonClass.Read_PC();
                int LenInv = 0;
                foreach (string i in pcs.Split('*'))
                {
                    if (i == "")
                    {
                        continue;
                    }
                    //for (int c = 0; c < Item.PC.Count; c++)
                    //{
                    //if (i == "Name:"+Item.PC[c].Name+";"+"Cost:"+Item.PC[c].Sell+";"+"Source:"+Item.PC[c].Path+";"+"Description:"+Item.PC[c].Description+";")
                    string NameG = i.Split(';')[0].Split(':')[1];
                    string CostG = i.Split(';')[1].Split(':')[1];
                    string SourceG = i.Split(';')[2].Split(':')[1];
                    string DescriptionG = i.Split(';')[3].Split(':')[1];

                    InvPC.Add(new Item(NameG, Convert.ToInt32(CostG), SourceG, DescriptionG));
                    ImageButton imageButton = new ImageButton { Margin = new Thickness(20, 0, 0, 0), Source = SourceG, BackgroundColor = Color.Transparent };
                    imageButton.Clicked += PC_Clicked;
                    Inv_Grid.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5) + 1, ((LenInv / 5)));
                    //}
                    LenInv++;
                }
                LenInv = 0;
            }
        }
        /// <summary>
        /// Добавление компонента из магазина
        /// </summary>
        /// <param name="Part"></param>
        public static void AddToInv(string Part)
        {
            PersonClass Player = PersonClass.ReturnPerson();
            InvPart = Player.InventoryPath;
            InvPart.Add(Part);
            PersonClass.Write_TXT(InvPart);
        }
        /// <summary>
        /// Переход на вкладку Компоненты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Переход на вкладку готовых ПК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        bool DopB = false;
        /// <summary>
        /// Продажа компонентов в магазин или пк клиенту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sell_Clicked(object sender, EventArgs e)
        {
            if (DopB)
            {
                if (Prod)
                {
                    bool check = false;
                    PersonClass Player = PersonClass.ReturnPerson();
                    switch (PlayPage.zakaz)
                    {
                        case 1:
                            if (PlayPage.MoneyClient >= Convert.ToInt32(Cost.Text.Replace("₽", "")))
                            {
                                PersonClass.Write_TXT(Player.Money + PlayPage.MoneyClient);
                                PersonClass.Write_TXT2(Player.Exp + 30);
                                check = true;
                            }
                            break;
                        case 2:
                            if (PlayPage.MoneyClient <= Convert.ToInt32(Cost.Text.Replace("₽", "")))
                            {
                                PersonClass.Write_TXT(Convert.ToInt32(Player.Money + Cost.Text));
                                PersonClass.Write_TXT2(Player.Exp + 30);
                                check = true;
                            }
                            break;
                    }
                    if (check)
                    {
                        List<string> NewPC = new List<string>();
                        string[] vs = PersonClass.Read_PC().Split('*');
                        for (int i = 0; i < vs.Length - 2; i++)
                        {
                            NewPC.Add(vs[i]);
                        }
                        PersonClass.Delet_PC(NewPC);
                        Navigation.PushAsync(new Page.PlayPage());
                    }
                }
                else
                {
                    string[] Text = PersonClass.Read_TXT().Split(';')[2].Split(':')[1].Split(',');
                    string DelText = null;
                    for(int i = 0; i < Item.InInvItems.Length; i++)
                    {
                        if (tempBtn.Source.ToString().Replace("File: ", "") == Item.InInvItems[i].Path)
                        {
                            PersonClass Player = PersonClass.ReturnPerson();
                            PersonClass.Write_TXT(Player.Money + Convert.ToInt32(Item.InInvItems[i].Sell * 0.8));
                            DelText = Item.InInvItems[i].Name;
                        }
                    }
                    for (int j = 0; j < Text.Length; j++)
                        if (Text[j] == DelText)
                        {
                            Text[j] = null;
                            break;
                        }
                    List<string> list = Text.ToList<string>();
                    for (int j = 0; j < list.Count; j++)
                        if (list[j] == null)
                            list.RemoveAt(j);
                    PersonClass.Write_TXT(list);
                }
                DisplayInvPath();
                DopB = false;
            }
        }
    }
}
