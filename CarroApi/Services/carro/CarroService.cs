using CarroApi.Data;
using CarroApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;

namespace CarroApi.Services.carro
{
    public class CarroService : ICarroInterface
    {
        private readonly AppDbContext _context;
        public CarroService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<CarroModel>>> ListarCarros()
        {
            ResponseModel<List<CarroModel>> resposta = new ResponseModel<List<CarroModel>>();
            try
            {
                
                var carros = await _context.Carros.ToListAsync();

                resposta.Dados = carros;
                resposta.Mensagem = "Carros listados com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<CarroModel>> ObterCarroPorId(int Id)
        {
            ResponseModel<CarroModel> resposta = new ResponseModel<CarroModel>();

            try
            {
                var carro = await _context.Carros.FirstOrDefaultAsync(carroBanco => carroBanco.Id == Id);
                if(carro == null)
                {
                    resposta.Mensagem = "Carro não encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = carro;
                resposta.Mensagem = "Carro encontrado com sucesso";
                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
