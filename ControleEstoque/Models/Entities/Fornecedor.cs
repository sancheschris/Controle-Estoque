using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Models.Entities
{
    public class Fornecedor
    {
        public int FornecedorID { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int CEP { get; set; }
        public int PaisID { get; set; }
        public Pais Pais { get; set; }
        public int EstadoID { get; set; }
        public Estado Estado { get; set; }
        public int CidadeID { get; set; }
        public Cidade Cidade { get; set; }
        public bool Ativo { get; set; }
    }
}
