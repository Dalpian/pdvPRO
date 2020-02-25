using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pdvPRO.Data;
using pdvPRO.Models;

namespace pdvPRO.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly ApplicationDbContext database;

        public EstoqueController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(Estoque estoqueTemp)
        {
            database.Estoques.Add(estoqueTemp);
            database.SaveChanges();
            return RedirectToAction("Estoque", "Gestao");
        }

        [HttpPost]
        public IActionResult Atualizar(Estoque estoqueTemp)
        {
            if (ModelState.IsValid)
            {
                var estoque = database.Estoques.First(prod => prod.Id == estoqueTemp.Id);
                estoque.Quantidade = estoqueTemp.Quantidade;
                database.SaveChanges();
                return RedirectToAction("Estoque", "Gestao");
            }
            else
            {
                return View("../Gestao/EditarFornecedor");
            }
        }
    }
}