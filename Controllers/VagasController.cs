using System;
using Microsoft.AspNetCore.Mvc;
using projeto.Data;
using projeto.DTO;
using projeto.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace projeto.Controllers
{
    [Authorize]
    public class VagasController : Controller
    {
        private readonly ApplicationDbContext database;
        public VagasController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(VagaDTO vagaTemporaria)
        {
            if (ModelState.IsValid)
            {
                Vaga v = new Vaga();

                v.Id = vagaTemporaria.Id;
                v.CodVaga = vagaTemporaria.CodVaga;
                v.Projeto = vagaTemporaria.Projeto;
                v.QtdVaga = vagaTemporaria.QtdVaga;
                v.AberturaVaga = DateTime.Now;
                v.DescricaoVaga = vagaTemporaria.DescricaoVaga;
                v.Status = true;

                database.vagas.Add(v);
                database.SaveChanges();

                VagaTecnologia vt = new VagaTecnologia();

                vt.Vaga = database.vagas.First(vaga => vaga.Id == v.Id);
                vt.Tecnologia = database.tecnologias.First(t => t.Id == vagaTemporaria.TecnologiaID);
                
                database.vagastecnologias.Add(vt);
                database.SaveChanges();

                return RedirectToAction("Vagas", "Adm");
            }
            else
            {
                ViewBag.tecnologias = database.tecnologias.Where(t => t.Status == true).ToList();
                return View("../Adm/CadastrarVaga");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(VagaDTO vagaTemporaria)
        {
            if (ModelState.IsValid)
            {
                var vaga = database.vagas.First(v => v.Id == vagaTemporaria.Id);

                vaga.Id = vagaTemporaria.Id;
                vaga.CodVaga = vagaTemporaria.CodVaga;
                vaga.Projeto = vagaTemporaria.Projeto;
                vaga.QtdVaga = vagaTemporaria.QtdVaga;
                vaga.AberturaVaga = vagaTemporaria.AberturaVaga;
                vaga.DescricaoVaga = vagaTemporaria.DescricaoVaga;
                var vatec = database.vagastecnologias.First(vt => vt.VagaID == vagaTemporaria.Id);
                database.vagastecnologias.Remove(vatec);
                database.SaveChanges();

                VagaTecnologia vt = new VagaTecnologia();

                vt.Vaga = database.vagas.First(vaga => vaga.Id == vagaTemporaria.Id);
                vt.Tecnologia = database.tecnologias.First(t => t.Id == vagaTemporaria.TecnologiaID);
                database.vagastecnologias.Add(vt);
                database.SaveChanges();

                return RedirectToAction("Vagas", "Adm");
            }
            else
            {
                ViewBag.tecnologias = database.tecnologias.ToList();
                return View("../Adm/EditarVaga");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var vaga = database.vagas.First(v => v.Id == id);
                vaga.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Vagas", "Adm");
        }
    }
}