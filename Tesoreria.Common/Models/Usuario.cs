using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesoreria.Common.Models
{
    public class Usuario
    {
        [JsonProperty("usu_id")]
        public int UsuId { get; set; }

        [JsonProperty("usu_usuario")]
        public string UsuUsuario { get; set; }

        [JsonProperty("usu_password")]
        public string UsuPassword { get; set; }

        [JsonProperty("usu_fecha")]
        public DateTimeOffset UsuFecha { get; set; }

        [JsonProperty("alu_id_alumno")]
        public int AluIdAlumno { get; set; }
    }
}
