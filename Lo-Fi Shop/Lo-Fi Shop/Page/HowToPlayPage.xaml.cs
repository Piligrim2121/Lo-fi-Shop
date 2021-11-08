using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HowToPlayPage : ContentPage
    {
        public HowToPlayPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            Add_Al();

        }
        /// <summary>
        /// Создании контента страницы
        /// </summary>
        public void Add_Al()
        {

            //var AbsoluteLayoutMain = new AbsoluteLayout();
            /*  AbsoluteLayout.SetLayoutFlags(ImgBack, AbsoluteLayoutFlags.PositionProportional);
              AbsoluteLayout.SetLayoutBounds(ImgBack, new Rectangle(0.5, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
              //AbsoluteLayoutMain.Children.Add(ImgBack);*/
            var StackMain = new StackLayout() { Spacing = 0 };
            AbsoluteLayout.SetLayoutFlags(StackMain, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(StackMain, new Rectangle(0.5, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            Image Logo = new Image { Source = "Resources/drawable/x_logo.gif", HeightRequest = 130, Aspect = Aspect.AspectFit, IsAnimationPlaying = true };
            StackMain.Children.Add(Logo);
            StackMain.Children.Add(new Xamarin.Forms.Label { Text = "Как играть", HorizontalOptions = LayoutOptions.Center, FontSize = 18, TextColor = Color.White });

            var Stack = new StackLayout();
            Stack.Children.Add(new Xamarin.Forms.Label { Text = "· Пользователь начинает свою игру в роли продавца 1 уровня и имеет стартовый капитал в размере 200.000₽", HorizontalOptions = LayoutOptions.Start, FontSize = 14, TextColor = Color.White });
            Stack.Children.Add(new Image { Source = "Resources/drawable/e_mainPage.jpg" });

            Stack.Children.Add(new Xamarin.Forms.Label { Text = "· Продавец имеет «Инвентарь», в котором он может хранить купленные в «Магазине» предметы.", HorizontalOptions = LayoutOptions.Start, FontSize = 14, TextColor = Color.White });
            Stack.Children.Add(new Image { Source = "Resources/drawable/e_inventory.jpg " });
            Stack.Children.Add(new Image { Source = "Resources/drawable/e_inventory2.jpg " });
            Stack.Children.Add(new Xamarin.Forms.Label { Text = "· В «Магазине» продавец может приобретать необходимые компоненты для сборки ПК.", HorizontalOptions = LayoutOptions.Start, FontSize = 14, TextColor = Color.White });
            Stack.Children.Add(new Image { Source = "Resources/drawable/e_Shop.jpg " });
            Stack.Children.Add(new Xamarin.Forms.Label { Text = "· В определенные моменты времени в помещение магазина заходят покупатели.", HorizontalOptions = LayoutOptions.Start, FontSize = 14, TextColor = Color.White });
            Stack.Children.Add(new Xamarin.Forms.Label { Text = "· Игрок имеет возможность взаимодействовать с покупателями, посредством диалога. При взаимодействии с покупателем открывается диалоговое окно.", HorizontalOptions = LayoutOptions.Start, FontSize = 14, TextColor = Color.White });
            Stack.Children.Add(new Image { Source = "Resources/drawable/e_Dialog.jpg " });
            Stack.Children.Add(new Xamarin.Forms.Label { Text = "· При принятии заказа он добавляется в «Список задач».", HorizontalOptions = LayoutOptions.Start, FontSize = 14, TextColor = Color.White });
            Stack.Children.Add(new Image { Source = "Resources/drawable/e_doskaTask.jpg " });
            Stack.Children.Add(new Xamarin.Forms.Label { Text = "· При отклонении заказа клиент уходит. При регулярном отказе снимается процент от текущего уровня. На первом уровне у игрока снимается 5% опыта от необходимого количества опыта для повышения уровня. С каждым следящим уровней опыт убавка опыта увеличивается на 3%.Тем самым, чем выше уровень, тем больше опыта теряет игрок. Если у игрока уровень больше чем первый и его опыт упал до 0, то его уровень понижается на 1. Уровень не может упасть ниже 1. На первом уровне опыт не может уйти в минус.", HorizontalOptions = LayoutOptions.Start, FontSize = 14, TextColor = Color.White });
            Stack.Children.Add(new Xamarin.Forms.Label { Text = "· Для создания ПК игрок должен проверить, есть ли у него необходимые комплектующие в «Инвентаре». В случае, если таковых нет, игрок должен зайти во вкладку «Магазин» и купить их. Собрав все необходимые компоненты, игрок переходит на вкладку «Крафт», где собирает ПК. После чего собранный ПК попадает во вкладку «Инвентарь».", HorizontalOptions = LayoutOptions.Start, FontSize = 14, TextColor = Color.White });
            Stack.Children.Add(new Image { Source = "Resources/drawable/e_craft.jpg " });
            //Если приложение вылетает то, на вашем устройстве в меню параметров разработчика вы должны включить "принудительный рендеринг gpu"
            StackMain.Children.Add(Stack);
            AL.Children.Add(StackMain);
            Content = new ScrollView { Content = AL };
        }
    }
}