using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Tesoreria.Common.Models;
using Tesoreria.Common.Services;
using Xamarin.Forms;

namespace Tesoreria.UIForms.ViewModels
{
    public class AlumnosViewModel: BaseViewModel
    {
        private ApiServices apiServices;
        private ObservableCollection<Alumno> alumnos;
        private bool cargando;
        public ObservableCollection<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.SetValue(ref this.alumnos, value); }
        }//lista de productoa para el list view

        public bool Cargando
        {
            get { return this.cargando; }
            set { this.SetValue(ref this.cargando, value); }
        }//lista de productoa para el list view
        public AlumnosViewModel()
        {
            this.apiServices = new ApiServices();
            this.CargarAlumnos();
        }

        private async void CargarAlumnos()
        {
            this.Cargando = true;
            var response = await this.apiServices.GetListAsync<Alumno>(
                "https://secret-woodland-25862.herokuapp.com",
                "listarAlumnos.php");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Mensaje,
                    "Aceptar");
                return;
            }
            this.Cargando = false;
            var MisAlumnos = (List<Alumno>)response.Resultado;
            this.Alumnos = new ObservableCollection<Alumno>(MisAlumnos.OrderBy(p => p.AluNombre));
        }
    }
}
