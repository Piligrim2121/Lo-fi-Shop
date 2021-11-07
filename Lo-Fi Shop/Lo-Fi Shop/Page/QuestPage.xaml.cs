using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lo_Fi_Shop.Class;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestPage : ContentPage
    {
        public QuestPage()
        {
            string[] DataClient = PersonClass.Read_TXT("client").Split(';');
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Quest.Text = DataClient[1];
        }
        public static string zadacha;
        public QuestPage(string text)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
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