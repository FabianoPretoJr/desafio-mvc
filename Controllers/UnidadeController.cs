using System;
using Microsoft.AspNetCore.Mvc;
using projeto.Models;
using projeto.Data;
using projeto.DTO;
using System.Linq;

namespace projeto.Controllers 
{
    public class UnidadeController : Controller
    {
        private readonly ApplicationDbContext database;
        public UnidadeController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(GftDTO unidadeTemporaria)
        {
            if (ModelState.IsValid)
            {
                Gft unidade = new Gft();

                unidade.Id = unidadeTemporaria.Id;
                unidade.Cep = unidadeTemporaria.Cep;
                unidade.Cidade = unidadeTemporaria.Cidade;
                unidade.Endereco = unidadeTemporaria.Endereco;
                unidade.Estado = unidadeTemporaria.Estado;
                unidade.Nome = unidadeTemporaria.Nome;
                unidade.Telefone = unidadeTemporaria.Telefone;

                database.gfts.Add(unidade);
                database.SaveChanges();

                return RedirectToAction("Unidades", "Adm");
            }
            else
            {
                return View("../Adm/CadastrarUnidade");
            }
        }

        public IActionResult Atualizar(GftDTO unidadeTemporaria)
        {
            if (ModelState.IsValid)
            {
                var unidade = database.gfts.First(u => u.Id == unidadeTemporaria.Id);

                unidade.Cep = unidadeTemporaria.Cep;
                unidade.Cidade = unidadeTemporaria.Cidade;
                unidade.Endereco = unidadeTemporaria.Endereco;
                unidade.Estado = unidadeTemporaria.Estado;
                unidade.Nome = unidadeTemporaria.Nome;
                unidade.Telefone = unidadeTemporaria.Telefone;

                database.SaveChanges();

                return RedirectToAction("Unidades", "Adm");
            }
            else
            {
                return View("../Adm/EditarUnidade");
            }
        }

        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var unidade = database.gfts.First(u => u.Id == id);
                database.gfts.Remove(unidade);
                database.SaveChanges();
            }

            return RedirectToAction("Unidades", "Adm");
        }
    }
}