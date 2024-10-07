using System.ComponentModel.DataAnnotations;

namespace Validacion_WEB.Models
{
    public class MatriculaEstudiante
    {

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El {0} no puede exceder de {1} caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El {0} no puede exceder de {1} caracteres")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date, ErrorMessage = "Fecha de nacimiento no válida")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNac { get; set; }


        [Required(ErrorMessage ="El campo {0} es necesario")]
        public string? Correo { get; set; }


        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(8, ErrorMessage = "El {0} no puede exceder de {1} caracteres")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(8, ErrorMessage = "El {0} no puede exceder de {1} caracteres")]
        public string? Nie { get;set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El {0} no puede exceder de {1} caracteres")]
        public string? Responsable { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Phone(ErrorMessage = "El número de teléfono no es válido")]
        [Display(Name = "Teléfono del Responsable")]
        public string TelefonoRes{ get; set; }

        [Required(ErrorMessage = "Debe seleccionar una opción de Bachillerato")]
        [Display(Name = "Opción de Bachillerato")]
        public string? OpcionBachillerato { get; set; }

       
    }
}
