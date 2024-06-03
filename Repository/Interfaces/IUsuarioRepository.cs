using Sistema_Rodonaves.DTO;
using Sistema_Rodonaves.Models;

namespace Sistema_Rodonaves.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarPorId(int id);
        Task<List<Usuario>> BuscarPorStatus(int status);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(UsuarioAlteraDTO usuario, int id);
    }
}
