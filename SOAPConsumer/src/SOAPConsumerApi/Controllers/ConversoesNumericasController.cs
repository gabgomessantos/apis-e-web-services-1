using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberConversionService;
using SOAPConsumerApi.Models;
using static NumberConversionService.NumberConversionSoapTypeClient;

namespace SOAPConsumerApi.Controllers
{
    [Route("api/conversoesnumericas")]
    [ApiController]
    public class ConversoesNumericasController : MainController
    {
        private readonly NumberConversionSoapTypeClient _soapClient;

        public ConversoesNumericasController()
        {
            _soapClient = new NumberConversionSoapTypeClient(EndpointConfiguration.NumberConversionSoap);
        }

        [HttpGet]
        [Route("numero-extenso")]
        public async Task<ActionResult<ConversaoNumerica>> NumeroPorExtenso(int numero)
        {
            
            var result = new ConversaoNumerica {
                TextoConversao = await ObterNumeroPorExtenso(numero)
            };
            return CustomResponse(result);
        }

        [HttpGet]
        [Route("numero-dolar")]
        public async Task<ActionResult<ConversaoNumerica>> NumeroParaDolar(int numero)
        {

            var result = new ConversaoNumerica
            {
                TextoConversao = await ObterNumeroParaDolar(numero)
            };
            return CustomResponse(result);
        }

        private async Task<string> ObterNumeroPorExtenso(int numero)
        {
            try
            {
                return _soapClient.NumberToWords(Convert.ToUInt64(numero));
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }

        private async Task<string> ObterNumeroParaDolar(int numero)
        {
            try
            {
                return _soapClient.NumberToDollars(Convert.ToUInt64(numero));
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw;
            }
        }
    }
}
