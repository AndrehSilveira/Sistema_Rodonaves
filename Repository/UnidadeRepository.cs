using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Rodonaves.Data;
using Sistema_Rodonaves.Models;
using Sistema_Rodonaves.Repository.Interfaces;

namespace Sistema_Rodonaves.Repository
{
    public class UnidadeRepository : IUnidadeRepository
    {
        private readonly Api_Crud_CsharpContext _dbContext;
        public UnidadeRepository(Api_Crud_CsharpContext sistemaRodonavesDBContext)
        {
            _dbContext = sistemaRodonavesDBContext;
        }
        public async Task<Unidade> BuscarPorId(int id)
        {
            return await _dbContext.Unidades.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Unidade>> BuscarTodasUnidades()
        {
            return await _dbContext.Unidades.ToListAsync();
        }
        public async Task<Unidade> Adicionar(Unidade unidade)
        {
            await _dbContext.Unidades.AddAsync(unidade);
            await _dbContext.SaveChangesAsync();

            return unidade;
        }

        public async Task<Unidade> Atualizar(Unidade unidade, int id)
        {
            Unidade unidadePorId = await BuscarPorId(id);

            if (unidadePorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não foi encontrado.");
            }

            unidadePorId.Status = unidadePorId.Status;

            _dbContext.Unidades.Update(unidadePorId);
            await _dbContext.SaveChangesAsync();

            return unidadePorId;
        }


    }
}
