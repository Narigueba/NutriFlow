using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NutriFlowAPI.Models.Usuario
{
    public class PaisModel
    {
        [Key]
        public int Id { get; set; }
        public string Pais { get; set; }
        [JsonIgnore] // Ignora a necessidade de inserir todas as cidades de um Pais de uma só vez
        public ICollection<CidadeModel> Cidade { get; set; }
        public ICollection<UsuarioModel> Usuarios { get; set; }
    }
}
