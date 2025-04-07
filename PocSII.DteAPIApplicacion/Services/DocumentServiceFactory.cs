using Microsoft.Extensions.DependencyInjection;
using PocSII.DteAPIApplicacion.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocSII.DteAPIApplicacion.Services
{
    public enum DocumentType {
        Invoice,
        CreditNote
    }
   public class DocumentServiceFactory
    {
        private readonly IServiceProvider _provider;

        public DocumentServiceFactory(IServiceProvider provider) {
            _provider = provider;
        }

        public IDocumentService GetService(DocumentType type) {
            return type switch {
                DocumentType.Invoice => _provider.GetRequiredService<IDocumentService>(),
                DocumentType.CreditNote => _provider.GetRequiredService<IDocumentService>(),
                _ => throw new NotSupportedException("Tipo de documento no soportado")
            };
        }
    }
}
