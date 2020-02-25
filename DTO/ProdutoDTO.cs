using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pdvPRO.DTO
{
    public class ProdutoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome do produto é obrigatório")]
        [StringLength(100,ErrorMessage ="Nome do produto tem que ter menos de 100 caracteres")]
        [MinLength(2,ErrorMessage ="Nome do produto é muito curto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Categoria do produto é obrigatória")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Fornecedor do produto é obrigatório")]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "Preço de custo do produto é obrigatório")]
        public float PrecoCusto { get; set; }

        [Required(ErrorMessage = "Preço de custo do produto é obrigatório")]
        public string PrecoCustoString { get; set; }


        [Required(ErrorMessage = "Preço de venda é obrigatório")]
        public float PrecoVenda { get; set; }

        [Required(ErrorMessage = "Preço de venda é obrigatório")]
        public string PrecoVendaString { get; set; }

        [Required(ErrorMessage = "Unidade de medida do produto é obrigatória")]
        [Range(0,2,ErrorMessage ="Unidade de medida inválida")]
        public int UnidadeMedida { get; set; }
    }
}
