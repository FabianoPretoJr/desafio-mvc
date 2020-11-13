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


                string[] arr = vagaTemporaria.TecnologiaID.Split(",");
                for(int i = 0; i < arr.Length; i++)
                {
                    VagaTecnologia vt = new VagaTecnologia();

                    vt.Vaga = database.vagas.First(vaga => vaga.Id == v.Id);
                    vt.Tecnologia = database.tecnologias.First(t => t.Id == Convert.ToInt32(arr[i]));
                    
                    database.vagastecnologias.Add(vt);
                    database.SaveChanges();
                }

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
                database.SaveChanges();


                string[] arr = vagaTemporaria.TecnologiaID.Split(",");
                string[] arr2 = vagaTemporaria.TecnologiaIDAntigos.Split(",");

                for(int i = 0; i < arr2.Length; i++)
                {
                    var vagtec = database.vagastecnologias.First(vt => vt.VagaID == vaga.Id && vt.TecnologiaID == Convert.ToInt32(arr2[i]));
                    database.vagastecnologias.Remove(vagtec);
                    database.SaveChanges();
                }

                for(int i = 0; i < arr.Length; i++)
                {
                    VagaTecnologia vt = new VagaTecnologia();

                    vt.Vaga = database.vagas.First(f => f.Id == vaga.Id);
                    vt.Tecnologia = database.tecnologias.First(t => t.Id == Convert.ToInt32(arr[i]));
                    
                    database.vagastecnologias.Add(vt);
                    database.SaveChanges();
                }
                
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

        [HttpPost]
        public IActionResult Teste()
        {
            var tec = database.tecnologias.Where(t => t.Status == true).ToList();
            return Json(tec);
        }

        [HttpPost]
        public IActionResult ObterJsonTec(int id)
        {
            var vagtec = database.vagastecnologias.Where(ft => ft.VagaID == id).ToList();

            return Json(vagtec);
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