using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Rodonaves.Data;
using Sistema_Rodonaves.DTO;
using Sistema_Rodonaves.Models;
using Sistema_Rodonaves.Repository.Interfaces;

namespace Sistema_Rodonaves.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Api_Crud_CsharpContext _dbContext;
        public UsuarioRepository(Api_Crud_CsharpContext sistemaRodonavesDBContext)
        {
            _dbContext = sistemaRodonavesDBContext;
        }
        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<List<Usuario>> BuscarPorStatus(int status)
        {
            var usuario = await _dbContext.Usuarios.Where(x => x.Status == status).ToListAsync();

            return usuario;
        }

        public async Task<Usuario> Atualizar(UsuarioAlteraDTO usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não foi encontrado.");
            }

            //usuarioPorId.Login = usuarioPorId.Login;
            usuarioPorId.Senha = usuario.Senha;
            usuarioPorId.Status = usuario.Status;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }


    }
}
