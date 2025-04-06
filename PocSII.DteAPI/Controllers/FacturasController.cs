using Microsoft.AspNetCore.Mvc;
using PocSII.DteAPI.Controllers.Auth;
using PocSII.DteAPIApplicacion.DTOs;
using PocSII.DteAPIApplicacion.Services;
using PocSII.DteBusinessRules.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PocSII.DteAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly ILogger<FacturasController> _logger;
        private readonly DocumentServiceFactory _documentServiceFactory;
        public FacturasController(ILogger<FacturasController> logger, DocumentServiceFactory documentServiceFactory) {
            _logger = logger;
           _documentServiceFactory = documentServiceFactory;
        }
        // POST api/<FacturasController>
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MensajeError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MensajeError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SendInvoice([FromBody] Invoice request) {

            var service = _documentServiceFactory.GetService(DocumentType.Invoice);
            var resultSend = await service.SendAsync(request);
            if (!resultSend.IsSuccess) {
                return BadRequest(new MensajeError { Error ="Ha ocurrido un error al enviar la Factura.", Detalle= $"{resultSend.Error}: {resultSend.ErrorDescription}" });
            }

            return Ok("Documento enviado con éxito");
                     
        }

    }
}
