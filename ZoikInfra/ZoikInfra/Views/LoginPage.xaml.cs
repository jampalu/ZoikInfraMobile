using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoikInfra.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZoikInfra.Services;
using ZoikInfra.Models;

namespace ZoikInfra.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        ZoikServices zoikServices;
        public LoginPage()
        {
            InitializeComponent();
            zoikServices = new ZoikServices();
            this.BindingContext = new LoginViewModel();
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                UserName = Email.Text,
                Password = Password.Text
            };
            await zoikServices.LoginAsync(user);
            if (App._token != null)
            {
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
        }
    }
}