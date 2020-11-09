using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using projeto.Data;
using projeto.Models;
using projeto.DTO;

namespace projeto.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDbContext database;
        public FuncionarioController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Salvar(FuncionarioDTO funcionarioTemporario)
        {
            if (ModelState.IsValid)
            {
                Funcionario func = new Funcionario();

                func.Id = funcionarioTemporario.Id;
                func.InicioWA = funcionarioTemporario.InicioWA;
                func.Cargo = funcionarioTemporario.Cargo;
                func.Matricula = funcionarioTemporario.Matricula;
                func.TerminoWA = funcionarioTemporario.TerminoWA;
                func.Nome = funcionarioTemporario.Nome;
                func.Gft = database.gfts.First(g => g.Id == funcionarioTemporario.GftID);
                func.Vaga = database.vagas.First(v => v.Id == funcionarioTemporario.VagaID);

                database.funcionarios.Add(func);
                database.SaveChanges();

                return RedirectToAction("Funcionarios", "Adm");
            }
            else
            {
                ViewBag.gfts = database.gfts.ToList();
                ViewBag.vagas = database.vagas.ToList();

                return View("../Adm/CadastrarFuncionario");
            }
        }

        public IActionResult Atualizar(FuncionarioDTO funcionarioTemporario)
        { 
            if (ModelState.IsValid)
            {
                var funcionario = database.funcionarios.First(f => f.Id == funcionarioTemporario.Id);

                funcionario.Cargo = funcionarioTemporario.Cargo;
                funcionario.InicioWA = funcionarioTemporario.InicioWA;
                funcionario.TerminoWA = funcionarioTemporario.TerminoWA;
                funcionario.Nome = funcionarioTemporario.Nome;
                funcionario.Matricula = funcionarioTemporario.Matricula;
                funcionario.Vaga = database.vagas.First(v => v.Id == funcionarioTemporario.VagaID);
                funcionario.Gft = database.gfts.First(g => g.Id == funcionarioTemporario.GftID);
                database.SaveChanges();

                return RedirectToAction("Funcionarios", "Adm");
            }
            else
            {
                ViewBag.gfts = database.gfts.ToList();
                ViewBag.vagas = database.vagas.ToList();

                return View("../Adm/EditarFuncionario");
            }
        }

        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var funcionario = database.funcionarios.First(f => f.Id == id);
                database.funcionarios.Remove(funcionario);
                database.SaveChanges();
            }
            return RedirectToAction("Funcionarios", "Adm");
        }

        public IActionResult Teste()
        {
            ViewBag.gfts = database.gfts.ToList();
            var unidades = database.gfts.ToList();
            return Json(unidades);
        }
    }
}