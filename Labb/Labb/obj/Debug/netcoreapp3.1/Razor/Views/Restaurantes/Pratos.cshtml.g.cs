#pragma checksum "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Restaurantes\Pratos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01e4975d4b974bc64a003c21202a6d92747bd6b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurantes_Pratos), @"mvc.1.0.view", @"/Views/Restaurantes/Pratos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01e4975d4b974bc64a003c21202a6d92747bd6b4", @"/Views/Restaurantes/Pratos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"016b9a2e3b30ed8750926c5611148010ac32a865", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurantes_Pratos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "vegan", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "meat", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "fish", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\vitor\source\repos\Lab\Prato_do_Dia\Labb\Labb\Views\Restaurantes\Pratos.cshtml"
  
    ViewData["title"] = "Editar Prato do dia";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""card mt-2"">
    <div class=""card-header"">
        <h3>Criar Prato do Dia</h3>
    </div>
    <div class=""card-body"">
        <div class=""row"">
            <div class=""col-6"">
                <div class=""form-group"">
                    <label for=""nameinput"">Nome do Prato:</label>
                    <input type=""text"" class=""form-control"" id=""nameinput"" placeholder=""Nome do Prato"" />
                </div>
                <div class=""form-group"">
                    <label for=""descinput"">Descri????o do Prato:</label>
                    <textarea class=""form-control"" placeholder=""Descri????o do Prato"" id=""descinput""></textarea>
                </div>
            </div>
            <div class=""col-6"">
                <div class=""row"">
                    <div class=""col-6"">
                        <div class=""form-group"">
                            <label for=""typeinput"">Tipo de Prato:</label>
                            <select id=""typeinput"" class=""form-control"">
            ");
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01e4975d4b974bc64a003c21202a6d92747bd6b45318", async() => {
                WriteLiteral("Vegetariano");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01e4975d4b974bc64a003c21202a6d92747bd6b46514", async() => {
                WriteLiteral("Carne");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01e4975d4b974bc64a003c21202a6d92747bd6b47704", async() => {
                WriteLiteral("Peixe");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </select>
                        </div>
                    </div>
                    <div class=""col-6"">
                        <label for=""priceinput"">Pre??o do Prato:</label>
                        <input type=""number"" class=""form-control"" id=""priceinput"" placeholder=""Pre??o do Prato"" />
                    </div>
                </div>
                <div class=""form-group mt-2"">
                    <label for=""imginput"">Imagem do Prato:</label><br/>
                    <input type=""file"" accept=""image/jpeg, image/png"" id=""imginput"" class=""form-control-file"" />
                </div>
            </div>
        </div>
        <button class=""btn btn-primary mt-2"" id=""SaveNewPlate"">Criar novo prato</button>
    </div>
</div>

