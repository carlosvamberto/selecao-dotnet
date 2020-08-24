using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndraApp.ApplicationCore.Entities
{
    [Table("Cartao")]
    public class Cartao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartaoId { get; set; }

        [Required]
        [MaxLength(16)]
        public string Numero { get; set; }

        [Required]
        public string Validade { get; set; }

        [Required]
        public string Chave { get; set; }
    }
}
