using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pdvPRO.DTO
{
    public class CategoriaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [StringLength(100,ErrorMessage ="Nome da categoria muito grande")]
        [MinLength(2,ErrorMessage ="Nome da categora muito pequeno")]
        public string Nome { get; set; }
    }
}
