using Microsoft.EntityFrameworkCore;
using PocSII.DteAPIInfrastructure.Context;
using PocSII.DteAPIApplicacion.Interfaces;
using PocSII.DteAPIApplicacion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocSII.DteAPIInfrastructure.Repositories
{
   public class CompanyRepository: ICompanyRepository {
        private readonly PocSIIDbContext _context;
        public CompanyRepository(PocSIIDbContext context) {
            _context = context;
        }
        public async Task<EmpresaEntity> GetById(Guid companyId) {
            var company = await _context.Empresas
               .Include(x => x.Ciudad)
               .Include(x => x.EmpresaTelefonos)
               .Include(x => x.EmpresaActecos)
               .Include(x => x.Sucursales)
               .FirstOrDefaultAsync(x => x.Id == companyId);
            if (company is null)
                return null;

            return company;
        }

        public async Task<EmpresaEntity> GetByRut(string rut) {
            var company= await _context.Empresas
                .Include(x => x.Ciudad)
                .Include(x => x.EmpresaTelefonos)
                .Include(x => x.EmpresaActecos).ThenInclude(ea => ea.Acteco) 
                .Include(x => x.Sucursales)
                .FirstOrDefaultAsync(x => x.Rut == rut);
            if(company is null)
                return null; 

            return company;

        }

        public async Task<List<EmpresaEntity>> GetAllAsync() {
            return await _context.Empresas
                 .Include(x => x.Ciudad)
                .Include(x => x.EmpresaTelefonos)
                .Include(x => x.EmpresaActecos)
                .Include(x => x.Sucursales)
                .ToListAsync();
        }
    }
}
