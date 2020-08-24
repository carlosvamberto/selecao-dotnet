using System.ComponentModel.DataAnnotations;

namespace IndraApp.API.Models
{
    public class CursoModel
    {
        public int CursoId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
    }
}
