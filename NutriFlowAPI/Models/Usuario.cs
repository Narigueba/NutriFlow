﻿namespace NutriFlowAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public ICollection<EstoqueAlimento> Estoque { get; set; }
    }
}
