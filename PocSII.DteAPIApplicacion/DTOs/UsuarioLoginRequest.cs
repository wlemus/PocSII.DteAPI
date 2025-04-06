using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocSII.DteAPIApplicacion.DTOs
{
    public class UsuarioLoginRequest {
        [JsonPropertyName("usuario")]
        [Required]
        public string Usuario { get; set; }
        [JsonPropertyName("clave")]
        [Required]
        public string Clave { get; set; }
    }
}
