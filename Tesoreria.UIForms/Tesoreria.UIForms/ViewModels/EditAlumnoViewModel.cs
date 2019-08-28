using System;
using System.Collections.Generic;
using System.Text;
using Tesoreria.Common.Models;

namespace Tesoreria.UIForms.ViewModels
{
    public class EditAlumnoViewModel
    {
        public Alumno Alumno { get; set; }
        public EditAlumnoViewModel(Alumno alumno)
        {
            this.Alumno = alumno;
        }
    }
}
