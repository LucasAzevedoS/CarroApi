using CarroApi.Models;

namespace CarroApi.Services.carro
{
    public interface ICarroInterface
    {
        Task<ResponseModel<List<CarroModel>>> ListarCarros();
        Task<ResponseModel<CarroModel>> ObterCarroPorId(int Id);
    }
}
