﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pdvPRO.Data;
using pdvPRO.DTO;

namespace pdvPRO.Controllers
{
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext database;
        public GestaoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categorias()
        {
            var categorias = database.Categorias.Where(cat => cat.Status == true).ToList();
            return View(categorias);
        }

        public IActionResult NovaCategoria()
        {
            return View();
        }

        public IActionResult EditarCategoria(int id)
        {
           var categoria =  database.Categorias.First(cat => cat.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO();
            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;
            return View(categoriaView);
        }

        public IActionResult Fornecedores()
        {
            var fonecedores = database.Fornecedores.Where(forne => forne.Status == true).ToList();
            return View(fonecedores);
        }

        public IActionResult NovoFornecedor()
        {
            return View();
        }

        public IActionResult EditarFornecedor(int id)
        {
            var fornecedor = database.Fornecedores.First(forne => forne.Id == id);
            FornecedorDTO fornecedorView = new FornecedorDTO();
            fornecedorView.Id = fornecedor.Id;
            fornecedorView.Nome = fornecedor.Nome;
            fornecedorView.Email = fornecedor.Email;
            fornecedorView.Telefone = fornecedor.Telefone;

            return View(fornecedorView);
        }

        public IActionResult Produtos()
        {
            var produtos = database.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor).Where(p => p.Status ==true).ToList();
            return View(produtos);
        }

        public IActionResult NovoProduto()
        {
            ViewBag.Categorias = database.Categorias.ToList();
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View();
        }

        public IActionResult EditarProduto(int id)
        {
            var produto = database.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor).First(p => p.Id == id);
            ProdutoDTO produtoView = new ProdutoDTO();
            produtoView.Id = produto.Id;
            produtoView.Nome = produto.Nome;
            produtoView.PrecoCusto = produto.PrecoCusto;
            produtoView.PrecoVenda = produto.PrecoVenda;
            produtoView.CategoriaId = produto.Categoria.Id;
            produtoView.FornecedorId = produto.Fornecedor.Id;
            produtoView.UnidadeMedida = produto.UnidadeMedida;
            ViewBag.Categorias = database.Categorias.ToList();
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View(produtoView);
        }

        public IActionResult Promocoes()
        {
            var promocoes = database.Promocoes.Include(p => p.Produto).Where(i => i.Status== true).ToList();
            return View(promocoes);
        }

        public IActionResult NovaPromocao()
        {
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }

        public IActionResult EditarPromocao(int id)
        {
            var promocao = database.Promocoes.Include(p => p.Produto).First(p => p.Id == id);
            PromocaoDTO promo = new PromocaoDTO();
            promo.Id = promocao.Id;
            promo.Nome = promocao.Nome;
            promo.Porcentagem = promocao.Porcentagem;
            promo.ProdutoID = promocao.Produto.Id;
            ViewBag.Produtos = database.Produtos.ToList();
            return View(promo);
        }
        public IActionResult Estoque()
        {
            var listaDeEstoque = database.Estoques.Include(e => e.Produto).ToList();
            return View(listaDeEstoque);

        }

        public IActionResult NovoEstoque()
        {
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }

        public IActionResult EditarEstoque(int id)
        {
            var estoque = database.Estoques.First(e => e.Id == id);
            return View(estoque);
        }
    }
}