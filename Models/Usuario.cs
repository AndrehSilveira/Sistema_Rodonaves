using System;
using System.Collections.Generic;

namespace Sistema_Rodonaves.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Colaboradores = new HashSet<Colaboradore>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<Colaboradore> Colaboradores { get; set; }
    }
}
