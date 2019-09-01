using System;
using Tesoreria.Common.Config;
using Tesoreria.UIForms.ViewModels;
using Tesoreria.UIForms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tesoreria.UIForms
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }

        public App()
        {
            InitializeComponent();
            
            if (Settings.IsRemember)
            {
                var mainViewModel = MainViewModel.obtenerInstancia();
                mainViewModel.UserEmail = Settings.UserEmail;
                mainViewModel.UserPassword = Settings.UserPassword;
                mainViewModel.UserId = Settings.User;
                mainViewModel.Alumnos = new AlumnosViewModel();
                this.MainPage = new MasterPage();
                return;

            }
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
