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
    public class EditAlumnoViewModel : BaseViewModel
    {

        private bool isRunning;
        private bool isEnabled;
        private readonly ApiServices apiService;

        public Alumno Alumno { get; set; }


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
        public ICommand GuardarCommand => new RelayCommand(this.ActualizarAlumno);
        public ICommand EliminarCommand => new RelayCommand(this.EliminarAlumno);


        public EditAlumnoViewModel(Alumno alumno)
        {
            this.Alumno = alumno;
            this.apiService = new ApiServices();
            this.IsEnabled = true;
        }

        private async void ActualizarAlumno()
        {
            if (string.IsNullOrEmpty(this.Alumno.AluCodigo))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Debes ingresar un Código",
                   "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Alumno.AluNombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Debes ingresar un Código",
                   "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Alumno.AluApellido))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Debes ingresar un Nombre",
                   "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Alumno.AluDireccion))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Debes ingresar un Apellido",
                   "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Alumno.AluCorreo))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Debes ingresar un Correo",
                   "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Alumno.AluTelefono))
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Debes ingresar un Teléfono",
                   "Aceptar");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            var url = "https://secret-woodland-25862.herokuapp.com";
            var response = await this.apiService.PutAsync(
                url,
                "editAlumno.php",
                this.Alumno.AluId,
                this.Alumno
                );
            this.IsRunning = false;
            this.IsEnabled = true;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   response.Mensaje,
                   "Aceptar");
                return;
            }
            var AlumnoModificado = (Alumno)response.Resultado;
            MainViewModel.obtenerInstancia().Alumnos.UpdateAlumnoInlist(AlumnoModificado);
            await App.Navigator.PopAsync();
            
        }
        private async void EliminarAlumno()
        {
            var rpt = await Application.Current.MainPage.DisplayAlert(
                   "Confirmar",
                   "Esta seguro de eliminar el alumno",
                   "Si",
                   "No");
            if (!rpt)
            {
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            var url = "https://secret-woodland-25862.herokuapp.com";
            var response = await this.apiService.DeleteAsync(
                url,
                "deleteAlumno.php",
                this.Alumno.AluId
                );
            this.IsRunning = false;
            this.IsEnabled = true;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   response.Mensaje,
                   "Aceptar");
                return;
            }
            MainViewModel.obtenerInstancia().Alumnos.deleteAlumnoInList(this.Alumno.AluId);
            await App.Navigator.PopAsync();
        }

    }
}
