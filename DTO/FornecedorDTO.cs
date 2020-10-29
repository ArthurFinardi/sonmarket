using System.ComponentModel.DataAnnotations;
namespace Sismarket.DTO
{
    public class FornecedorDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage="Favor inserir um nome.")]
        [StringLength(100, ErrorMessage="Nome ultrapassou o limite de carácteres. Insira um nome menor.")]
        [MinLength(2, ErrorMessage="Nome com poucos caractéres. Insira um nome maior.")]
        public string Nome { get; set; }
    
        [Required(ErrorMessage="Favor inserir um e-mail.")]
        [EmailAddress(ErrorMessage="E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage="Favor inserir um telefone.")]
        [Phone(ErrorMessage="Número de Telefone inválido")]
        public string Telefone { get; set; }
    }
}