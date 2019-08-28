using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tesoreria.Common.Models;
using Tesoreria.UIForms.Views;

namespace Tesoreria.UIForms.ViewModels
{
    public class AlumnoItemViewModel:Alumno
    {
        public ICommand SelectAlumnoCommand => new RelayCommand(this.SelectAlumno);

        private async void SelectAlumno()
        {
            MainViewModel.obtenerInstancia().EditAlumno = new EditAlumnoViewModel((Alumno)this);
            await App.Navigator.PushAsync(new EditAlumnosPages());
        }
    }
}
