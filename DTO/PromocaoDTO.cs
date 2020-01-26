using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

    namespace pdvPRO.DTO
{
    public class PromocaoDTO
    {
        [Required]
        public int Id { get; set; }
        [StringLength(100)]
        [MinLength(3)]
        public string Nome { get; set; }
        [Required]
        public int ProdutoID { get; set; }
        [Range(0,100)]
        public float Porcentagem { get; set; }
    }
}
