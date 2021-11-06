using Lo_Fi_Shop.Class;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CraftPage : ContentPage
    {

        public CraftPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Players = PersonClass.ReturnPerson();
            DisplayInvPath();
        }
        ISimpleAudioPlayer PageSound;
        static PersonClass Players;
        public static List<string> InvPart { get; set; }
        public static List<string> Items { get; set; }

        public int[] Cost = new int[8];

        public string[] UseKomponents = new string[8];
        PersonClass Player = PersonClass.ReturnPerson();

        private void DisplayInvPath()
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
                else
                {
                    for (int j = 0; j < Item.CreateItems().Length; j++)
                    {
                        if (i == Item.CreateItems()[j].Name)
                        {
                            ImageButton imageButton = new ImageButton { Source = Item.CreateItems()[j].Path, BackgroundColor = Color.Transparent };
                            InvCraft.Children.Add(imageButton, (LenInv - (LenInv / 5) * 5), ((LenInv / 5) + 1));
                            imageButton.Clicked += ElementCliced;
                        }
                    }
                }
                LenInv++;
            }
            LenInv = 0;
        }
        ImageButton tempBtn;
        
        private void ElementCliced(object sender, EventArgs e)
        {
            tempBtn = sender as ImageButton;
            for(int i = 0; i < Item.CreateItems().Length; i++)
            {
                if (tempBtn.Source.ToString().Replace("File: ", "") == Item.CreateItems()[i].Path)
                {
                    if (tempBtn.Source.ToString().Replace("File: ", "").Contains("Proc"))
                    {
                        
                        var stream = PersonClass.GetStreamFromFile("songVhih.mp3");
                        PageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                        PageSound.Load(stream);
                        PageSound.Volume = Player.Settings[2];
                        PageSound.Play();

                        Proc.Source = Item.CreateItems()[i].Path;
                        Cost[0] = Item.CreateItems()[i].Sell;
                        UseKomponents[0] = Item.CreateItems()[i].Name;
                    }
                    else if (tempBtn.Source.ToString().Replace("File: ", "").Contains("Vid"))
                    {
                        var stream = PersonClass.GetStreamFromFile("songVhih.mp3");
                        PageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                        PageSound.Load(stream);
                        PageSound.Volume = Player.Settings[2];
                        PageSound.Play();

                        Video.Source = Item.CreateItems()[i].Path;
                        Cost[1] = Item.CreateItems()[i].Sell;
                        UseKomponents[1] = Item.CreateItems()[i].Name;
                    }
                    else if (tempBtn.Source.ToString().Replace("File: ", "").Contains("Cooler"))
                    {
                        var stream = PersonClass.GetStreamFromFile("songVhih.mp3");
                        PageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                        PageSound.Load(stream);
                        PageSound.Volume = Player.Settings[2];
                        PageSound.Play();

                        Kyler.Source = Item.CreateItems()[i].Path;
                        Cost[2] = Item.CreateItems()[i].Sell;
                        UseKomponents[2] = Item.CreateItems()[i].Name;
                    }
                    else if (tempBtn.Source.ToString().Replace("File: ", "").Contains("Mother"))
                    {
                        var stream = PersonClass.GetStreamFromFile("songVhih.mp3");
                        PageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                        PageSound.Load(stream);
                        PageSound.Volume = Player.Settings[2];
                        PageSound.Play();

                        Mat.Source = Item.CreateItems()[i].Path;
                        Cost[3] = Item.CreateItems()[i].Sell;
                        UseKomponents[3] = Item.CreateItems()[i].Name;
                    }
                    else if (tempBtn.Source.ToString().Replace("File: ", "").Contains("ram"))
                    {
                        var stream = PersonClass.GetStreamFromFile("songVhih.mp3");
                        PageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                        PageSound.Load(stream);
                        PageSound.Volume = Player.Settings[2];
                        PageSound.Play();

                        OP.Source = Item.CreateItems()[i].Path;
                        Cost[4] = Item.CreateItems()[i].Sell;
                        UseKomponents[4] = Item.CreateItems()[i].Name;
                    }
                    else if (tempBtn.Source.ToString().Replace("File: ", "").Contains("corpus"))
                    {
                        var stream = PersonClass.GetStreamFromFile("songVhih.mp3");
                        PageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                        PageSound.Load(stream);
                        PageSound.Volume = Player.Settings[2];
                        PageSound.Play();

                        Korpus.Source = Item.CreateItems()[i].Path;
                        Cost[5] = Item.CreateItems()[i].Sell;
                        UseKomponents[5] = Item.CreateItems()[i].Name;
                    }
                    else if (tempBtn.Source.ToString().Replace("File: ", "").Contains("Power"))
                    {
                        var stream = PersonClass.GetStreamFromFile("songVhih.mp3");
                        PageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                        PageSound.Load(stream);
                        PageSound.Volume = Player.Settings[2];
                        PageSound.Play();

                        Pit.Source = Item.CreateItems()[i].Path;
                        Cost[6] = Item.CreateItems()[i].Sell;
                        UseKomponents[6] = Item.CreateItems()[i].Name;
                    }
                    else if (tempBtn.Source.ToString().Replace("File: ", "").Contains("mem"))
                    {
                        var stream = PersonClass.GetStreamFromFile("songVhih.mp3");
                        PageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                        PageSound.Load(stream);
                        PageSound.Volume = Player.Settings[2];
                        PageSound.Play();

                        HDD.Source = Item.CreateItems()[i].Path;
                        Cost[7] = Item.CreateItems()[i].Sell;
                        UseKomponents[7] = Item.CreateItems()[i].Name;
                    }
                }
            }
        }

        private void Sborka_Clicked(object sender, EventArgs e)
        {
            int AllCost = Cost.Sum();
            Sborka.IsEnabled = false;
            Console.WriteLine(Cost.ToString());
            if (Proverka())
            {
                if (PersonClass.Read_PC().Split('*').Length < 25)
                {
                    InvPart = new List<string>();
                    string name = "";
                    string Source = "";

                    PersonClass Player = PersonClass.ReturnPerson();
                    var stream = PersonClass.GetStreamFromFile("songCraft.mp3");
                    PageSound = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    PageSound.Load(stream);
                    PageSound.Volume = Player.Settings[2];
                    PageSound.Play();

                    if (AllCost <= 50000)
                    {
                        name = "Бюджетный ПК";
                        Source = "Resource/drawable/Easy_DonePC.png";
                    }
                    else if ((AllCost >= 50000) && (AllCost <= 120000))
                    {
                        name = "Средний ПК";
                        Source = "Resource/drawable/Medium_DonePC.png";
                    }
                    else
                    {
                        name = "Мощный ПК";
                        Source = "Resource/drawable/Hard_DonePC.png";
                    }

                    Item.PC.Add(new Item(name, AllCost, Source, UseKomponents[0] + "\n" + UseKomponents[1] + "\n" + UseKomponents[2] + "\n" + UseKomponents[3] + "\n" + UseKomponents[4] + "\n" + UseKomponents[5] + "\n" + UseKomponents[6] + "\n" + UseKomponents[7]));
                    PersonClass.Write_PC(Item.PC);
                    
                    string[] Text = PersonClass.Read_TXT().Split(';')[2].Split(':')[1].Split(',');
                    foreach (string i in UseKomponents)
                    {
                        for (int j = 0; j < Text.Length; j++)
                        {
                            if (Text[j] == i)
                            {
                                Text[j] = null;
                                break;
                            }
                        }
                    }
                    List<string> list = Text.ToList<string>();
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] == null)
                        {
                            list.RemoveAt(j);
                        }
                    }
                    PersonClass.Write_TXT(list);
                    Navigation.PopAsync();
                }
            }
        }
        private bool Proverka() // крестик по умолчанию когда не выбран
        {
            if (Proc.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Video.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Mat.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                OP.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                HDD.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Pit.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Kyler.Source.ToString() == "File: Resource/drawable/ItemPlace.png" ||
                Korpus.Source.ToString() == "File: Resource/drawable/ItemPlace.png")
                return false;
            else
                return true;
        }
    }
}