using System.ComponentModel.DataAnnotations;

namespace IndraApp.API.Models
{
    public class EstudanteModel
    {        
        public int EstudanteId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
                
        public int? CartaoId { get; set; }
        
    }
}
