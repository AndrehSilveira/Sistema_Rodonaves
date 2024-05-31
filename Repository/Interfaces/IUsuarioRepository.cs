using Sistema_Rodonaves.Models;

namespace Sistema_Rodonaves.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario, int id);
    }
}
