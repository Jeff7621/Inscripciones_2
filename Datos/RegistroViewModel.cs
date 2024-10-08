﻿using System.ComponentModel.DataAnnotations;

namespace Validacion_WEB.Datos
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido...")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un Correo electronico valido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido...")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
