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
        private List<Alumno> MisAlumnos;
        private ObservableCollection<AlumnoItemViewModel> alumnos;
        private bool cargando;
        public ObservableCollection<AlumnoItemViewModel> Alumnos
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
            this.MisAlumnos = (List<Alumno>)response.Resultado;
            this.RefresListAlumnos();
        }

        private void RefresListAlumnos()
        {
            this.Alumnos = new ObservableCollection<AlumnoItemViewModel>(
                this.MisAlumnos.Select(p => new AlumnoItemViewModel
                {
                    AluId = p.AluId,
                    AluCodigo = p.AluCodigo,
                    AluNombre = p.AluNombre,
                    AluApellido = p.AluApellido,
                    AluDireccion = p.AluDireccion,
                    AluTelefono = p.AluTelefono,
                    AluCorreo = p.AluCorreo
                })
            .OrderBy(p => p.AluNombre)
            .ToList());
        }
        public void AddAlumnoToList(Alumno alumno)
        {
            this.MisAlumnos.Add(alumno);
            this.RefresListAlumnos();
        }
        public void UpdateAlumnoInlist(Alumno alumno)
        {
            var anterioAlumno = this.MisAlumnos.Where(p => p.AluId == alumno.AluId).FirstOrDefault();
            if (anterioAlumno != null)
            {
                this.MisAlumnos.Remove(anterioAlumno);
            }

            this.MisAlumnos.Add(alumno);
            this.RefresListAlumnos();
        }
        public void deleteAlumnoInList(int alumnoId)
        {
            var anterioAlumno = this.MisAlumnos.Where(p => p.AluId == alumnoId).FirstOrDefault();
            if (anterioAlumno != null)
            {
                this.MisAlumnos.Remove(anterioAlumno);
            }
            this.RefresListAlumnos();

        }
    }
}
