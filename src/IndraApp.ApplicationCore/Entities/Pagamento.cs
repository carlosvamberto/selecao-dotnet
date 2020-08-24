using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndraApp.ApplicationCore.Entities
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagamentoId { get; set; }

        [Required]
        [ForeignKey("Estudante")]
        public int EstudanteId { get; set; }
        public Estudante Estudante { get; set; }

        [Required]
        public DateTime Vencimento { get; set; }

        [Required]
        public bool Pago { get; set; } = false;
    }
}
