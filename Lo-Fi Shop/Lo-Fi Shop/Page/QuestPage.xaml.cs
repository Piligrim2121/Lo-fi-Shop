
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestPage : ContentPage
    {
        public QuestPage()
        {
            InitializeComponent();
            Quest.Text = zadacha;
        }
        public static string zadacha;
        public QuestPage(string text)
        {
            InitializeComponent();
            zadacha = text;
            Quest.Text = zadacha;
        }
        //public  string Test { get { return ""; } set { Quest.Text = value; } }
        //public static void AddQuest(string message)
        //{
        //    //Test = text;
        //    text = message;
        //    new Page.QuestPage().AddToDoska();
        //}
    }
}