using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pdvPRO.Data;
using pdvPRO.DTO;
using pdvPRO.Models;

namespace pdvPRO.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly ApplicationDbContext database;
        public FornecedoresController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(FornecedorDTO fornecedorTemporaria)
        {
            if (ModelState.IsValid)
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = fornecedorTemporaria.Nome;
                fornecedor.Email = fornecedorTemporaria.Email;
                fornecedor.Telefone = fornecedorTemporaria.Telefone;
                fornecedor.Status = true;
                database.Fornecedores.Add(fornecedor);
                database.SaveChanges();
                return RedirectToAction("Fornecedores", "Gestao");
            }
            else
            {
                return View("../Gestao/NovoFornecedor");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(FornecedorDTO fornecedorTemporario)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = database.Fornecedores.First(forne => forne.Id == fornecedorTemporario.Id);
                fornecedor.Nome = fornecedorTemporario.Nome;
                fornecedor.Email = fornecedorTemporario.Email;
                fornecedor.Telefone = fornecedorTemporario.Telefone;
                database.SaveChanges();
                return RedirectToAction("Fornecedores", "Gestao");
            }
            else
            {
                return View("../Gestao/EditarFornecedor");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if(id > 0)
            {
                var fornecedor = database.Fornecedores.First(forne => forne.Id == id);
                fornecedor.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Fornecedores", "Gestao");
        }

    }
}