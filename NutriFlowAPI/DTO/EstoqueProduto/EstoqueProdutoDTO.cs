namespace NutriFlowAPI.DTO.EstoqueProduto
{
    public class EstoqueProdutoDTO
    {

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; } // ← novo

        public int CategoriaId { get; set; }
        public string Categoria { get; set; } // ← novo

        public int ProdutoId { get; set; }
        public string Produto { get; set; } // ← novo

        public int MarcaId { get; set; }
        public string Marca { get; set; } // ← novo

        public decimal Quantidade { get; set; }

        public int UnidadeMedidaId { get; set; }
        public string UnidadeMedida { get; set; } // ← novo

        public decimal Preco { get; set; }

        public int EstabelecimentoId { get; set; }
        public string Estabelecimento { get; set; } // ← novo

        public DateTime DataRegisto { get; set; }
        public DateTime? DataValidade { get; set; }

        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
