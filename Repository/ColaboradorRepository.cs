using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Rodonaves.Data;
using Sistema_Rodonaves.Models;
using Sistema_Rodonaves.Repository.Interfaces;

namespace Sistema_Rodonaves.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly Api_Crud_CsharpContext _dbContext;
        public ColaboradorRepository(Api_Crud_CsharpContext sistemaRodonavesDBContext)
        {
            _dbContext = sistemaRodonavesDBContext;
        }
        public async Task<Colaboradore> BuscarPorId(int id)
        {
            return await _dbContext.Colaboradores
                .Include(x => x.IdUnidadeNavigation)
                .Include(x => x.IdUsuarioNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Colaboradore>> BuscarTodosColaboradores()
        {
            return await _dbContext.Colaboradores
                .Include(x => x.IdUnidadeNavigation)
                .Include(x => x.IdUsuarioNavigation)
                .ToListAsync();
        }
        public async Task<Colaboradore> Adicionar(Colaboradore colaborador)
        {
            await _dbContext.Colaboradores.AddAsync(colaborador);
            await _dbContext.SaveChangesAsync();

            return colaborador;
        }

        public async Task<Colaboradore> Atualizar(Colaboradore colaborador, int id)
        {
            Colaboradore colaboradorPorId = await BuscarPorId(id);

            if (colaboradorPorId == null)
            {
                throw new Exception($"Colaborador com ID: {id} não foi encontrado.");
            }

            colaboradorPorId.Nome = colaboradorPorId.Nome;
            colaboradorPorId.IdUnidade = colaborador.IdUnidade;
            colaboradorPorId.IdUsuario = colaborador.IdUsuario;

            _dbContext.Colaboradores.Update(colaboradorPorId);
            await _dbContext.SaveChangesAsync();

            return colaboradorPorId;
        }

        public async Task<string> Apagar(int id)
        {
            Colaboradore colaboradorPorId = await BuscarPorId(id);

            if (colaboradorPorId == null)
            {
                throw new Exception($"Colaborador com ID: {id} não foi encontrado.");
            }

            _dbContext.Colaboradores.Remove(colaboradorPorId);
            await _dbContext.SaveChangesAsync();

            return $"Colaborador {id} removido com sucesso.";
        }


    }
}
