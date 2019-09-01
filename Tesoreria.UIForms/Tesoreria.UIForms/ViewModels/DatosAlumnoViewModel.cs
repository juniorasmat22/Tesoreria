using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tesoreria.Common.Config;
using Tesoreria.Common.Models;
using Tesoreria.Common.Services;
using Xamarin.Forms;

namespace Tesoreria.UIForms.ViewModels
{
    public class DatosAlumnoViewModel:BaseViewModel
    {
        private Alumno mialumno;
        public Alumno MiAlumno
        {
            get => this.mialumno;
            set => this.SetValue(ref this.mialumno, value);
        }

        private ApiServices apiServices;

        
        public DatosAlumnoViewModel()
        {
           
            apiServices = new ApiServices();
            cargarDatos();
        }

        private async void cargarDatos()
        {
            var alumno = new Alumno
            {
                AluId = Convert.ToInt32( Settings.User)

            };

            var response = await this.apiServices.PostAsync<Alumno>(
              "https://secret-woodland-25862.herokuapp.com",
              "listAlumno.php",
              alumno);
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Mensaje,
                    "Aceptar");
                return;
            }
            var alumnoX = (Alumno)response.Resultado;
            this.MiAlumno= alumnoX;
            //cfc/
        }

      
    }
}
