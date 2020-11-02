using Microsoft.AspNetCore.Mvc;
using Sismarket.DTO;
using System.Linq;
using Sismarket.Data;
using Sismarket.Models;

namespace sismarket.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly ApplicationDbContext database;
        public PromocoesController(ApplicationDbContext database){
            this.database = database;
        }
        [HttpPost]
        public IActionResult Salvar(PromocaoDTO pPromocao){
            if(ModelState.IsValid){
                Promocao promocao = new Promocao();
                promocao.Nome = pPromocao.Nome;
                //buscando no bd o produto q tem o id qual o prod do form
                promocao.Produto = database.Produtos.First(prod => prod.Id == pPromocao.ProdutoID);
                promocao.Porcentagem = pPromocao.Porcentagem;
                promocao.Status = true;
                database.Promocoes.Add(promocao);
                database.SaveChanges();
                return RedirectToAction("Promocoes", "Gestao");
            }else{
                ViewBag.Produtos = database.Produtos.ToList();
                return View("../Gestao/NovaPromocao");
            }
        }
        [HttpPost]
        public IActionResult Atualizar(PromocaoDTO pPromocao){
            if(ModelState.IsValid){
                var promocao = database.Promocoes.First(p => p.Id == pPromocao.Id);
                promocao.Nome = pPromocao.Nome;
                promocao.Produto = database.Produtos.First(prod => prod.Id == pPromocao.ProdutoID);
                promocao.Porcentagem = pPromocao.Porcentagem;
                database.SaveChanges();
                return RedirectToAction("Promocoes", "Gestao");
            }else{
                return RedirectToAction("Promocoes", "Gestao");
            }
        }
        public IActionResult Deletar(int id){
            if(id > 0){
                var promocao = database.Promocoes.First(p => p.Id == id);
                promocao.Status = false;
                database.SaveChanges();
                
            }
            return RedirectToAction("Promocoes", "Gestao");
        }
    }
}