<div id=""main""></div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@" 
<script type=""text/javascript"">
    let __yeoldelement = [];
    $(document).ready(() => {
        $.ajax({
            type: ""GET"",
            url: ""/api/restaurantes/GetPlates""
        }).done((resp) => {
            __yeoldelement = resp;
            resp.forEach(elem => {
                CreateElement(elem);
            });
        }).catch((resp) => {
            toastr.error(""N??o foi possivel obter os pratos do dia"", ""Pratos do Dia"");
        });
    });

    $(""#SaveNewPlate"").on(""click"", () => {
        let nome = $(""#nameinput"").val();
        let desc = $(""#descinput"").val();
        let tipo = $(""#typeinput"").val();
        let preco = $(""#priceinput"").val();
        let image = $(""#imginput"")[0].files[0];
        let simulatedform = new FormData();
        simulatedform.append('nome', nome);
        simulatedform.append('desc', desc);
        simulatedform.append('tipo', tipo);
        simulatedform.append('preco', preco);
        simulatedform.append('image', image)");
                WriteLiteral(@";
        $.ajax({
            type: ""POST"",
            url: ""/api/restaurantes/CreatePlate"",
            data: simulatedform,
            processData: false,
            contentType: false
        }).done((resp) => {
            toastr.success(""prato criado com sucesso"", ""Pratos"");
            CreateElement(resp);
        }).catch((resp) => {
            toastr.error(""N??o foi possivel criar o prato"", ""Pratos"");
        });
    });

    function CreateElement(element) {
        $(""#main"").append(`<div class=""card mt-2"" onclick=""OnOldClick(this);"" data-oldid=""${element.idPrato}"">
                                <div class=""card-body"">
                                    <div class=""row"">
                                        <div class=""col-6"">
                                            <div class=""form-group"">
                                                <label for=""nameinput${element.idPrato}"">Nome do Prato:</label>
                                                <input type=""tex");
                WriteLiteral(@"t"" class=""form-control"" id=""nameinput${element.idPrato}"" placeholder=""Nome do Prato"" value=""${element.nome}"" readonly />
                                            </div>
                                            <div class=""form-group"">
                                                <label for=""descinput${element.idPrato}"">Descri????o do Prato:</label>
                                                <textarea class=""form-control"" placeholder=""Descri????o do Prato"" id=""descinput${element.idPrato}"" readonly>${element.descricao}</textarea>
                                            </div>
                                            <button class=""btn btn-danger mt-2"" onclick=""DeleteSelf(this);"">Apagar Prato</button>
                                        </div>
                                        <div class=""col-6"">
                                            <div class=""row"">
                                                <div class=""col-6"">
                                                   ");
                WriteLiteral(@" <div class=""form-group"">
                                                        <label for=""typeinput${element.idPrato}"">Tipo de Prato:</label>
                                                        <input type=""text"" class=""form-control"" id=""typeinput${element.idPrato}"" placeholder=""Tipo de Prato"" value=""${ConvertTipoPrato(element.tipoPrato)}"" readonly/>
                                                    </div>
                                                </div>
                                                <div class=""col-6"">
                                                    <label for=""priceinput${element.idPrato}"">Pre??o do Prato:</label>
                                                    <input type=""number"" class=""form-control"" id=""priceinput${element.idPrato}"" placeholder=""Pre??o do Prato"" value=""${element.preco}"" readonly />
                                                </div>
                                            </div>
                                            <div clas");
                WriteLiteral(@"s=""form-group mt-2"">
                                                <img class=""img-fluid"" src=""${element.foto}"" alt=""Imagem do Prato${element.idPrato}"" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>`);
    }

    function ConvertTipoPrato(tp) {
        if (tp == ""meat"") {
            return `Carne`;
        } else if (tp == ""fish"") {
            return `Peixe`;
        } else if (tp == ""vegan"") {
            return `Vegetariano`;
        } else {
            return `Desconhecido`;
        }
    }

    function OnOldClick(clickedelement) {
        __yeoldelement.forEach(element => {
            if (element.idPrato == $(clickedelement).attr(""data-oldid"")) {
                $(""#nameinput"").val(element.nome);
                $(""#descinput"").val(element.descricao);
                $(""#typeinput"").val(element.tipoPrato)");
                WriteLiteral(@";
                $(""#priceinput"").val(element.preco)
            }
        });
    }

    function DeleteSelf(element) {
        __yeoldelement.forEach(oldy => {
            if (oldy.idPrato == $(element).parent().parent().parent().parent().attr(""data-oldid"")) {
                $.ajax({
                    type: ""DELETE"",
                    url: `/api/restaurantes/DeletePlate/${oldy.idPrato}`
                }).done((resp) => {
                    toastr.success(""O Prato foi apagado com sucesso!"", ""Pratos"");
                    $(element).parent().parent().parent().parent().remove();
                }).catch((resp) => {
                    toastr.error(""N??o foi possivel apagar o prato por favor recarregue a p??gina e tente novamente"", ""Pratos"");
                });
            }
        })
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
