using CarroApi.Data;
using CarroApi.Dto.Carro;
using CarroApi.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<ResponseModel<List<CarroModel>>> CriarCarro(CarroCriacaoDto carroCriacaoDto)
        {
            ResponseModel<List<CarroModel>> resposta = new ResponseModel<List<CarroModel>>();

            try
            {

                var carro = new CarroModel()
                {
                    Marca = carroCriacaoDto.Marca,
                    Modelo = carroCriacaoDto.Modelo,
                    Ano = carroCriacaoDto.Ano,
                    Cor = carroCriacaoDto.Cor
                };
                _context.Add(carro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Carros.ToListAsync();
                return resposta;
                resposta.Mensagem = "Carro criado com sucesso"; 
            }
            
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<CarroModel>>> EditarCarro(CarroEdicaoDto carroEdicaoDto)
        {
            ResponseModel<List<CarroModel>> resposta = new ResponseModel<List<CarroModel>>();

            try
            {
                var carro =  _context.Carros
                    .FirstOrDefault(carroBanco => carroBanco.Id == carroEdicaoDto.Id);
                if(carro == null)
                {
                    resposta.Mensagem = "Carro não encontrado";
                    return resposta;
                }

                carro.Marca = carroEdicaoDto.Marca;
                carro.Modelo = carroEdicaoDto.Modelo;       
                carro.Ano = carroEdicaoDto.Ano;
                carro.Cor = carroEdicaoDto.Cor;
               _context.Update(carro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Carros.ToListAsync();
                resposta.Mensagem = "Carro editado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<CarroModel>>> ExcluirCarro(int Id)
        {
            ResponseModel<List<CarroModel>> resposta = new ResponseModel<List<CarroModel>>();

            try
            {
                var carro = await _context.Carros
                    .FirstOrDefaultAsync(carroBanco => carroBanco.Id == Id);

                if(carro == null)
                {
                    resposta.Mensagem = "Carro não encontrado";
                    return resposta;
                }
                _context.Remove(carro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Carros.ToListAsync();
                resposta.Mensagem = "Carro excluído com sucesso";
                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
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
                if (carro == null)
                {
                    resposta.Mensagem = "Carro não encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = carro;
                resposta.Mensagem = "Carro encontrado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
