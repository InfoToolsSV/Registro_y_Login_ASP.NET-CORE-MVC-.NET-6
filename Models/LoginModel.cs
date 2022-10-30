using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Campo requerido")]
        public string? Usuario { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string? Clave { get; set; }
    }
}