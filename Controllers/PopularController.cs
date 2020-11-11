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

        public string Email = "fabiano@gft.com";
        public string Password = "Biano15;-;";
        public string ConfirmPassword = "Biano15;-;";

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
            vt4.Tecnologia = database.tecnologias.First(t => t.Id == 4);
            database.vagastecnologias.Add(vt4);
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