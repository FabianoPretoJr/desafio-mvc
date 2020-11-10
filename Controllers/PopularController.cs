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

        public IActionResult PopularDados()
        {
            Vaga vaga = new Vaga();

            vaga.CodVaga = "#ITABANK";
            vaga.Projeto = "Itaú Unibanco";
            vaga.QtdVaga = 10;
            vaga.AberturaVaga = DateTime.Now;
            vaga.DescricaoVaga = "Vagas para desenvolvedor backend .NET";
            vaga.Status = true;
            database.vagas.Add(vaga);
            database.SaveChanges();

            Tecnologia tec = new Tecnologia();

            tec.Nome = ".NET";
            tec.Status = true;
            database.tecnologias.Add(tec);
            database.SaveChanges();

            Gft unidade = new Gft();

            unidade.Cep = "07844-170";
            unidade.Cidade = "São Paulo";
            unidade.Endereco = "Alameda Rio Negro, 266";
            unidade.Estado = "SP";
            unidade.Nome = "Alphaville";
            unidade.Telefone = "11 4444-5612";
            unidade.Status = true;
            database.gfts.Add(unidade);
            database.SaveChanges();

            Funcionario func = new Funcionario();

            func.Cargo = "Desenvolvedor backend .NET";
            func.InicioWA = DateTime.Now;
            func.Matricula = "1545884";
            func.Nome = "Fabiano Preto";
            func.TerminoWA = DateTime.Now.AddDays(15);
            func.Gft = database.gfts.First(g => g.Id == 4);
            func.Vaga = database.vagas.First(v => v.Id == 5);
            func.Status = true;
            database.funcionarios.Add(func);
            database.SaveChanges();

            Popular pop = new Popular();

            pop.ClaimCont = "Dados";
            pop.ValueCont = true;

            database.popular.Add(pop);
            database.SaveChanges();

            return RedirectToAction("Index", "Adm");
        }
    }
}