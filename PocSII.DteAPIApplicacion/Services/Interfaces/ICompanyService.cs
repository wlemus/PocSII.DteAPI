using PocSII.DteAPIApplicacion.DTOs;
using PocSII.DteBusinessRules.Dto;

namespace PocSII.DteAPIApplicacion.Services.Interfaces
{
  public  interface ICompanyService
    {
        Task<CompanyFullDTO> GetFullCompanyInformation(string rut);

        Task<CompanyDTO> GetCompanyByRut(string rut);
        Task<(ResolutionDTO, FoliosInfoDTO)> GetResolutionBySucursal(Guid sucursalId, string tipoDocumento, bool Vigente);
    }
}
