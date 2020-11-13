using System;
using Microsoft.AspNetCore.Mvc;
using projeto.Models;
using projeto.DTO;
using projeto.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace projeto.Controllers
{
    public class AdmController : Controller
    {
        private readonly ApplicationDbContext database;
        public AdmController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [Authorize]
        [Route("wa/")]
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

        [Route("wa/funcionarios")]
        public IActionResult Funcionarios()
        {
            var func = database.funcionarios.Include(f => f.Gft).Include(f => f.FuncionarioTecnologias).ThenInclude(f => f.Tecnologia).Where(f => f.Status == true && f.Alocacao == null).ToList();
            return View(func);
        }

        [Authorize]
        [Route("wa/funcionarios/cadastrar")]
        public IActionResult CadastrarFuncionario()
        {
            ViewBag.tecnologias = database.tecnologias.Where(t => t.Status == true).ToList();
            ViewBag.gfts = database.gfts.Where(g => g.Status == true).ToList();

            return View();
        }

        [Authorize]
        public IActionResult EditarFuncionario(int id)
        {
            FuncionarioDTO funcionarioView = new FuncionarioDTO();

            var func = database.funcionarios.Include(f => f.Gft).Include(f => f.FuncionarioTecnologias).ThenInclude(f => f.Tecnologia).First(f => f.Id == id);

            funcionarioView.Id = func.Id;
            funcionarioView.Cargo = func.Cargo;
            funcionarioView.InicioWA = func.InicioWA;
            funcionarioView.TerminoWA = func.TerminoWA;
            funcionarioView.Matricula = func.Matricula;
            funcionarioView.Nome = func.Nome;
            funcionarioView.GftID = func.Gft.Id;

            var funtec = database.funcionariostecnologias.Where(ft => ft.FuncionarioID == func.Id).ToList();
            string tecId = "";
            for(int i = 0; i < funtec.Count; i++)
            {
                tecId = tecId + "," + funtec[i].TecnologiaID;
            }
            tecId = tecId.Remove(0, 1);
            funcionarioView.TecnologiaID = tecId;

            ViewBag.gfts = database.gfts.ToList();
            ViewBag.tecnologias = database.tecnologias.ToList();

            return View(funcionarioView);
        }

        [Route("wa/vagas")]
        public IActionResult Vagas()
        {
            var vagas = database.vagas.Include(v => v.VagaTecnologias).ThenInclude(v => v.Tecnologia).Where(v => v.Status == true && v.QtdVaga > 0).ToList();
            return View(vagas);
        }

        [Authorize]
        [Route("wa/vagas/cadastrar")]
        public IActionResult CadastrarVaga()
        {
            ViewBag.tecnologias = database.tecnologias.Where(t => t.Status == true).ToList();
            return View();
        }

        [Authorize]
        public IActionResult EditarVaga(int id)
        {
            VagaDTO vagaView = new VagaDTO();

            var vaga = database.vagas.Include(v => v.VagaTecnologias).ThenInclude(v => v.Tecnologia).First(v => v.Id == id);

            vagaView.Id = vaga.Id;
            vagaView.Projeto = vaga.Projeto;
            vagaView.CodVaga = vaga.CodVaga;
            vagaView.AberturaVaga = vaga.AberturaVaga;
            vagaView.DescricaoVaga = vaga.DescricaoVaga;
            vagaView.QtdVaga = vaga.QtdVaga;
            var vatec = database.vagastecnologias.First(vt => vt.VagaID == vaga.Id);

            var vagtec = database.vagastecnologias.Where(vt => vt.VagaID == vaga.Id).ToList();
            string tecId = "";
            for(int i = 0; i < vagtec.Count; i++)
            {
                tecId = tecId + "," + vagtec[i].TecnologiaID;
            }
            tecId = tecId.Remove(0, 1);
            vagaView.TecnologiaID = tecId;

            ViewBag.tecnologias = database.tecnologias.ToList();

            return View(vagaView);
        }

        [Authorize]
        [Route("wa/alocar")]
        public IActionResult Alocacao()
        {
            ViewBag.funcionario = database.funcionarios.Include(f => f.Gft).Include(f => f.FuncionarioTecnologias).ThenInclude(f => f.Tecnologia).Where(f => f.Alocacao == null && f.Status == true).ToList();
            ViewBag.vaga = database.vagas.Include(v => v.VagaTecnologias).ThenInclude(v => v.Tecnologia).Where(v => v.QtdVaga > 0 && v.Status == true).ToList();
            return View();
        }

        [Authorize]
        [Route("wa/historico")]
        public IActionResult Historico()
        {
            var func = database.funcionarios.Include(f => f.Alocacao).ThenInclude(f => f.Vaga).Where(f => f.Alocacao != null).ToList();
            return View(func);
        }

        [Authorize]
        [Route("wa/tecnologia")]
        public IActionResult Tecnologia()
        {
            var tecnologias = database.tecnologias.Where(t => t.Status == true).ToList();

            return View(tecnologias);
        }

        [Authorize]
        [Route("wa/tecnologia/cadastrar")]
        public IActionResult CadastrarTecnologia()
        {
            return View();
        }

        [Authorize]
        public IActionResult EditarTecnologia(int id)
        {
            TecnologiaDTO tecnologiaView = new TecnologiaDTO();

            var tec = database.tecnologias.First(t => t.Id == id);
            tecnologiaView.Id = tec.Id;
            tecnologiaView.Nome = tec.Nome;

            return View(tecnologiaView);
        }

        [Authorize]
        [Route("wa/unidades")]
        public IActionResult Unidades()
        {
            var unidades = database.gfts.Where(u => u.Status == true).ToList();

            return View(unidades);
        }

        [Authorize]
        [Route("wa/unidades/cadastrar")]
        public IActionResult CadastrarUnidade()
        {
            return View();
        }

        [Authorize]
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