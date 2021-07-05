#pragma checksum "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd86f515a748c7a47eb26cf38a97a824e9ec25e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pratos_favoritos), @"mvc.1.0.view", @"/Views/Pratos/favoritos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd86f515a748c7a47eb26cf38a97a824e9ec25e6", @"/Views/Pratos/favoritos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"016b9a2e3b30ed8750926c5611148010ac32a865", @"/Views/_ViewImports.cshtml")]
    public class Views_Pratos_favoritos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
  
    ViewData["title"] = "Lista de Favoritos";
    List<PratoDoDium> pratosfavoritos = (List<PratoDoDium>)ViewData["favoritos"];

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
 foreach (PratoDoDium prato in pratosfavoritos)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-3\">\r\n            <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 275, "\"", 292, 1);
#nullable restore
#line 9 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
WriteAttributeValue("", 281, prato.Foto, 281, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Capa de Restaurante\" />\r\n        </div>\r\n        <div class=\"col-6\">\r\n            <p><b>");
#nullable restore
#line 12 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
             Write(prato.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n            <p><b>");
#nullable restore
#line 13 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
             Write(prato.restaurante.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n            <p>");
#nullable restore
#line 14 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
          Write(prato.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n        <div class=\"col-3 text-center\">\r\n            <input type=\"text\" class=\"form-control\"");
            BeginWriteAttribute("value", " value=\"", 604, "\"", 651, 1);
#nullable restore
#line 17 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
WriteAttributeValue("", 612, prato.DataPrato.ToString("dd/MM/yyyy"), 612, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n            <p class=\"mt-2\">");
#nullable restore
#line 18 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
                       Write(prato.Preco.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("€</p>\r\n            <button class=\"btn btn-danger\" onclick=\"RemFromFavClick(this);\" data-plate=\"");
#nullable restore
#line 19 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
                                                                                   Write(prato.IdPrato);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Remover dos Favoritos</button>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 22 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Pratos\favoritos.cshtml"
}

#line default
#line hidden
#nullable disable
            DefineSection("scripts", async() => {
                WriteLiteral(@" 
<script type=""text/javascript"">
    function RemFromFavClick(element) {
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
                $(element).parent().parent().remove();
            } else {
                toastr.error('Prato adicionado aos favoritos com sucesso!', 'Favoritos');
                console.log(""WTF!!!!"");
            }
        }).catch((resp) => {
            toastr.error('Não foi possivel remover o prato dos favoritos', 'Favoritos');
        });
    }
</script>
");
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