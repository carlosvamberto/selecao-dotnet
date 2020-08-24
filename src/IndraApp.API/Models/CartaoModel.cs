using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndraApp.API.Models
{
    public class CartaoModel
    {       
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
