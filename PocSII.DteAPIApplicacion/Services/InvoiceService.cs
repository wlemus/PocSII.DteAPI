using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using PocSII.DteAPIApplicacion.Interfaces;
using PocSII.DteBusinessRules.Common;
using PocSII.DteBusinessRules.Domain;
using PocSII.DteBusinessRules.Dto;
using PocSII.DteBusinessRules.Enums;
using PocSII.DteBusinessRules.Interfaces;
using PocSII.DteProcessor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocSII.DteAPIApplicacion.Services
{
    public class InvoiceService : IDocumentService {
        private readonly IMapper _mapper;
        private readonly IProcessDocumentService _processDTEService;
        public InvoiceService(IMapper mapper, IProcessDocumentService processDTEService) {
            _mapper = mapper;
            _processDTEService = processDTEService;
        }

        public async Task<Result<bool>> SendAsync(ElectronicDocument documentoElectronico) {
            //STEP 1: Map the ElectronicDocument to Invoice
            Invoice invoice = _mapper.Map<Invoice>(documentoElectronico);

            //STEP 2: Validate the Invoice
            var resultInvalidInvoice = await invoice.IsInvalid();
            if (resultInvalidInvoice.IsSuccess)
                return Result<bool>.Failure("Errores de validación de datos de entrada",String.Join(",", resultInvalidInvoice.Value));

            //STEP 3: Fill all values invoice TODO
            var invoiceDTO = FillInvoiceDTO(invoice);

            //STEP 4: Send document
          //  _processDTEService = new ProcessDTEService();
            var resultSendTaxService= _processDTEService.SendTaxService(invoiceDTO);
           

            //STEP 5: Notify the user

            return Result<bool>.Success(true);
        }

        private InvoiceDTO FillInvoiceDTO(Invoice invoice) {
            return new InvoiceDTO {
                ID = $"F{invoice.Folio}T{DOCType.Item33.GetXmlEnumValue()}",
                Factura = new Invoice {
                    Folio = "60",
                    Totales = new TotalsDocument {
                        MontoNeto = "100000",
                        IVA = "19",
                        TasaIVA = "19",
                        MontoTotal = "119000"
                    },
                    FechaEmision = DateTime.Now.ToString(),
                    FormaPago = "1",
                    RutEmisor = "97975000-5",
                    RutReceptor = "77777777-7",
                    Detalle = new List<DetailDocument>{
                    new DetailDocument {
                        NombreItem = "Parlantes Multimedia 180W",
                        CantidadItem = "20",
                        PrecioItem = "4500",
                        MontoItem = "90000",
                        CodigoItem = new List<ItemCodeDetailDocument>
                        {
                            new ItemCodeDetailDocument
                            {
                                TipoCodigo = "INT1",
                                ValorCodigo = "001"
                            }
                        }
                    },
                      new DetailDocument {
                        NombreItem = "Caja de Diskettes 10 Unidades",
                        CantidadItem = "5",
                        PrecioItem = "1000",
                        MontoItem = "5000",
                        CodigoItem = new List<ItemCodeDetailDocument>
                        {
                            new ItemCodeDetailDocument
                            {
                                TipoCodigo = "INT1",
                                ValorCodigo = "1515"
                            }
                        }
                    }
                }
                },
                Emisor = new CompanyDTO {
                    Rut = "97975000-5",
                    RazonSocial = "RUT DE PRUEBA",
                    Giro = "Insumos de Computacion",
                    Acteco = new List<string> { "31341" },
                    CodigoSIISucursal = "1234",
                    Direccion = "Teatinos 120, Piso 4",
                    Comuna = "Santiago",
                    Ciudad = "Santiago"
                },
                Receptor = new CompanyDTO {
                    Rut = "77777777-7",
                    RazonSocial = "EMPRESA LTDA",
                    Giro = "COMPUTACION",
                    Direccion = "SAN DIEGO 2222",
                    Comuna = "LA FLORIDA",
                    Ciudad = "SANTIAGO"
                },
                Resolucion = new ResolutionDTO {
                    Numero = "0",
                    Fecha = DateTime.Parse("2003-09-02")
                },
                FoliosInfo = new FoliosInfoDTO {
                    FolioInicial = "1",
                    FolioFinal = "200",
                    FechaAutorizacion = DateTime.Parse("2003-09-04")
                },
                FechaFirmaDoc = DateTime.Parse("2003-09-04"),
                TimbreElectronicoInfo = new ElectronicStamp {
                    FechaFirmaDigitalDatosAutorizacion = DateTime.Parse("2003-10-13"),
                    LlavePublicaModuloRSA = "0a4O6Kbx8Qj3K4iWSP4w7KneZYeJ+g/prihYtIEolKt3cykSxl1zO8vSXu397QhTmsX7SBEudTUx++2zDXBhZw==",
                    LlavePublicaExponenteRSA = "Aw==",
                    IdLlavePublica = "100",
                    FirmaDigitalDatosAutorizacion = "g1AQX0sy8NJugX52k2hTJEZAE9Cuul6pqYBdFxj1N17umW7zG/hAavCALKByHzdYAfZ3LhGTXCai5zNxOo4lDQ==",
                    FechaFirmaDigitalDatoDocumento = DateTime.Parse("2003-10-13"),
                    FirmaDigitalDatoDocumento = "GbmDcS9e/jVC2LsLIe1iRV12Bf6lxsILtbQiCkh6mbjckFCJ7fj/kakFTS06Jo8i\r\nS4HXvJj3oYZuey53Krniew=="
                },
            };
        }
        public Task<Result<ElectronicDocument>> GetAsync(string folio) {
            throw new NotImplementedException();

        }

        public Task<Result<bool>> NotifyAsync(string folio) {
            throw new NotImplementedException();
        }

    }
}
