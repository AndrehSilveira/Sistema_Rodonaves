using Sistema_Rodonaves.Models;

namespace Sistema_Rodonaves.Repository.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<List<Colaboradore>> BuscarTodosColaboradores();
        Task<Colaboradore> BuscarPorId(int id);
        Task<Colaboradore> Adicionar(Colaboradore colaborador);
        Task<Colaboradore> Atualizar(Colaboradore colaborador, int id);
        Task<string> Apagar(int id);
    }
}
