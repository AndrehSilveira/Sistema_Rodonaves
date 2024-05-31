using Sistema_Rodonaves.Models;

namespace Sistema_Rodonaves.Repository.Interfaces
{
    public interface IUnidadeRepository
    {
        Task<List<Unidade>> BuscarTodasUnidades();
        Task<Unidade> BuscarPorId(int id);
        Task<Unidade> Adicionar(Unidade unidade);
        Task<Unidade> Atualizar(Unidade unidade, int id);
    }
}
