using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndraApp.ApplicationCore.Entities
{
    [Table("Estudante")]
    public class Estudante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstudanteId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [ForeignKey("Cartao")]
        public int? CartaoId { get; set; }
        public Cartao Cartao { get; set; }

    }
}
