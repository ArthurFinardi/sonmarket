using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sismarket.Data;
using Sismarket.DTO;
using Sismarket.Models;

namespace Sismarket.Controllers
{
    public class CategoriasController : Controller
    {
        //Injeção de Dependência (DI)
        private readonly ApplicationDbContext database;
        public CategoriasController(ApplicationDbContext pDatabase){
            this.database = pDatabase;
        }
        
        [HttpPost]
        public IActionResult Salvar(CategoriaDTO pCategoria){
            if(ModelState.IsValid){
                Categoria categoria = new Categoria();
                categoria.Nome= pCategoria.Nome;
                categoria.Status = true;

                database.Categorias.Add(categoria);
                database.SaveChanges();
                return RedirectToAction("Categorias", "Gestao");

            }else{
                return View("../Gestao/NovaCategoria");
            }

        }
        [HttpPost]
        public IActionResult Atualizar(CategoriaDTO pCategoria){
            if(ModelState.IsValid){
                //pegando o objeto do banco de dados
                var categoria = database.Categorias.First(cat => cat.Id == pCategoria.Id);
                //Alterando o mesmo
                categoria.Nome = pCategoria.Nome;

                database.SaveChanges();
                return RedirectToAction("Categorias", "Gestao");
            }
            else{

            }
            return View("../Gestao/EditarCategoria");
        }
        [HttpPost]
        public IActionResult Deletar(int id){
            if(id > 0){
                var categoria = database.Categorias.First(cat => cat.Id == id);
                categoria.Status = false;

                database.SaveChanges();
            }
            return RedirectToAction("Categorias", "Gestao");
        }
    }
}