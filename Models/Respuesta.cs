using FinalBackendWeb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBackendWeb.Models
{
    public class Respuesta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Contenido { get; set; } = string.Empty;

        [Required]
        public int PreguntaId { get; set; }

        [ForeignKey("PreguntaId")]
        public virtual Pregunta? Pregunta { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}