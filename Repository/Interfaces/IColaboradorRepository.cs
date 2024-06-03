using Sistema_Rodonaves.DTO;
using Sistema_Rodonaves.Models;

namespace Sistema_Rodonaves.Repository.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<List<Colaboradore>> BuscarTodosColaboradores();
        Task<Colaboradore> BuscarPorId(int id);
        Task<ColaboradorDTO> Adicionar(ColaboradorDTO colaborador);
        Task<Colaboradore> Atualizar(ColaboradorDTO colaborador, int id);
        Task<string> Apagar(int id);
    }
}
