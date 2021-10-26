﻿using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Android.Views;

using Android.Webkit;
using Plugin.SimpleAudioPlayer;
using System.Reflection;
using System.IO;
using Android.Media;

namespace Lo_Fi_Shop.Droid
{
    [Activity
        (
        Label = "Lo-Fi Shop", 
        Icon = "@drawable/iconka", 
        Theme = "@style/MainTheme", 
        MainLauncher = true, 
        NoHistory =true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize, ScreenOrientation = ScreenOrientation.UserLandscape
        )
    ]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// Метод при создании активити
        /// </summary>
        /// <param name="savedInstanceState"></param>
        ///
 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;


            //var assembly = typeof(App).GetTypeInfo().Assembly;
            //System.IO.Stream audioStream = assembly.GetManifestResourceStream("Resources/drawable/" + "play.mp3");


            //var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            //player.Load(audioStream);
            //player.Play();


            //Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

       
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}