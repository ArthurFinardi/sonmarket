using System;
using Microsoft.AspNetCore.Mvc;
using Sismarket.Data;
using Sismarket.DTO;
using Sismarket.Models;
namespace Sismarket.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly ApplicationDbContext database;

        public FornecedoresController(ApplicationDbContext pDatabase){
            this.database = pDatabase;
        }

        [HttpPost]
        public IActionResult Salvar(FornecedorDTO pFornecedor){
            if (ModelState.IsValid)
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = pFornecedor.Nome;
                fornecedor.Email = pFornecedor.Email;
                fornecedor.Telefone = pFornecedor.Telefone;
                fornecedor.Status = true;

                database.Fornecedores.Add(fornecedor);
                database.SaveChanges();
                return RedirectToAction("Fornecedores", "Gestao");
            }else{
                return View("..Gestao/NovoFornecedor");
            }
        }
    }
}