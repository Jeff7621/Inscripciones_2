using System.ComponentModel.DataAnnotations;

namespace Validacion_WEB.Models
{
    public class OpcionBachillerato
    {
        [Key]
        public int Id { get; set; }

        public string Bachilleratos { get; set; }
    }
}
