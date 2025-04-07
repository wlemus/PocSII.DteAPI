using PocSII.DteAPIApplicacion.Models;

namespace PocSII.DteAPIApplicacion.Interfaces
{
  public  interface ICompanyRepository
    {
        Task<EmpresaEntity> GetByRut(string rut);
        Task<EmpresaEntity> GetById(Guid companyId);
        Task<List<EmpresaEntity>> GetAllAsync();
    }
}
