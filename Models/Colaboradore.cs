using System;
using System.Collections.Generic;

namespace Sistema_Rodonaves.Models
{
    public partial class Colaboradore
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int? IdUnidade { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Unidade? IdUnidadeNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
