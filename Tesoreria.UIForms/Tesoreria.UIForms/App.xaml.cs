using System;
using Tesoreria.UIForms.ViewModels;
using Tesoreria.UIForms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tesoreria.UIForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainViewModel.obtenerInstancia().Login = new LoginViewModel();
            this.MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
