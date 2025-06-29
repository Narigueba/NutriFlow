﻿namespace NutriFlowAPI.DTO.EstoqueProduto
{
    public class EstoqueProdutoEdicaoDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int ProdutoId { get; set; }
        public int MarcaId { get; set; }
        public decimal Quantidade { get; set; }
        public int UnidadeMedidaId { get; set; }
        public decimal Preco { get; set; }
        public int EstabelecimentoId { get; set; }
        public DateTime? DataValidade { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
