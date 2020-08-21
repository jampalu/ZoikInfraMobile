using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZoikInfra.Services;
using ZoikInfra.Views;

namespace ZoikInfra
{
    public partial class App : Application
    {
        public static string _token;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            if (_token != null)
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
