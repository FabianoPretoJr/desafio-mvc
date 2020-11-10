#pragma checksum "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "056a86650c483be158afdbe2edde54e1d90fded7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Adm_Funcionarios), @"mvc.1.0.view", @"/Views/Adm/Funcionarios.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\_ViewImports.cshtml"
using projeto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\_ViewImports.cshtml"
using projeto.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"056a86650c483be158afdbe2edde54e1d90fded7", @"/Views/Adm/Funcionarios.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a28a2dd05ee5c164a75e30eb36b981129448ddd1", @"/Views/_ViewImports.cshtml")]
    public class Views_Adm_Funcionarios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<projeto.Models.Funcionario>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Adm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CadastrarFuncionario", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Deletar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Funcionario", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
  
    ViewData["Title"] = "Funcionários";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    $(document).ready( function () {
        $('#funcionarios').DataTable({
            //""info"" : false,
            ""language"" : {
                ""lengthMenu"": ""Mostrando _MENU_ registros por página"",
                ""zeroRecords"": ""Desculpe, nada encontrado"",
                ""info"": ""Mostrando página _PAGE_ de _PAGES_"",
                ""infoEmpty"": ""Nenhum funcionário cadastrado no sistema."",
                ""search"": ""Buscar:"",
                ""paginate"": {
                    ""first"": ""Primeiro"",
                    ""last"": ""Último"",
                    ""next"": ""próximo"",
                    ""previous"": ""Anterior""
                }
            }
        });
    } );
</script>

<style>
    .cargo {
        white-space: wrap;
        width: 15%;                   
        overflow: hidden;
        text-overflow: clip ellipsis;
    }
</style>

");
#nullable restore
#line 39 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
 if(SignInManager.IsSignedIn(User))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <h2>Funcionários em WA</h2><br/>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "056a86650c483be158afdbe2edde54e1d90fded77050", async() => {
                WriteLiteral("Cadastrar funcionários");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 45 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<hr/>
<table id=""funcionarios"" class=""table table-striped table-bordered"">
    <thead>
        <tr>
            <th>Id</th>
            <th>Cargo</th>
            <th>Inicio WA</th>
            <th>Matricula</th>
            <th>Nome</th>
            <th>Termino WA</th>
");
            WriteLiteral("            <th>GFT</th>\r\n");
#nullable restore
#line 59 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
             if (SignInManager.IsSignedIn(User))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>Ações</th>\r\n");
#nullable restore
#line 62 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n    </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 66 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
         foreach (var func in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 69 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
                   Write(func.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"cargo\">");
#nullable restore
#line 70 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
                                 Write(func.Cargo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 71 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
                   Write(func.InicioWA);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 72 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
                   Write(func.Matricula);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 73 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
                   Write(func.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 74 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
                   Write(func.TerminoWA);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                    <td>");
#nullable restore
#line 76 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
                   Write(func.Gft.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 77 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
                     if (SignInManager.IsSignedIn(User))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                        <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 2467, "\"", 2505, 2);
            WriteAttributeValue("", 2474, "/Adm/EditarFuncionario/", 2474, 23, true);
#nullable restore
#line 80 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
WriteAttributeValue("", 2497, func.Id, 2497, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Editar</a> \r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "056a86650c483be158afdbe2edde54e1d90fded712828", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"id\" id=\"id\"");
                BeginWriteAttribute("value", " value=\"", 2693, "\"", 2709, 1);
#nullable restore
#line 82 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
WriteAttributeValue("", 2701, func.Id, 2701, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> ");
                WriteLiteral("\r\n                            <button class=\"btn btn-danger\">Deletar</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 86 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>                \r\n");
#nullable restore
#line 88 "C:\Users\FOEU\My Private Documents\Projetos\desafio-mvc\projeto\Views\Adm\Funcionarios.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<projeto.Models.Funcionario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
