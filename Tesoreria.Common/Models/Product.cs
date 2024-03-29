﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesoreria.Common.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("precio")]
        public decimal Precio { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }
        public override string ToString()
        {
            return $"{this.Descripcion}{this.Precio}";
        }
    }
}
