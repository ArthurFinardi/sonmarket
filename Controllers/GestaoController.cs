using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sismarket.Data;
using Sismarket.DTO;
using Microsoft.EntityFrameworkCore;

namespace Sismarket.Controllers
{
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext database;
        public GestaoController(ApplicationDbContext pDatabase){
            this.database = pDatabase;
        }
        public IActionResult Index(){
            return View();
        }
        public IActionResult Categorias(){
            var categorias = database.Categorias.Where(cat => cat.Status == true).ToList();
            return View(categorias);
        }
        public IActionResult NovaCategoria(){
            return View();
        }
        public IActionResult EditarCategoria(int id){
            var categoria = database.Categorias.First(cat => cat.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO();
            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;

            return View(categoriaView);
        }
        public IActionResult Fornecedores(){
            var fornecedores = database.Fornecedores.Where(fornecedores => fornecedores.Status == true).ToList();
            return View(fornecedores);
        }
        
        public IActionResult NovoFornecedor(){
            return View();
        }

        public IActionResult EditarFornecedor(int id){
            var fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == id);
            FornecedorDTO fornecedorView = new FornecedorDTO();
            fornecedorView.Id = fornecedor.Id;
            fornecedorView.Nome = fornecedor.Nome;
            fornecedorView.Email = fornecedor.Email;
            fornecedorView.Telefone = fornecedor.Telefone;

            return View(fornecedorView);
        }

        public IActionResult Produtos(){
            var produtos = database.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor).Where(p => p.Status == true).ToList();
            return View(produtos);
        }
        public IActionResult NovoProduto(){
            ViewBag.Categorias = database.Categorias.ToList();
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View();
        }
        public IActionResult EditarProduto(int id){
            var produto = database.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor).First(p => p.Id == id);
            ProdutoDTO produtoView = new ProdutoDTO();
            produtoView.Id = produto.Id;
            produtoView.Nome = produto.Nome;
            produtoView.PrecodeCusto = produto.PrecodeCusto;
            produtoView.PrecodeVenda = produto.PrecodeVenda;
            produtoView.CategoriaID = produto.Categoria.Id;
            produtoView.FornecedorID = produto.Fornecedor.Id;
            produtoView.Medicao = produto.Medicao;
            ViewBag.Categorias = database.Categorias.ToList();
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View(produtoView);
        }
        public IActionResult Promocoes(){
            //buscando promoções que contenham um produto e estejam com o status verdadeiro
            var promocoes = database.Promocoes.Include(p => p.Produto).Where(i => i.Status == true).ToList();
            return View(promocoes);
        }
        public IActionResult NovaPromocao(){
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }
        public IActionResult EditarPromocao(int id){
            var promocao = database.Promocoes.Include(p => p.Produto).First(p => p.Id == id);
            PromocaoDTO promo = new PromocaoDTO();
            promo.Id = promocao.Id;
            promo.Nome = promocao.Nome;
            promo.Porcentagem = promocao.Porcentagem;
            promo.ProdutoID = promocao.Produto.Id;
            ViewBag.Produtos = database.Produtos.ToList();
            return View(promo);
        }
        public IActionResult Estoque(){
            //buscando produtos da lista de estoque
            var listaEstoque = database.Estoques.Include(e => e.Produto).ToList();
            return View(listaEstoque);
        }
        
        public IActionResult NovoEstoque(){
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }

        public IActionResult EditarEstoque(){
            return Content("");
        }
    }
}