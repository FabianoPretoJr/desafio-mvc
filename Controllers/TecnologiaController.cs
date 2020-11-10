using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using projeto.Models;
using projeto.DTO;
using projeto.Data;


namespace projeto.Controllers
{
    public class TecnologiaController : Controller
    {
        private readonly ApplicationDbContext database;
        public TecnologiaController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(TecnologiaDTO tecnologiaTemporaria)
        {
            if (ModelState.IsValid)
            {
                Tecnologia tecnologia = new Tecnologia();
                tecnologia.Id = tecnologiaTemporaria.Id;
                tecnologia.Nome = tecnologiaTemporaria.Nome;
                tecnologia.Status = true;

                database.tecnologias.Add(tecnologia);
                database.SaveChanges();

                return RedirectToAction("Tecnologia", "Adm");
            }
            else
            {
                return View("../Adm/CadastrarTecnologia");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(TecnologiaDTO tecnologiaTemporaria)
        {
            if (ModelState.IsValid)
            {
                var tec = database.tecnologias.First(t => t.Id == tecnologiaTemporaria.Id);
                tec.Nome = tecnologiaTemporaria.Nome;
                database.SaveChanges();

                return RedirectToAction("Tecnologia", "Adm");
            }
            else
            {
                return View("../Adm/EditarTecnologia");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if(id > 0)
            {
                var tecnologia = database.tecnologias.First(t => t.Id == id);
                tecnologia.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Tecnologia", "Adm");
        }
    }
}