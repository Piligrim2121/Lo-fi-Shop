﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lo_Fi_Shop.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            anim.IsAnimationPlaying = true;
        }
}
}