using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Validacion_WEB.Datos
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo{0} debe ser un Correo electronico")]

        public string Email { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Recuerdame")]

        public bool Recuerdame { get; set; }

    }
}
