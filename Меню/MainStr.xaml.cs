using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alchemy
{
    /// <summary>
    /// Логика взаимодействия для MainStr.xaml
    /// </summary>
    public partial class MainStr : Page
    {
        public MainStr(SoundPlayer sp, bool musika)
        {
            InitializeComponent();
            this.sp = sp;
            this.musika = musika;
        }
        SoundPlayer sp;
       // bool sou = true;
        bool musika;
       

        

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            switch ((sender as Label).Name)
            {
                case "StartTheGame":
                    StartTheGame.Foreground = Brushes.Green;
                    break;
                case "Rules":
                    Rules.Foreground = Brushes.Green;
                    break;
                case "Author":
                    Author.Foreground = Brushes.Green;
                    break;
                case "Sound":
                    Sound.Foreground = Brushes.Green;
                    break;
                case "Exit":
                    Exit.Foreground = Brushes.Green;
                    break;
                case "Back":
                    Back.Foreground = Brushes.Green;
                    break;
            }
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            switch ((sender as Label).Name)
            {
                case "StartTheGame":
                    StartTheGame.Foreground = Brushes.Yellow;
                    break;
                case "Rules":
                    Rules.Foreground = Brushes.Yellow;
                    break;
                case "Author":
                    Author.Foreground = Brushes.Yellow;
                    break;
                case "Sound":
                    Sound.Foreground = Brushes.Yellow;
                    break;
                case "Exit":
                    Exit.Foreground = Brushes.OrangeRed;
                    break;
                case "Back":
                    Back.Foreground = Brushes.Yellow;
                    break;
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as Label).Name)
            {
                case "Sound":
                    if (musika == true)
                    {
                        Sound.Content = "Звук: ВЫКЛ";
                        sp.Stop();
                        musika = false;
                    }
                    else
                    {
                        Sound.Content = "Звук: ВКЛ";
                        sp.PlayLooping();
                        musika = true;
                    }
                    break;
                case "Exit":
                    Application.Current.Shutdown();
                    break;
                case "Author":
                    Back.Visibility = Visibility.Visible;
                    Stenka.Visibility = Visibility.Hidden;
                    Options.Visibility = Visibility.Hidden;
                    MainFrame.Navigate(new Author());
                    break;
                case "Rules":
                    MainFrame.Navigate(new HowToPlay());
                    Back.Visibility = Visibility.Visible;
                    Stenka.Visibility = Visibility.Hidden;
                    Options.Visibility = Visibility.Hidden;
                    break;
                case "StartTheGame":
                    Alchemy_GamePlay Game= new Alchemy_GamePlay(sp, musika);
                    Application.Current.MainWindow.Close();
                    Game.ShowDialog();
                    break;
                case "Back":
                    Back.Visibility = Visibility.Hidden;
                    MainFrame.Navigate(new MainStr(sp, musika));
                    break;
            }
        }
    }
}
