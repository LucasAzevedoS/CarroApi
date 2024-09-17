using CarroApi.Dto.Carro;
using CarroApi.Models;

namespace CarroApi.Services.carro
{
    public interface ICarroInterface
    {
        Task<ResponseModel<List<CarroModel>>> ListarCarros();
        Task<ResponseModel<CarroModel>> ObterCarroPorId(int Id);
        Task<ResponseModel<List<CarroModel>>> CriarCarro(CarroCriacaoDto carroCriacaoDto);
    }
}
