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
   public class ResolutionRepository: IResolutionRepository {
        private readonly PocSIIDbContext _context;
        public ResolutionRepository(PocSIIDbContext context) {
            _context = context;
        }

        public async Task<ResolucionDteEntity> GetById(Guid resolucionId) {
            var resolution = await _context.ResolucionDtes    
                .Include(x => x.Sucursal)
                .FirstAsync(x => x.Id == resolucionId);

            if (resolution is null)
                return null;

            return resolution;
        }

        public async Task<List<ResolucionDteEntity>> GetBySucursal(Guid sucursalId,  string tipoDocumento, bool Vigente) {
            var resolution = await _context.ResolucionDtes
              .Include(x => x.Sucursal)
             .Include(x => x.RangoFolios.Where(rf => rf.Vigente && rf.Activo && rf.TipoDocumentoCodigo.Equals(tipoDocumento)))
            .Where(x => x.SucursalId == sucursalId && x.Activo).ToListAsync();

            return resolution;
        }
    }
}
