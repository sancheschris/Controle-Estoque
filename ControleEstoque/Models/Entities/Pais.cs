using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Models.Entities
{
    public class Pais
    {
        public int PaisID { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
