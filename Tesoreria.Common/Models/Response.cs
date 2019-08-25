using System;
using System.Collections.Generic;
using System.Text;

namespace Tesoreria.Common.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }//si se realizo con exito
        public String Mensaje { get; set; }//mensaje 
        public object Resultado { get; set; }//datos
    }
}
