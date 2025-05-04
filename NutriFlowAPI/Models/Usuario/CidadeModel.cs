using System.ComponentModel.DataAnnotations;

namespace NutriFlowAPI.Models.Usuario
{
    public class CidadeModel
    {
        [Key]
        public int Id { get; set; }
        public string Cidade { get; set; }
        public PaisModel Pais { get; set; }
        public ICollection<UsuarioModel> Usuarios { get; set; }

    }
}
