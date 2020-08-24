using System.ComponentModel.DataAnnotations;

namespace IndraApp.API.Models
{
    public class MatriculaModel
    {   
        public int MatriculaId { get; set; }

        [Required]        
        public int EstudanteId { get; set; }

        [Required]
        public int CursoId { get; set; }
    }
}
