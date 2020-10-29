using System;
namespace Sismarket.Models
{
    public class Saida
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public float ValorDeVenda { get; set; }
        public DateTime Data { get; set; }
        public Venda Venda { get; set; }
        public Cliente Cliente { get; set; }
    }
}