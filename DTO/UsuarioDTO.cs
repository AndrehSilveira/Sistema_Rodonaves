using Sistema_Rodonaves.Models;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Rodonaves.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public int Status { get; set; }

    }

    public class UsuarioAlteraDTO
    {
        public int Id { get; set; }
        public string Senha { get; set; } = null!;
        [Required]
        public int Status { get; set; }

    }
}
