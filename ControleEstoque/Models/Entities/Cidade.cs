using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Models.Entities
{
    public class Cidade
    {
        public int CidadeID { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int? EstadoID { get; set; }
        public Estado Estado { get; set; }
        public int? PaisID { get; set; }
        public Pais Pais { get; set; }
    }
}
