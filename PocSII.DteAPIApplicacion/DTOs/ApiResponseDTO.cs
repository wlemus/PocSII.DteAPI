using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocSII.DteAPIApplicacion.DTOs {
    public class ApiResponseDTO<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
        public string? Traza { get; set; }

        public ApiResponseDTO(bool success, string message, object? data, string traza)
        {
            Success = success;
            Message = message;
            Data = data;
            Traza = traza;
        }
    }
}