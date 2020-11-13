using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using projeto.Data;
using projeto.Models;
using projeto.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace projeto.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDbContext database;
        public FuncionarioController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(FuncionarioDTO funcionarioTemporario)
        {
            if (ModelState.IsValid)
            {
                Funcionario func = new Funcionario();

                func.Id = funcionarioTemporario.Id;
                func.InicioWA = DateTime.Now;
                func.Cargo = funcionarioTemporario.Cargo;
                func.Matricula = funcionarioTemporario.Matricula;
                func.TerminoWA = DateTime.Now.AddDays(15);
                func.Nome = funcionarioTemporario.Nome;
                func.Gft = database.gfts.First(g => g.Id == funcionarioTemporario.GftID);
                func.Status = true;

                database.funcionarios.Add(func);
                database.SaveChanges();

                string[] arr = funcionarioTemporario.TecnologiaID.Split(",");
                for(int i = 0; i < arr.Length; i++)
                {
                    FuncionarioTecnologia ft = new FuncionarioTecnologia();

                    ft.Funcionario = database.funcionarios.First(f => f.Id == func.Id);
                    ft.Tecnologia = database.tecnologias.First(t => t.Id == Convert.ToInt32(arr[i]));
                    
                    database.funcionariostecnologias.Add(ft);
                    database.SaveChanges();
                }

                return RedirectToAction("Funcionarios", "Adm");
            }
            else
            {
                ViewBag.tecnologias = database.tecnologias.Where(t => t.Status == true).ToList();
                ViewBag.gfts = database.gfts.Where(g => g.Status == true).ToList();

                return View("../Adm/CadastrarFuncionario");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(FuncionarioDTO funcionarioTemporario)
        { 
            if (ModelState.IsValid)
            {
                var funcionario = database.funcionarios.First(f => f.Id == funcionarioTemporario.Id);

                funcionario.Id = funcionarioTemporario.Id;
                funcionario.Cargo = funcionarioTemporario.Cargo;
                funcionario.InicioWA = funcionarioTemporario.InicioWA;
                funcionario.TerminoWA = funcionarioTemporario.TerminoWA;
                funcionario.Nome = funcionarioTemporario.Nome;
                funcionario.Matricula = funcionarioTemporario.Matricula;
                funcionario.Gft = database.gfts.First(g => g.Id == funcionarioTemporario.GftID);
                database.SaveChanges();

                string[] arr = funcionarioTemporario.TecnologiaID.Split(",");
                string[] arr2 = funcionarioTemporario.TecnologiaIDAntigos.Split(",");

                for(int i = 0; i < arr2.Length; i++)
                {
                    var funtec = database.funcionariostecnologias.First(ft => ft.FuncionarioID == funcionario.Id && ft.TecnologiaID == Convert.ToInt32(arr2[i]));
                    database.funcionariostecnologias.Remove(funtec);
                    database.SaveChanges();
                }

                for(int i = 0; i < arr.Length; i++)
                {
                    FuncionarioTecnologia ft = new FuncionarioTecnologia();

                    ft.Funcionario = database.funcionarios.First(f => f.Id == funcionario.Id);
                    ft.Tecnologia = database.tecnologias.First(t => t.Id == Convert.ToInt32(arr[i]));
                    
                    database.funcionariostecnologias.Add(ft);
                    database.SaveChanges();
                }

                return RedirectToAction("Funcionarios", "Adm");
            }
            else
            {
                ViewBag.gfts = database.gfts.ToList();
                ViewBag.tecnologias = database.tecnologias.ToList();

                return View("../Adm/EditarFuncionario");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var funcionario = database.funcionarios.First(f => f.Id == id);
                funcionario.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Funcionarios", "Adm");
        }

        [HttpPost]
        public IActionResult AdcVaga(AlocacaoDTO alocacaoTemporaria)
        {
            if(ModelState.IsValid)
            {
                Alocacao alo = new Alocacao();

                alo.Id = alocacaoTemporaria.Id;
                alo.InicioAlocacao = DateTime.Now;
                alo.Vaga = database.vagas.First(v => v.Id == alocacaoTemporaria.VagaID);
                database.alocacoes.Add(alo);
                database.SaveChanges();

                var func = database.funcionarios.First(f => f.Id == alocacaoTemporaria.FuncionarioID);
                func.Alocacao = database.alocacoes.First(a => a.Id == alo.Id);
                database.SaveChanges();

                var vaga = database.vagas.First(v => v.Id == alocacaoTemporaria.VagaID);
                vaga.QtdVaga = vaga.QtdVaga - 1;
                database.SaveChanges();
                return RedirectToAction("Alocacao", "Adm");
            }
            else
            {
                ViewBag.funcionario = database.funcionarios.Include(f => f.Gft).Include(f => f.FuncionarioTecnologias).ThenInclude(f => f.Tecnologia).Where(f => f.Alocacao == null && f.Status == true).ToList();
                ViewBag.vaga = database.vagas.Include(v => v.VagaTecnologias).ThenInclude(v => v.Tecnologia).Where(v => v.QtdVaga > 0 && v.Status == true).ToList();
                return View("../Adm/Alocacao");
            }
            
        }

        [HttpPost]
        public IActionResult Teste()
        {
            var tec = database.tecnologias.Where(t => t.Status == true).ToList();
            return Json(tec);
        }

        [HttpPost]
        public IActionResult ObterJsonTec(int id)
        {
            var funtec = database.funcionariostecnologias.Where(ft => ft.FuncionarioID == id).ToList();

            return Json(funtec);
        }

        [HttpPost]
        public IActionResult ObterNomeTec(int id)
        {
            var nomeTec = database.tecnologias.First(nt => nt.Id == id);
            var nome = nomeTec.Nome;

            return Json(nome);
        }
    }
}