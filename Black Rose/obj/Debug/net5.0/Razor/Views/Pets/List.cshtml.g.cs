#pragma checksum "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2ff45ce67b4c974427e6798a0b01dd879a4ccac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pets_List), @"mvc.1.0.view", @"/Views/Pets/List.cshtml")]
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
#line 1 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\_ViewImports.cshtml"
using Black_Rose;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml"
using Black_Rose.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2ff45ce67b4c974427e6798a0b01dd879a4ccac", @"/Views/Pets/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e9cbc1ccda0650b5901adfc6c71915a02083964", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Pets_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Black_Rose.Models.PetModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Pets", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml"
  
    ViewData["Title"] = "List Pets";
    Layout = "~/Views/Shared/admin/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"card card-primary\">\r\n    <div class=\"card-header\">\r\n        <h3 class=\"card-title\">Search Pets</h3>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2ff45ce67b4c974427e6798a0b01dd879a4ccac4953", async() => {
                WriteLiteral(@"
            <table>
                <tr>
                    <td>
                        <div class=""form-group"">
                            <label>Nama</label>
                            <input type=""text"" class=""form-control"" id=""namahewan"" name=""namahewan"" />
                        </div>
                    </td>
                    <td>
                        <div class=""form-group"">
                            <label>Jenis Hewan</label>
                            <input type=""text"" class=""form-control"" id=""klasifikasi"" name=""klasifikasi"" />
                        </div>
                    </td>
                    <td>
                        <div class=""form-group"">
                            <label>Nama Pemilik</label>
                            <input type=""text"" class=""form-control"" id=""pemilik"" name=""pemilik"" />
                        </div>
                    </td>
                </tr>
            </table>
            <div class="" form-group"">
                ");
                WriteLiteral("<button type=\"submit\" class=\"btn btn-primary\">Search</button>\r\n                <button type=\"reset\" class=\"btn btn-default\">Clear</button>\r\n            </div>\r\n\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <div class=""card-footer""></div>
</div>

<div class=""card card-info"">
    <div class=""card-header"">
        <h3 class=""card-title"">List hewan</h3>
    </div>
    <div class=""card-body"">
        <table class=""table table-striped"">
            <thead>
                <tr>
");
            WriteLiteral("                    <td>Nama Pemilik</td>\r\n                    <td>Nama Hewan</td>\r\n                    <td>Jenis</td>\r\n                    <td colspan=\"2\" align=\"center\">Action</td>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 62 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml"
                 foreach (var data in ViewData["Pets"] as IEnumerable<Black_Rose.Models.PetModel>)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 65 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml"
                       Write(data.idpemilik);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 66 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml"
                       Write(data.nama);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 67 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml"
                       Write(data.jenis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 2520, "\"", 2573, 2);
            WriteAttributeValue("", 2527, "https://localhost:44360/pets/editpage/", 2527, 38, true);
#nullable restore
#line 68 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml"
WriteAttributeValue("", 2565, data.id, 2565, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"icofont-edit\"></i></a></td>\r\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 2644, "\"", 2695, 2);
            WriteAttributeValue("", 2651, "https://localhost:44360/pets/delete/", 2651, 36, true);
#nullable restore
#line 69 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml"
WriteAttributeValue("", 2687, data.id, 2687, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"icofont-delete-alt\"></i></a></td>\r\n");
            WriteLiteral("\r\n                    </tr>\r\n");
#nullable restore
#line 73 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Pets\List.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </tbody>
        </table>

    </div>
    <div class=""card-footer"">
        <button type=""button"" class=""btn btn-primary"" onclick=""ToCreate()"">New Pet</button>

    </div>

</div>


<script>
    function ToCreate() {
        window.location = ""/pets/AddPage"";
    };
</script>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Black_Rose.Models.PetModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
