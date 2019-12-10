using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pdvPRO.DTO
{
    public class FornecedorDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do fornecedor é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome do fornecedor muito grande")]
        [MinLength(2, ErrorMessage = "Nome do fornecedor muito pequeno")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O fone do fornecedor é obrigatório")]
        [Phone(ErrorMessage = "Fone inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail do fornecedor é obrigatório")]
        [EmailAddress(ErrorMessage ="E-mail inválido")]
        public string Email { get; set; }
    }
}
