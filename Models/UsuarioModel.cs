using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id_Usuario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]

        public string? Correo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]

        public int Edad { get; set; }
        [Required(ErrorMessage = "Campo requerido")]

        public string? Usuario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Clave { get; set; }
    }
}