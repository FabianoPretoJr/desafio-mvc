using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using projeto.Areas.Identity.Pages.Account;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using projeto.Data;
using projeto.Models;
using Microsoft.AspNetCore.Authorization;

namespace projeto.Controllers
{
    public class PopularController : Controller
    {
        private readonly ApplicationDbContext database;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public PopularController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger, ApplicationDbContext database)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.database = database;
        }

        public string Email = "clecio@gft.com";
        public string Password = "Abc123:)";
        public string ConfirmPassword = "Abc123:)";

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        // POPULAR LOGIN

        public async Task<IActionResult> PopularLogin()
        {
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            var user = new IdentityUser { UserName = Email, Email = Email };
            var result = await _userManager.CreateAsync(user, Password);

            _logger.LogInformation("User created a new account with password.");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            Popular pop = new Popular();

            pop.ClaimCont = "Login";
            pop.ValueCont = true;

            database.popular.Add(pop);
            database.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }

        // POPULAR DADOS

        [Authorize]
        public IActionResult PopularDados()
        {
            Tecnologia tec1 = new Tecnologia();
            tec1.Nome = ".NET";
            tec1.Status = true;
            database.tecnologias.Add(tec1);
            database.SaveChanges();

            Tecnologia tec2 = new Tecnologia();
            tec2.Nome = "Java";
            tec2.Status = true;
            database.tecnologias.Add(tec2);
            database.SaveChanges();

            Tecnologia tec3 = new Tecnologia();
            tec3.Nome = "Angular";
            tec3.Status = true;
            database.tecnologias.Add(tec3);
            database.SaveChanges();

            Tecnologia tec4 = new Tecnologia();
            tec4.Nome = "SalesForce";
            tec4.Status = true;
            database.tecnologias.Add(tec4);
            database.SaveChanges();

            Tecnologia tec5 = new Tecnologia();
            tec5.Nome = "Selenium";
            tec5.Status = true;
            database.tecnologias.Add(tec5);
            database.SaveChanges();

            Tecnologia tec6 = new Tecnologia();
            tec6.Nome = "Node";
            tec6.Status = true;
            database.tecnologias.Add(tec6);
            database.SaveChanges();

            Tecnologia tec7 = new Tecnologia();
            tec7.Nome = "React";
            tec7.Status = true;
            database.tecnologias.Add(tec7);
            database.SaveChanges();

            Tecnologia tec8 = new Tecnologia();
            tec8.Nome = "TypeScript";
            tec8.Status = true;
            database.tecnologias.Add(tec8);
            database.SaveChanges();

            /////////////////////////////////////////////////////////////////////////////////////////////

            Gft unidade1 = new Gft();
            unidade1.Cep = "06454-000";
            unidade1.Cidade = "Barueri";
            unidade1.Endereco = "Alameda Rio Negro, 585 - Alphaville Industrial";
            unidade1.Estado = "São Paulo";
            unidade1.Nome = "Alphaville";
            unidade1.Telefone = "(11) 2176-3253";
            unidade1.Status = true;
            database.gfts.Add(unidade1);
            database.SaveChanges();

            Gft unidade2 = new Gft();
            unidade2.Cep = "80250-210";
            unidade2.Cidade = "Curitiba";
            unidade2.Endereco = "Av. Sete de Setembro, 2451 - Rebouças";
            unidade2.Estado = "Paraná";
            unidade2.Nome = "Curitiba";
            unidade2.Telefone = "(41) 4009-5700";
            unidade2.Status = true;
            database.gfts.Add(unidade2);
            database.SaveChanges();

            Gft unidade3 = new Gft();
            unidade3.Cep = "18095-450";
            unidade3.Cidade = "Sorocaba";
            unidade3.Endereco = "Av. São Francisco, 98 - Jardim Santa Rosália";
            unidade3.Estado = "São Paulo";
            unidade3.Nome = "Sorocaba";
            unidade3.Telefone = "(11) 2176-3253";
            unidade3.Status = true;
            database.gfts.Add(unidade3);
            database.SaveChanges();

            /////////////////////////////////////////////////////////////////////////////////////////////

            Vaga vaga1 = new Vaga();
            vaga1.CodVaga = "#ITAUNI";
            vaga1.Projeto = "Itaú Unibanco";
            vaga1.QtdVaga = 10;
            vaga1.AberturaVaga = DateTime.Now;
            vaga1.DescricaoVaga = "Vagas para desenvolvedor backend .NET";
            vaga1.Status = true;
            database.vagas.Add(vaga1);
            database.SaveChanges();

            VagaTecnologia vt1 = new VagaTecnologia();
            vt1.Vaga = database.vagas.First(v => v.Id == vaga1.Id);
            vt1.Tecnologia = database.tecnologias.First(t => t.Id == 1);
            database.vagastecnologias.Add(vt1);
            database.SaveChanges();

            VagaTecnologia vt11 = new VagaTecnologia();
            vt11.Vaga = database.vagas.First(v => v.Id == vaga1.Id);
            vt11.Tecnologia = database.tecnologias.First(t => t.Id == 3);
            database.vagastecnologias.Add(vt11);
            database.SaveChanges();

            Vaga vaga2 = new Vaga();
            vaga2.CodVaga = "#RABANK";
            vaga2.Projeto = "Rabo Bank";
            vaga2.QtdVaga = 5;
            vaga2.AberturaVaga = DateTime.Now;
            vaga2.DescricaoVaga = "Vagas para desenvolvedor frontend";
            vaga2.Status = true;
            database.vagas.Add(vaga2);
            database.SaveChanges();

            VagaTecnologia vt2 = new VagaTecnologia();
            vt2.Vaga = database.vagas.First(v => v.Id == vaga2.Id);
            vt2.Tecnologia = database.tecnologias.First(t => t.Id == 3);
            database.vagastecnologias.Add(vt2);
            database.SaveChanges();

            Vaga vaga3 = new Vaga();
            vaga3.CodVaga = "#BANORI";
            vaga3.Projeto = "Banco Original";
            vaga3.QtdVaga = 15;
            vaga3.AberturaVaga = DateTime.Now;
            vaga3.DescricaoVaga = "Vagas para QA";
            vaga3.Status = true;
            database.vagas.Add(vaga3);
            database.SaveChanges();

            VagaTecnologia vt3 = new VagaTecnologia();
            vt3.Vaga = database.vagas.First(v => v.Id == vaga3.Id);
            vt3.Tecnologia = database.tecnologias.First(t => t.Id == 5);
            database.vagastecnologias.Add(vt3);
            database.SaveChanges();

            VagaTecnologia vt31 = new VagaTecnologia();
            vt31.Vaga = database.vagas.First(v => v.Id == vaga3.Id);
            vt31.Tecnologia = database.tecnologias.First(t => t.Id == 2);
            database.vagastecnologias.Add(vt31);
            database.SaveChanges();

            Vaga vaga4 = new Vaga();
            vaga4.CodVaga = "#SULAME";
            vaga4.Projeto = "Sul Ámerica";
            vaga4.QtdVaga = 8;
            vaga4.AberturaVaga = DateTime.Now;
            vaga4.DescricaoVaga = "Vagas para desenvolvedor SalesForce";
            vaga4.Status = true;
            database.vagas.Add(vaga4);
            database.SaveChanges();

            VagaTecnologia vt4 = new VagaTecnologia();
            vt4.Vaga = database.vagas.First(v => v.Id == vaga4.Id);
            vt4.Tecnologia = database.tecnologias.First(t => t.Id == 6);
            database.vagastecnologias.Add(vt4);
            database.SaveChanges();

            VagaTecnologia vt41 = new VagaTecnologia();
            vt41.Vaga = database.vagas.First(v => v.Id == vaga4.Id);
            vt41.Tecnologia = database.tecnologias.First(t => t.Id == 7);
            database.vagastecnologias.Add(vt41);
            database.SaveChanges();

            VagaTecnologia vt42 = new VagaTecnologia();
            vt42.Vaga = database.vagas.First(v => v.Id == vaga4.Id);
            vt42.Tecnologia = database.tecnologias.First(t => t.Id == 8);
            database.vagastecnologias.Add(vt42);
            database.SaveChanges();

            /////////////////////////////////////////////////////////////////////////////////////////////

            Funcionario func1 = new Funcionario();
            func1.Cargo = "Desenvolvedor .NET";
            func1.InicioWA = DateTime.Now;
            func1.Matricula = "1545884";
            func1.Nome = "Fabiano Preto";
            func1.TerminoWA = DateTime.Now.AddDays(15);
            func1.Gft = database.gfts.First(g => g.Id == 1);
            func1.Status = true;
            database.funcionarios.Add(func1);
            database.SaveChanges();

            FuncionarioTecnologia ft1 = new FuncionarioTecnologia();
            ft1.Funcionario = database.funcionarios.First(f => f.Id == func1.Id);
            ft1.Tecnologia = database.tecnologias.First(t => t.Id == 1);
            database.funcionariostecnologias.Add(ft1);
            database.SaveChanges();

            FuncionarioTecnologia ft11 = new FuncionarioTecnologia();
            ft11.Funcionario = database.funcionarios.First(f => f.Id == func1.Id);
            ft11.Tecnologia = database.tecnologias.First(t => t.Id == 7);
            database.funcionariostecnologias.Add(ft11);
            database.SaveChanges();

            Funcionario func2 = new Funcionario();
            func2.Cargo = "Desenvolvedora SalesForce";
            func2.InicioWA = DateTime.Now;
            func2.Matricula = "1544521";
            func2.Nome = "Ingrid Serello";
            func2.TerminoWA = DateTime.Now.AddDays(15);
            func2.Gft = database.gfts.First(g => g.Id == 3);
            func2.Status = true;
            database.funcionarios.Add(func2);
            database.SaveChanges();

            FuncionarioTecnologia ft2 = new FuncionarioTecnologia();
            ft2.Funcionario = database.funcionarios.First(f => f.Id == func2.Id);
            ft2.Tecnologia = database.tecnologias.First(t => t.Id == 4);
            database.funcionariostecnologias.Add(ft2);
            database.SaveChanges();

            Funcionario func3 = new Funcionario();
            func3.Cargo = "Desenvolvedora Frontend";
            func3.InicioWA = DateTime.Now;
            func3.Matricula = "1684284";
            func3.Nome = "Karine Martins";
            func3.TerminoWA = DateTime.Now.AddDays(15);
            func3.Gft = database.gfts.First(g => g.Id == 2);
            func3.Status = true;
            database.funcionarios.Add(func3);
            database.SaveChanges();

            FuncionarioTecnologia ft3 = new FuncionarioTecnologia();
            ft3.Funcionario = database.funcionarios.First(f => f.Id == func3.Id);
            ft3.Tecnologia = database.tecnologias.First(t => t.Id == 3);
            database.funcionariostecnologias.Add(ft3);
            database.SaveChanges();

            FuncionarioTecnologia ft31 = new FuncionarioTecnologia();
            ft31.Funcionario = database.funcionarios.First(f => f.Id == func3.Id);
            ft31.Tecnologia = database.tecnologias.First(t => t.Id == 8);
            database.funcionariostecnologias.Add(ft31);
            database.SaveChanges();

            Funcionario func4 = new Funcionario();
            func4.Cargo = "Desenvolvedor Backend";
            func4.InicioWA = DateTime.Now;
            func4.Matricula = "4523284";
            func4.Nome = "Felipe Fernandes";
            func4.TerminoWA = DateTime.Now.AddDays(15);
            func4.Gft = database.gfts.First(g => g.Id == 1);
            func4.Status = true;
            database.funcionarios.Add(func4);
            database.SaveChanges();

            FuncionarioTecnologia ft4 = new FuncionarioTecnologia();
            ft4.Funcionario = database.funcionarios.First(f => f.Id == func4.Id);
            ft4.Tecnologia = database.tecnologias.First(t => t.Id == 2);
            database.funcionariostecnologias.Add(ft4);
            database.SaveChanges();

            Funcionario func5 = new Funcionario();
            func5.Cargo = "Desenvolvedora Backend";
            func5.InicioWA = DateTime.Now;
            func5.Matricula = "4524952";
            func5.Nome = "kemylly Cavalcante";
            func5.TerminoWA = DateTime.Now.AddDays(15);
            func5.Gft = database.gfts.First(g => g.Id == 1);
            func5.Status = true;
            database.funcionarios.Add(func5);
            database.SaveChanges();

            FuncionarioTecnologia ft5 = new FuncionarioTecnologia();
            ft5.Funcionario = database.funcionarios.First(f => f.Id == func5.Id);
            ft5.Tecnologia = database.tecnologias.First(t => t.Id == 1);
            database.funcionariostecnologias.Add(ft5);
            database.SaveChanges();

            Funcionario func6 = new Funcionario();
            func6.Cargo = "Desenvolvedora SalesForce";
            func6.InicioWA = DateTime.Now;
            func6.Matricula = "4522152";
            func6.Nome = "Samara Santos";
            func6.TerminoWA = DateTime.Now.AddDays(15);
            func6.Gft = database.gfts.First(g => g.Id == 2);
            func6.Status = true;
            database.funcionarios.Add(func6);
            database.SaveChanges();

            FuncionarioTecnologia ft6 = new FuncionarioTecnologia();
            ft6.Funcionario = database.funcionarios.First(f => f.Id == func6.Id);
            ft6.Tecnologia = database.tecnologias.First(t => t.Id == 4);
            database.funcionariostecnologias.Add(ft6);
            database.SaveChanges();

            Funcionario func7 = new Funcionario();
            func7.Cargo = "Desenvolvedor Backend";
            func7.InicioWA = DateTime.Now;
            func7.Matricula = "4521642";
            func7.Nome = "Matheus Ribeiro";
            func7.TerminoWA = DateTime.Now.AddDays(15);
            func7.Gft = database.gfts.First(g => g.Id == 3);
            func7.Status = true;
            database.funcionarios.Add(func7);
            database.SaveChanges();

            FuncionarioTecnologia ft7 = new FuncionarioTecnologia();
            ft7.Funcionario = database.funcionarios.First(f => f.Id == func7.Id);
            ft7.Tecnologia = database.tecnologias.First(t => t.Id == 1);
            database.funcionariostecnologias.Add(ft7);
            database.SaveChanges();

            FuncionarioTecnologia ft71 = new FuncionarioTecnologia();
            ft71.Funcionario = database.funcionarios.First(f => f.Id == func7.Id);
            ft71.Tecnologia = database.tecnologias.First(t => t.Id == 2);
            database.funcionariostecnologias.Add(ft71);
            database.SaveChanges();

            Funcionario func8 = new Funcionario();
            func8.Cargo = "Desenvolvedor FullStack";
            func8.InicioWA = DateTime.Now;
            func8.Matricula = "4523549";
            func8.Nome = "João Oliveira";
            func8.TerminoWA = DateTime.Now.AddDays(15);
            func8.Gft = database.gfts.First(g => g.Id == 1);
            func8.Status = true;
            database.funcionarios.Add(func8);
            database.SaveChanges();

            FuncionarioTecnologia ft8 = new FuncionarioTecnologia();
            ft8.Funcionario = database.funcionarios.First(f => f.Id == func8.Id);
            ft8.Tecnologia = database.tecnologias.First(t => t.Id == 6);
            database.funcionariostecnologias.Add(ft8);
            database.SaveChanges();

            FuncionarioTecnologia ft81 = new FuncionarioTecnologia();
            ft81.Funcionario = database.funcionarios.First(f => f.Id == func8.Id);
            ft81.Tecnologia = database.tecnologias.First(t => t.Id == 7);
            database.funcionariostecnologias.Add(ft81);
            database.SaveChanges();

            FuncionarioTecnologia ft82 = new FuncionarioTecnologia();
            ft82.Funcionario = database.funcionarios.First(f => f.Id == func8.Id);
            ft82.Tecnologia = database.tecnologias.First(t => t.Id == 8);
            database.funcionariostecnologias.Add(ft82);
            database.SaveChanges();

            /////////////////////////////////////////////////////////////////////////////////////////////

            Alocacao alo1 = new Alocacao();
            alo1.Id = 0;
            alo1.InicioAlocacao = DateTime.Now;
            alo1.Vaga = database.vagas.First(v => v.Id == 1);
            database.alocacoes.Add(alo1);
            database.SaveChanges();

            var funcio1 = database.funcionarios.First(f => f.Id == 1);
            funcio1.Alocacao = database.alocacoes.First(a => a.Id == 1);
            database.SaveChanges();

            var v1 = database.vagas.First(v => v.Id == 1);
            v1.QtdVaga = v1.QtdVaga - 1;
            database.SaveChanges();

            Alocacao alo2 = new Alocacao();
            alo2.Id = 0;
            alo2.InicioAlocacao = DateTime.Now;
            alo2.Vaga = database.vagas.First(v => v.Id == 4);
            database.alocacoes.Add(alo2);
            database.SaveChanges();

            var funcio2 = database.funcionarios.First(f => f.Id == 2);
            funcio2.Alocacao = database.alocacoes.First(a => a.Id == 2);
            database.SaveChanges();

            var v2 = database.vagas.First(v => v.Id == 4);
            v2.QtdVaga = v2.QtdVaga - 1;
            database.SaveChanges();

            Alocacao alo3 = new Alocacao();
            alo3.Id = 0;
            alo3.InicioAlocacao = DateTime.Now;
            alo3.Vaga = database.vagas.First(v => v.Id == 2);
            database.alocacoes.Add(alo3);
            database.SaveChanges();

            var funcio3 = database.funcionarios.First(f => f.Id == 3);
            funcio3.Alocacao = database.alocacoes.First(a => a.Id == 3);
            database.SaveChanges();

            var v3 = database.vagas.First(v => v.Id == 2);
            v3.QtdVaga = v3.QtdVaga - 1;
            database.SaveChanges();

            Alocacao alo4 = new Alocacao();
            alo4.Id = 0;
            alo4.InicioAlocacao = DateTime.Now;
            alo4.Vaga = database.vagas.First(v => v.Id == 1);
            database.alocacoes.Add(alo4);
            database.SaveChanges();

            var funcio4 = database.funcionarios.First(f => f.Id == 5);
            funcio4.Alocacao = database.alocacoes.First(a => a.Id == 4);
            database.SaveChanges();

            var v4 = database.vagas.First(v => v.Id == 1);
            v4.QtdVaga = v4.QtdVaga - 1;
            database.SaveChanges();

            /////////////////////////////////////////////////////////////////////////////////////////////

            Popular pop = new Popular();

            pop.ClaimCont = "Dados";
            pop.ValueCont = true;

            database.popular.Add(pop);
            database.SaveChanges();

            return RedirectToAction("Index", "Adm");
        }
    }
}