using System.ComponentModel.DataAnnotations;
namespace Sismarket.DTO
{
    public class ProdutoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage="O nome do produto é obrigatório. ")]
        [StringLength(100, ErrorMessage="O nome do produto ultrapassou o limite de caractéres. ")]
        [MinLength(2, ErrorMessage="O nome do produto necessita de mais caractéres. ")]
        public string Nome { get; set; }
        [Required(ErrorMessage="A categoria do produto é obrigatória. ")]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage="O fornecedor do produto é obrigatório. ")]
        public int FornecedorID { get; set; }
        [Required(ErrorMessage="O preço do produto de custo do produto é obrigatório. ")]
        public float PrecodeCusto { get; set; }
        [Required(ErrorMessage="O preço do produto de custo do produto é obrigatório. ")]
        public float PrecodeVenda { get; set; }
        [Required(ErrorMessage="A Medição do produto é obrigatória. ")]
        [Range(0,2, ErrorMessage="Medição inválida. ")]
        public int Medicao { get; set; }        
    }
}