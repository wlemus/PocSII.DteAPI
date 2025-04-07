using PocSII.DteAPIApplicacion.Models;

namespace PocSII.DteAPIApplicacion.Interfaces
{
  public  interface IResolutionRepository
    {
        Task<ResolucionDteEntity> GetById(Guid resolucionId);
        Task<List<ResolucionDteEntity>> GetBySucursal(Guid sucursalId, string tipoDocumento, bool Vigente);

    }
}
