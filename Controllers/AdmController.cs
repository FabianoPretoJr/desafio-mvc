using System;
using Microsoft.AspNetCore.Mvc;
using projeto.Models;
using projeto.DTO;
using projeto.Data;

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

        public IActionResult Vagas()
        {
            return View();
        }

        public IActionResult Alocacao()
        {
            return View();
        }

        public IActionResult Historico()
        {
            return View();
        }
    }
}