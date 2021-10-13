using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lo_Fi_Shop
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
            
           test();
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {

        }
       public void test()
      {
            anim.IsAnimationPlaying = true;
           //BacgroundGif.IsAnimationPlaying = true;
            // sl.Children.Add(new Image { Source = "Resources/drawable/logo.gif", 
            //   isAnimationPlaying});
        }
    }
}
