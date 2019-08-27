using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Tesoreria.UIForms.Views;
using Xamarin.Forms;

namespace Tesoreria.UIForms.ViewModels
{
    public class LoginViewModel
    {
        public String email { get;  set; }
        public String password { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);
        public LoginViewModel()
        {
            this.email = "j.asmat@outlook.com";
            this.password = "123";
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un email",
                    "aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un password",
                    "aceptar");
                return;
            }
            if (!this.email.Equals("j.asmat@outlook.com")|| !this.password.Equals("123"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usario o password incorrecto",
                    "aceptar");
                return;
            }
            //await Application.Current.MainPage.DisplayAlert(
            //        "ok",
            //        "correcto",
            //        "aceptar");
            var mainViewModel = MainViewModel.obtenerInstancia();
            mainViewModel.UserEmail = this.email;
            mainViewModel.UserPassword = this.password;
            MainViewModel.obtenerInstancia().Products = new ProductsViewModel();
            Application.Current.MainPage= new MasterPage();

        }


        //implementar comando hay que implementar nuget MVVM LIGHT STD 
    }
}
