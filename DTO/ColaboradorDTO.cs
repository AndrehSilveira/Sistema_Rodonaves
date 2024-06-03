using Sistema_Rodonaves.Models;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Rodonaves.DTO
{
    public class ColaboradorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int? IdUnidade { get; set; }
        public int? IdUsuario { get; set; }

    }
}
