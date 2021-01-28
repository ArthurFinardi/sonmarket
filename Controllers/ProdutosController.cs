using System;
using Microsoft.AspNetCore.Mvc;
using Sismarket.Data;
using Sismarket.DTO;
using System.Linq;
using Sismarket.Models;
using Microsoft.EntityFrameworkCore;

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
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == pProduto.CategoriaID);
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == pProduto.FornecedorID);

                produto.PrecodeCusto = pProduto.PrecodeCusto;
                produto.PrecodeVenda = pProduto.PrecodeVenda;
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
        public IActionResult Atualizar(ProdutoDTO pProduto){
            if(ModelState.IsValid){
                var produto = database.Produtos.First(p => p.Id == pProduto.Id);
                produto.Nome = pProduto.Nome;
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == pProduto.CategoriaID);
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == pProduto.FornecedorID);

                produto.PrecodeCusto = pProduto.PrecodeCusto;
                produto.PrecodeVenda = pProduto.PrecodeVenda;
                produto.Medicao = pProduto.Medicao;
                database.SaveChanges();
                return RedirectToAction("Produtos", "Gestao");
            }else{
                return RedirectToAction("Produtos", "Gestao");
            }
        }
        public IActionResult Deletar(int id){
            if(id > 0){
                var produto = database.Produtos.First(p => p.Id == id);
                produto.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Produtos", "Gestao");
        }
        [HttpPost]
        public IActionResult Produto(int id){
            if(id > 0){
                var produto = database.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor).First(p => p.Id == id);
                if(produto != null){
                    return Json(produto);
                }
                else{
                    return Json(null);
                }
            }
            else{
                return Json(null);
            }
        }
    }
}