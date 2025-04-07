using PocSII.DteBusinessRules.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocSII.DteAPIApplicacion.DTOs
{
    public class CompanyFullDTO
    {
        public CompanyDTO Company  { get; set; }
        public ResolutionDTO Resolucion { get; set; }
        public FoliosInfoDTO Folios { get; set; }
        public ElectronicStamp ElectronicStamp { get; set; }
    }
}
