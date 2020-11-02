using System.ComponentModel.DataAnnotations;

namespace Sismarket.DTO
{
    public class PromocaoDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="O nome do produto é obrigatório. ")]
        [StringLength(100, ErrorMessage="O nome do produto ultrapassou o limite de caractéres. ")]
        [MinLength(3, ErrorMessage="O nome do produto necessita de mais caractéres. ")]
        public string Nome { get; set; }
        [Required(ErrorMessage="É necessário inserir o produto da promoção. ")]
        public int ProdutoID { get; set; }
        [Required(ErrorMessage="A porcentagem da promoção é obrigatória.")]
        [Range(0, 100)]
        public float Porcentagem { get; set; }
    }
}