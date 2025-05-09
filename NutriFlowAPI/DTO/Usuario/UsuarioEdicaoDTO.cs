using NutriFlowAPI.Models.Usuario;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutriFlowAPI.DTO.Usuario
{
    public class UsuarioEdicaoDTO
    {
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
        public int CidadeId { get; set; }

    }
}
