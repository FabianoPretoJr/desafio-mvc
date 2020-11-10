using System;
using Microsoft.AspNetCore.Mvc;
using projeto.Models;
using projeto.DTO;
using projeto.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace projeto.Controllers
{
    public class AdmController : Controller
    {
        private readonly ApplicationDbContext database;
        public AdmController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            var login = database.popular.Where(p => p.ClaimCont == "Dados" && p.ValueCont == true).ToList();

            if(login.Any())
            {
                ViewData["cont2"] = false;
            }
            else
            {
                ViewData["cont2"] = true;
            }
            return View();
        }

        public IActionResult Funcionarios()
        {
            var func = database.funcionarios.Include(f => f.Gft).Include(f => f.FuncionarioTecnologias).ThenInclude(f => f.Tecnologia).Where(f => f.Status == true).ToList();
            return View(func);
        }

        public IActionResult CadastrarFuncionario()
        {
            ViewBag.tecnologias = database.tecnologias.Where(t => t.Status == true).ToList();
            ViewBag.gfts = database.gfts.Where(g => g.Status == true).ToList();
            // ViewBag.vagas = database.vagas.Where(v => v.Status == true).ToList();

            return View();
        }

        public IActionResult EditarFuncionario(int id)
        {
            FuncionarioDTO funcionarioView = new FuncionarioDTO();

            var func = database.funcionarios.Include(f => f.Gft).First(f => f.Id == id);

            funcionarioView.Cargo = func.Cargo;
            funcionarioView.InicioWA = func.InicioWA;
            funcionarioView.TerminoWA = func.TerminoWA;
            funcionarioView.Matricula = func.Matricula;
            funcionarioView.Nome = func.Nome;
            funcionarioView.GftID = func.Gft.Id;
            // funcionarioView.VagaID = func.Vaga.Id;

            ViewBag.gfts = database.gfts.ToList();
            // ViewBag.vagas = database.vagas.ToList();

            return View(funcionarioView);
        }

        public IActionResult Vagas()
        {
            var vagas = database.vagas.Include(v => v.VagaTecnologias).ThenInclude(v => v.Tecnologia).Where(v => v.Status == true).ToList();
            return View(vagas);
        }

        public IActionResult CadastrarVaga()
        {
            ViewBag.tecnologias = database.tecnologias.Where(t => t.Status == true).ToList();
            return View();
        }

        public IActionResult EditarVaga(int id)
        {
            VagaDTO vagaView = new VagaDTO();

            var vaga = database.vagas.First(v => v.Id == id);

            vagaView.Id = vaga.Id;
            vagaView.Projeto = vaga.Projeto;
            vagaView.CodVaga = vaga.CodVaga;
            vagaView.AberturaVaga = vaga.AberturaVaga;
            vagaView.DescricaoVaga = vaga.DescricaoVaga;
            vagaView.QtdVaga = vaga.QtdVaga;

            return View(vagaView);
        }

        public IActionResult Alocacao()
        {
            return View();
        }

        public IActionResult Historico()
        {
            return View();
        }

        public IActionResult Tecnologia()
        {
            var tecnologias = database.tecnologias.Where(t => t.Status == true).ToList();

            return View(tecnologias);
        }

        public IActionResult CadastrarTecnologia()
        {
            return View();
        }

        public IActionResult EditarTecnologia(int id)
        {
            TecnologiaDTO tecnologiaView = new TecnologiaDTO();

            var tec = database.tecnologias.First(t => t.Id == id);
            tecnologiaView.Id = tec.Id;
            tecnologiaView.Nome = tec.Nome;

            return View(tecnologiaView);
        }

        public IActionResult Unidades()
        {
            var unidades = database.gfts.Where(u => u.Status == true).ToList();

            return View(unidades);
        }

        public IActionResult CadastrarUnidade()
        {
            return View();
        }

        public IActionResult EditarUnidade(int id)
        {
            GftDTO gftView = new GftDTO();

            var unidade = database.gfts.First(u => u.Id == id);
            gftView.Id = unidade.Id;
            gftView.Cep = unidade.Cep;
            gftView.Cidade = unidade.Cidade;
            gftView.Endereco = unidade.Endereco;
            gftView.Estado = unidade.Estado;
            gftView.Nome = unidade.Nome;
            gftView.Telefone = unidade.Telefone;

            return View(gftView);
        }
    }
}