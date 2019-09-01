using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Tesoreria.Common.Config;
using Tesoreria.Common.Models;
using Tesoreria.Common.Services;
using Tesoreria.UIForms.Views;
using Xamarin.Forms;

namespace Tesoreria.UIForms.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        public bool isRemember { get; set; }
        private readonly ApiServices apiService;
        public String email { get;  set; }
        public String password { get; set; }
        public bool IsRunning
        {
            get => this.isRunning;
            set => this.SetValue(ref this.isRunning, value);
        }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetValue(ref this.isEnabled, value);
        }

        public ICommand LoginCommand => new RelayCommand(Login);
        public LoginViewModel()
        {
          
            this.apiService = new ApiServices();
            this.isRemember = true;
            this.IsEnabled = true;
           
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

            this.IsRunning = true;
            this.IsEnabled = false;
            var usuario = new Usuario
            {
                UsuUsuario = this.email,
                UsuPassword = this.password
            };
            var url = "https://secret-woodland-25862.herokuapp.com";
            var response = await this.apiService.PostAsync(
                url,
                "login.php",
                usuario
                );
            if (!response.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Usario o password incorrecto",
                   "aceptar");
                return;
            }
            usuario = (Usuario)response.Resultado;
            var mainViewModel = MainViewModel.obtenerInstancia();
            mainViewModel.UserEmail = this.email;
            mainViewModel.UserPassword = this.password;
            mainViewModel.UserId = ""+usuario.AluIdAlumno;
            MainViewModel.obtenerInstancia().Alumnos = new AlumnosViewModel();
            Settings.IsRemember = this.isRemember;
            Settings.UserEmail = this.email;
            Settings.UserPassword = this.password;
            Settings.User=""+usuario.AluIdAlumno;
            
            Application.Current.MainPage= new MasterPage();

        }


        //implementar comando hay que implementar nuget MVVM LIGHT STD 
    }
}
