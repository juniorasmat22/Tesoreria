using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tesoreria.Common.Models;
using Tesoreria.Common.Services;
using Xamarin.Forms;

namespace Tesoreria.UIForms.ViewModels
{
    public class AddAlumnoViewModel: BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        private readonly ApiServices apiService;


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
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        //falta el iod de  la escuela

        public ICommand SaveCommand => new RelayCommand(this.Guardar);

        public AddAlumnoViewModel()
        {
            this.apiService = new ApiServices();
            this.IsEnabled = true;
        }
        private async void Guardar()
        {
            if (string.IsNullOrEmpty(this.Codigo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un Código",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Nombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un Nombre",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Apellido))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar el Apellido",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Direccion))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar una Dirección",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Telefono))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un Teléfono",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Correo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un Correo",
                    "Aceptar");
                return;
            }
            if (this.Codigo.Length!=10)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un Codigo Valido, debe contener 10 digitos",
                    "Aceptar");
                return;
            }
            if (this.Nombre.Length <3 && this.Nombre.Length>=100)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El nombre debe contener de 3 a 100 caracteres",
                    "Aceptar");
                return;
            }
            if (this.Apellido.Length < 3 && this.Apellido.Length >= 100)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El Apellido debe contener de 3 a 100 caracteres",
                    "Aceptar");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            var alumno = new Alumno
            {
                AluCodigo=this.Codigo,
                AluNombre=this.Nombre,
                AluApellido=this.Apellido,
                AluCorreo=this.Correo,
                AluDireccion=this.Direccion,
                AluTelefono=this.Telefono,
                EscIdEscuela=1

            };

            var url = "https://secret-woodland-25862.herokuapp.com";
            var response = await this.apiService.PostAsync(
                url,
                "addAlumno.php",
                alumno
                );

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Mensaje,
                    "Accept");
                return;
            }
            var newAlumno = (Alumno)response.Resultado;
            MainViewModel.obtenerInstancia().Alumnos.AddAlumnoToList(newAlumno);

            this.IsRunning = false;
            this.IsEnabled = true;
            await App.Navigator.PopAsync();
        }
    }
}

