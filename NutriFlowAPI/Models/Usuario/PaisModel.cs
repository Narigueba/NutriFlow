using System.ComponentModel.DataAnnotations;

namespace NutriFlowAPI.Models.Usuario
{
    public class PaisModel
    {
        [Key]
        public int Id { get; set; }
        public string Pais { get; set; }
        public ICollection<UsuarioModel> Usuarios { get; set; }
    }
}
