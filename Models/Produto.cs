namespace sismarket.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MyProperty { get; set; }
        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public float PrecodeCusto { get; set; }
        public float PrecodeVenda { get; set; }
        public int Medicao { get; set; }
        public bool Status { get; set; }
    }
}