#pragma checksum "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "134cc59e24268493e7301954f523f54bbb1728b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pratos_Index), @"mvc.1.0.view", @"/Views/Pratos/Index.cshtml")]
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
#line 1 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\_ViewImports.cshtml"
using Labb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\_ViewImports.cshtml"
using Labb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"134cc59e24268493e7301954f523f54bbb1728b1", @"/Views/Pratos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"016b9a2e3b30ed8750926c5611148010ac32a865", @"/Views/_ViewImports.cshtml")]
    public class Views_Pratos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\Index.cshtml"
  
    ViewData["title"] = "Pesquisar Pratos";
    ViewData["container-type"] = "container-fluid";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-3"">
        <button class=""btn btn-outline-primary mb-2"" id=""DisplayType""><i class=""far fa-eye""></i> Tipo de apresentação</button>
        <input type=""text"" class=""form-control"" placeholder=""Pesquisar"" id=""searchbox"" />
        <p class=""mt-2""><b>Preço:</b></p>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""checkbox"" id=""0to10"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                0 - 10
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""checkbox"" id=""10to20"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                10 - 20
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""checkbox"" id=""20plus"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                20 +
            </label>
        </div>
   ");
            WriteLiteral(@"     <p class=""mt-2""><b>Tipo:</b></p>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""checkbox"" id=""vegan"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                Vegan
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""checkbox"" id=""carne"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                Carne
            </label>
        </div>
        <div class=""form-check"">
            <input class=""form-check-input"" type=""checkbox"" id=""peixe"">
            <label class=""form-check-label"" for=""flexCheckDefault"">
                Peixe
            </label>
        </div>
        <button class=""btn btn-outline-dark mt-4"" id=""search"">Pesquisar</button>
    </div>
    <div class=""col-9"" id=""restaurantes"">
");
            WriteLiteral("    </div>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@" 
<script type=""text/javascript"">
    let pagetype = ""PLANE"";
    let lastresults = null;
    $(""#DisplayType"").on(""click"", () => {
        if (pagetype == ""PLANE"") {
            pagetype = ""COMPLEX"";
        } else {
            pagetype = ""PLANE"";
        }
        if (lastresults != null) {
            RenderPage(lastresults);
        }
    });
    $(""#search"").on(""click"", () => {
        let zerototen = $(""#0to10"").is("":checked"");
        let tentotwenty = $(""#10to20"").is("":checked"");
        let twentyplus = $(""#20plus"").is("":checked"");
        let vegan = $(""#vegan"").is("":checked"");
        let meat = $(""#carne"").is("":checked"");
        let fish = $(""#peixe"").is("":checked"");
        let search = $(""#searchbox"").val();
        $.ajax({
            type: ""GET"",
            url: ""/api/pratos"",
            data:
            {
                zerototen: zerototen,
                tentotwenty: tentotwenty,
                twentyplus: twentyplus,
                vegan: vegan,
   ");
                WriteLiteral(@"             meat: meat,
                fish: fish,
                search: search
            }
        }).done((resp) => {
            lastresults = resp;
            RenderPage(resp);
        });
    });
    function AddToFavClick(element) {
        let plateid = $(element).attr(""data-plate"");
        $.ajax({
            type: ""GET"",
            url: ""/api/Pratos/Favorito"",
            data: {
                idPrato: plateid
            }
        }).done((resp) => {
            if (resp == ""Removed"") {
                toastr.success('Prato removido dos favoritos com sucesso!', 'Favoritos');
            } else {
                toastr.success('Prato adicionado aos favoritos com sucesso!', 'Favoritos');
            }
        }).catch((resp) => {
            toastr.error('Não foi possivel adicionar/remover o prato aos favoritos', 'Favoritos');
        });
    }
    function RenderPage(resp) {
        $(""#restaurantes"").html("""");
        if (pagetype == ""PLANE"") {
            l");
                WriteLiteral(@"et elements = [];
            //CODIGO PARA PLANE ELEMENTS
            resp.forEach((rest) => {
                elements.push(CreatePlaneElement(rest));
            });
            let i = 0;
            let finalhtml = """";
            while (i < elements.length) {
                let stopat = i + 3;
                finalhtml += ""<div class=\""row\"">"";
                for (i; i < stopat; i++) {
                    if (i < elements.length) {
                        finalhtml += ""<div class=\""col-4\""><div class=\""card\""><div class=\""card-body\"">"" + elements[i] + ""</div></div></div>"";
                    }
                }
                finalhtml += ""</div>"";
            }
            $(""#restaurantes"").append(finalhtml);
        } else {
            //CODIGO PARA COMPLEX ELEMENTS
            let finalhtml = """";
            resp.forEach((rest) => {
                finalhtml += ""<div class=\""card\""><div class=\""card-body\"">"" + CreateComplexElement(rest) + ""</div></div>"";
            });
");
                WriteLiteral(@"            $(""#restaurantes"").append(finalhtml);
        }
    }
    function CreatePlaneElement(plate) {
        return `<div>
                    <img class=""img-fluid"" src=""${plate.foto}"" alt=""Capa de Restaurante""/><br/>
                    <div class=""text-center"">
                        <p>${plate.nome}</p>
                        <button class=""btn btn-outline-dark mt-2"" data-plate=""${plate.idPrato}"" onclick=""AddToFavClick(this);"">Favorito</button>
                    </div>
                </div>`;
    }
    function CreateComplexElement(plate) {
        return `<div class=""row"">
                    <div class=""col-3"">
                        <img class=""img-fluid"" src=""${plate.foto}"" alt=""Capa de Restaurante""/>
                    </div>
                    <div class=""col-6"">
                        <p><b>${plate.nome}</b></p>
                        <p><b>${plate.restaurante.nome}</b></p>
                        <p>${plate.descricao}</p>
                    </div>
           ");
                WriteLiteral(@"         <div class=""col-3 text-center"">
                        <input type=""text"" class=""form-control"" value=""${FormatDate(plate.dataPrato)}"" disabled>
                        <p class=""mt-2"">${plate.preco}€</p>
                    </div>
                </div>
                <div class=""row mt-4"">
                    <div class=""col-2"">
                        <button class=""btn btn-outline-dark"" data-plate=""${plate.idPrato}"" onclick=""AddToFavClick(this);"">Favorito</button>
                    </div>
                    <div class=""col-10""></div>
                </div>`;
    }
    function FormatDate(date) {
        let regex = /([0-9]{4})-([0-9]{2})-([0-9]{2})/;
        let matches = date.match(regex);
        let day = matches[3];
        let month = matches[2];
        let year = matches[1];
        return `${day}/${month}/${year}`;
    }
</script>
");
#nullable restore
#line 181 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\Index.cshtml"
 if ((bool)ViewData["FirstSearch"])
{

#line default
#line hidden
#nullable disable
                WriteLiteral("    <script type=\"text/javascript\">\r\n        let types = \'");
#nullable restore
#line 184 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\Index.cshtml"
                Write(ViewData["Tipo"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
        let vegan = false;
        let meat = false;
        let fish = false;
        if (types == ""Vegan"") {
            vegan = true;
        }
        if (types == ""Carne"") {
            meat = true;
        } if (types == ""Peixe"") {
            fish = true;
        }
        let zerototen = false;
        let tentotwenty = false;
        let twentyplus = false;
        let search = '");
#nullable restore
#line 199 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\Index.cshtml"
                 Write(ViewData["NomePrato"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
        $.ajax({
            type: ""GET"",
            url: ""/api/pratos"",
            data:
            {
                zerototen: zerototen,
                tentotwenty: tentotwenty,
                twentyplus: twentyplus,
                vegan: vegan,
                meat: meat,
                fish: fish,
                search: search
            }
        }).done((resp) => {
            lastresults = resp;
            RenderPage(resp);
        });
    </script>
");
#nullable restore
#line 218 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
