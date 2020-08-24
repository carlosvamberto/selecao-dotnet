using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndraApp.ApplicationCore.Entities
{
    [Table("Matricula")]
    public class Matricula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatriculaId { get; set; }

        [Required]
        [ForeignKey("Estudante")]
        public int EstudanteId { get; set; }

        [Required]
        [ForeignKey("Curso")]
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}
