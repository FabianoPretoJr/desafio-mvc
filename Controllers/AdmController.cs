using System;
using Microsoft.AspNetCore.Mvc;
using projeto.Models;
using projeto.DTO;
using projeto.Data;
using System.Linq;

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
            return View();
        }

        public IActionResult Funcionarios()
        {
            return View();
        }

        public IActionResult CadastrarFuncionario()
        {
            return View();
        }

        public IActionResult Vagas()
        {
            var vagas = database.vagas.ToList();
            return View(vagas);
        }

        public IActionResult CadastrarVaga()
        {
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
            return View();
        }

        public IActionResult CadastrarTecnologia()
        {
            return View();
        }

        public IActionResult Unidades()
        {
            return View();
        }
    }
}