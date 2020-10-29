using System;
using Microsoft.AspNetCore.Mvc;
using Sismarket.Data;
using Sismarket.DTO;
using System.Linq;
using Sismarket.Models;

namespace sismarket.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext database;

        public ProdutosController(ApplicationDbContext database){
            this.database = database;
        }
        [HttpPost]
        public IActionResult Salvar(ProdutoDTO pProduto){
            if(ModelState.IsValid){
                Produto produto = new Produto();
                produto.Nome = pProduto.Nome;
                //verifica se o Id passado no formulário é o mesmo ID buscado no BD
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == pProduto.CategoriaID);
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == pProduto.FornecedorID);

                produto.PrecodeCusto = pProduto.PrecodeCusto;
                produto.PrecodeCusto = pProduto.PrecodeVenda;
                produto.Medicao = pProduto.Medicao;
                produto.Status = true;

                database.Produtos.Add(produto);
                database.SaveChanges();
                return RedirectToAction("Produtos", "Gestao");
            }
            else{
                ViewBag.Categorias = database.Categorias.ToList();
                ViewBag.Fornecedores = database.Fornecedores.ToList();

                return View("../Gestao/NovoProduto");
            }
        }
    }
}