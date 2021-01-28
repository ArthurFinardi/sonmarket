using Microsoft.AspNetCore.Mvc;
using Sismarket.Data;
using Sismarket.Models;

namespace sismarket.Controllers
{
    public class EstoquesController : Controller
    {
        //Injeção de Dependência (Conexão com banco de dados)
        private readonly ApplicationDbContext database;

        public EstoquesController(ApplicationDbContext pDatabase){
            this.database = pDatabase;
        }

        [HttpPost]
        public IActionResult Salvar(Estoque pEstoque){
            database.Estoques.Add(pEstoque);
            database.SaveChanges();
            return RedirectToAction("Estoque", "Gestao");
        }


    }
}