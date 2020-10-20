using System;

namespace sismarket.Models
{
    public class Saida
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public float ValorDeVenda { get; set; }
        public DateTime Data { get; set; }
    }
}