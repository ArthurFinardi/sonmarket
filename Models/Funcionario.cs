using System;
namespace Sismarket.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime DtNascimento { get; set; }        
    }
}