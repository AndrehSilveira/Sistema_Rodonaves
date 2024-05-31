using System;
using System.Collections.Generic;

namespace Sistema_Rodonaves.Models
{
    public partial class Unidade
    {
        public Unidade()
        {
            Colaboradores = new HashSet<Colaboradore>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public byte? Status { get; set; }

        public virtual ICollection<Colaboradore> Colaboradores { get; set; }
    }
}
