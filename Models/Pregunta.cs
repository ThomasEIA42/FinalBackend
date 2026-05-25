using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBackendWeb.Models
{
    public class Pregunta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid id_Pregunta { get; set; }

        [Required]

        public String Enunciado { get; set; } = String.Empty;

        [Required]

        public String Categoria {  get; set; } = String.Empty;

        [Required]

        public String Estado {  get; set; } = "Sin resolver";


    }
}
