using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesoreria.Common.Models
{
    public class Alumno
    {
        [JsonProperty("alu_id")]
        public int AluId { get; set; }

        [JsonProperty("alu_codigo")]
        
        public string AluCodigo { get; set; }

        [JsonProperty("alu_nombre")]
        public string AluNombre { get; set; }

        [JsonProperty("alu_apellido")]
        public string AluApellido { get; set; }

        [JsonProperty("alu_direccion")]
        public string AluDireccion { get; set; }

        [JsonProperty("alu_telefono")]
        public string AluTelefono { get; set; }

        [JsonProperty("alu_correo")]
        public string AluCorreo { get; set; }

        [JsonProperty("esc_id_escuela")]
        public int EscIdEscuela { get; set; }

        public override string ToString()
        {
            return $"{this.AluCodigo}{this.AluNombre}{this.AluApellido}{this.AluTelefono}";
        }
    }
}
