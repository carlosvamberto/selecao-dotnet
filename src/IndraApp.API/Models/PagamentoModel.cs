using System;
using System.ComponentModel.DataAnnotations;

namespace IndraApp.API.Models
{
    public class PagamentoModel
    {
        public int PagamentoId { get; set; }

        [Required]
        public int EstudanteId { get; set; }
        
        [Required]
        public DateTime Vencimento { get; set; }

        [Required]
        public bool Pago { get; set; } = false;
    }
}
