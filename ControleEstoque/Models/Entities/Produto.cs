using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Models.Entities
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string CodigoProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVenda { get; set; }
        public int Qtd_Estoque { get; set; }
        public TipoProduto? TipoProduto { get; set; }
        public Marca? Marca { get; set; }
        public int? FornecedorID { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public bool Ativo { get; set; }
        // chaves estrangeiras

    }
}
