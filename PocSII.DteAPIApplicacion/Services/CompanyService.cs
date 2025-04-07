using PocSII.DteAPIApplicacion.DTOs;
using PocSII.DteAPIApplicacion.Services.Interfaces;
using PocSII.DteAPIApplicacion.Interfaces;
using PocSII.DteBusinessRules.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocSII.DteAPIApplicacion.Services
{
   public class CompanyService: ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IResolutionRepository resolutionRepository;
        public CompanyService(ICompanyRepository companyRepository,
            IResolutionRepository resolutionRepository) {
            this.companyRepository = companyRepository;
            this.resolutionRepository = resolutionRepository;
        }

        public async Task<CompanyDTO> GetCompanyByRut(string rut) {
            var company = await companyRepository.GetByRut(rut);
            if (company == null)
                return null;
            
            return new CompanyDTO {
                Rut = company.Rut,
                RazonSocial = company.RazonSocial,
                Giro = company.Giro,
                CorreoElectrónico = company.CorreoElectronico,               
                CodigoSIISucursal = company.Sucursales.FirstOrDefault()?.CodigoSiisucursal,
                Telefonos = company.EmpresaTelefonos.Select(t => t.Telefono).ToList(),
                Acteco = company.EmpresaActecos.Select(a => a.Acteco.Codigo).ToList(),
                Direccion = company.Direccion,
                Comuna = company.Comuna,
                Ciudad = company.Ciudad.Nombre,
            };
        }

        public async Task<CompanyFullDTO> GetFullCompanyInformation(string rut) {
            ResolutionDTO resolucion;
            FoliosInfoDTO folio;
            var company = await GetCompanyByRut(rut);
             (resolucion, folio) = await GetResolutionBySucursal(new Guid("56E91795-AB7C-480B-B7D8-478F18F6F83B"),"33",true);

            return new CompanyFullDTO() {
               Company= company,
         
                Resolucion = resolucion,
                Folios= folio,                  
                ElectronicStamp = new ElectronicStamp {
                    FechaFirmaDigitalDatosAutorizacion = DateTime.Parse("2003-10-13"),
                    LlavePublicaModuloRSA = "0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==",
                    LlavePublicaExponenteRSA = "Aw==",
                    IdLlavePublica = "100",
                    FirmaDigitalDatosAutorizacion = "g1AQX0sy8NJugX52k2hTJEZAE9Cuul6pqYBdFxj1N17umW7zG/hAavCALKByHzdYAfZ3LhGTXCai5zNxOo4lDQ==",
                    FechaFirmaDigitalDatoDocumento = DateTime.Parse("2003-10-13"),
                    FirmaDigitalDatoDocumento = "GbmDcS9e/jVC2LsLIe1iRV12Bf6lxsILtbQiCkh6mbjckFCJ7fj/kakFTS06Jo8i\r\nS4HXvJj3oYZuey53Krniew=="
                }
            };
        }

        public async Task<(ResolutionDTO, FoliosInfoDTO)> GetResolutionBySucursal(Guid sucursalId, string tipoDocumento, bool Vigente) {
            var resolutionResult = await resolutionRepository.GetBySucursal(sucursalId, tipoDocumento, true);
            var resolutionBySucursal = resolutionResult.FirstOrDefault();

            if (resolutionBySucursal == null)
                return (null, null);

           var rangoFolios = resolutionBySucursal.RangoFolios.FirstOrDefault();
            var resolucion = new ResolutionDTO {
                Numero = resolutionBySucursal.Numero.ToString(),
                Fecha = resolutionBySucursal.Fecha.ToDateTime(TimeOnly.MinValue),
            };

            var folios = new FoliosInfoDTO {
                FolioInicial = rangoFolios.FolioDesde.ToString(),
                FolioFinal = rangoFolios.FolioHasta.ToString(),
                FechaAutorizacion = rangoFolios.FechaAutorizacion.ToDateTime(TimeOnly.MinValue)
            };

            return(resolucion, folios);
        }
    }
}
