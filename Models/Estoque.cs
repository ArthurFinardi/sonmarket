namespace Sismarket.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }
        public float Quantidade { get; set; }       
    }
}