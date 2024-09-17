using CarroApi.Dto.Carro;
using CarroApi.Models;
using CarroApi.Services.carro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroInterface _carroInterface;
        public CarroController(ICarroInterface carroInterface)
        {
            _carroInterface = carroInterface;
        }

        [HttpGet("listarCarros")]
        public async Task<ActionResult<ResponseModel<List<CarroModel>>>> listarCarros()
        {
            var carros = await _carroInterface.ListarCarros();
            return Ok(carros);
        }

        [HttpGet("obterCarroPorId")]
        public async Task<ActionResult<ResponseModel<CarroModel>>> obterCarroPorId(int Id)
        {
            var carro = await _carroInterface.ObterCarroPorId(Id);
            return Ok(carro);
        }
        [HttpPost("criarCarro")]
        public async Task<ActionResult<ResponseModel<CarroModel>>> criarCarro(CarroCriacaoDto carroCriacaoDto)
        {
            var carros = await _carroInterface.CriarCarro(carroCriacaoDto);
            return Ok(carros);
        }
    }
}
