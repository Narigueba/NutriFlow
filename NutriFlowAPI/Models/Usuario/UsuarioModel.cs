using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace NutriFlowAPI.Models.Usuario
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        //Tabelas Estrangeiras
        public int PaisId { get; set; }
        public PaisModel Pais { get; set; }
        public int CidadeId { get; set; }
        public CidadeModel Cidade { get; set; }
        public ICollection<EstoqueProdutoModel> EstoqueProdutos { get; set; }
    }
}
