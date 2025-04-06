using PocSII.DteBusinessRules.Common;
using PocSII.DteBusinessRules.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocSII.DteAPIApplicacion.Interfaces
{
   public interface IDocumentService
    {
        Task<Result<bool>> SendAsync(ElectronicDocument documentoElectronico);
        Task<Result<ElectronicDocument>> GetAsync(string folio);
        Task<Result<bool>> NotifyAsync(string folio);
    }
}
