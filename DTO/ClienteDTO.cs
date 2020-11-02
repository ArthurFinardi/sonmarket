using System;
using System.ComponentModel.DataAnnotations;

namespace Sismarket.DTO
{
    public class ClienteDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage="O Nome é obrigatório.")]
        [StringLength(100, MinimumLength= 5, ErrorMessage="O Nome deve ter no mínimo 5 e no máximo 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage ="Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }
        [Required(ErrorMessage="O CPF é obrigatório. ")]
        public string Cpf { get; set; }
        [Required(ErrorMessage="Informe o Telefone. ")]
        public string Telefone { get; set; }
        [Required(ErrorMessage="Informe o Endereço. ")]
        public string Endereco { get; set; }
        [Required(ErrorMessage="Informe o bairro.")]
        public string Bairro { get; set; }
        //[Required(ErrorMessage = "Informe o email do cliente")]
        [StringLength(100, MinimumLength= 5, ErrorMessage="O Nome deve ter no mínimo 5 e no máximo 100 caracteres.")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [Required(ErrorMessage="Informe a data de nascimento.")]
        public DateTime DtNascimento { get; set; }
    }
}