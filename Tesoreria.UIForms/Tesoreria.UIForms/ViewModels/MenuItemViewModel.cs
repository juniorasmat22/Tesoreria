using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tesoreria.Common.Config;
using Tesoreria.Common.Models;
using Tesoreria.UIForms.Views;
using Xamarin.Forms;

namespace Tesoreria.UIForms.ViewModels
{
    public class MenuItemViewModel : Common.Models.Menu
    {
        public ICommand SelectMenuCommand => new RelayCommand(this.SelectMenu);

        private async void SelectMenu()
        {
            App.Master.IsPresented = false;
            var mainViewModel = MainViewModel.obtenerInstancia();

            switch (this.PageName)
            {
                case "AboutPage":
                    await App.Navigator.PushAsync(new AboutPage());
                    break;
                case "SetupPage":
                    await App.Navigator.PushAsync(new SetupPage());
                    break;
                case "PagosPage":
                    await App.Navigator.PushAsync(new PagosPage());
                    break;
                case "NewPagosPage":
                    await App.Navigator.PushAsync(new NewPagoPage());
                    break;
                case "AlumnosPage":
                    //await App.Navigator.PushAsync(new SetupPage());
                    break;
                case "DatosPage":
                    MainViewModel.obtenerInstancia().DatosAlumno = new DatosAlumnoViewModel();
                    await App.Navigator.PushAsync(new DatosAlumnoPage());
                    break;
                default:
                    Settings.IsRemember = false;
                    Settings.UserEmail = string.Empty;
                    Settings.UserPassword = string.Empty;
                    MainViewModel.obtenerInstancia().Login = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
            }
        }
    }
}
