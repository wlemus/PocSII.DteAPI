using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocSII.DteAPIApplicacion.DTOs
{
    public class MensajeError {
        [JsonPropertyName("error")]
        public string Error { get; set; }
        [JsonPropertyName("detalle")]
        public string Detalle { get; set; }
    }
}
