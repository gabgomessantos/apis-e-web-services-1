using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CalculatorService;
using SOAPConsumerApi.Models;
using static CalculatorService.CalculatorSoapClient;

namespace SOAPConsumerApi.Controllers
{
    [Route("api/calculos")]
    [ApiController]
    public class CalculosController : MainController
    {
        private readonly CalculatorSoapClient _soapClient;

        public CalculosController()
        {
            _soapClient = new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap);
        }

        [HttpGet]
        [Route("soma")]
        public async Task<ActionResult<Calculo>> Soma(int numero1, int numero2)
        {
            
            var result = new Calculo {
                Resultado = await ObterSoma(numero1, numero2)
            };
            return CustomResponse(result);
        }

        [HttpGet]
        [Route("subtracao")]
        public async Task<ActionResult<Calculo>> Subtracao(int numero1, int numero2)
        {

            var result = new Calculo
            {
                Resultado = await ObterSubtracao(numero1, numero2)
            };
            return CustomResponse(result);
        }

        private async Task<int> ObterSoma(int numero1, int numero2)
        {
            try
            {
                return _soapClient.Add(numero1, numero2);
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }

        private async Task<int> ObterSubtracao(int numero1, int numero2)
        {
            try
            {
                return _soapClient.Subtract(numero1, numero2);
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }
    }
}
