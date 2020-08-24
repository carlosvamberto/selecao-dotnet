using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndraApp.ApplicationCore.Entities
{
    [Table("Curso")]
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CursoId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

    }
}
