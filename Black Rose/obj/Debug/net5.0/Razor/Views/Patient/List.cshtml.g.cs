#pragma checksum "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9b7408571ab39bc28533832ffbcca255a0d0bec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient_List), @"mvc.1.0.view", @"/Views/Patient/List.cshtml")]
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
#line 6 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
using Black_Rose.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9b7408571ab39bc28533832ffbcca255a0d0bec", @"/Views/Patient/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e9cbc1ccda0650b5901adfc6c71915a02083964", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Patient_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Black_Rose.Models.PatientModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
  
    ViewData["Title"] = "List User";
    Layout = "~/Views/Shared/admin/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""col-12"">
    <div class=""card"">
        <div class=""card-header"">
            <h3 class=""card-title"">List User</h3>
        </div>
        <div class=""card-body"">
            <table class=""table table-bordered table-striped table-hover"">
                <thead>
                    <tr>
");
            WriteLiteral(@"                        <td>Name</td>
                        <td>Address</td>
                        <td>Email</td>
                        <td>Phone</td>
                        <td>KTP</td>
                        <td colspan=""2"" align=""center"">Action</td>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 28 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
                     foreach (var data in ViewData["patients"] as IEnumerable<Black_Rose.Models.PatientModel>)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 31 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
                           Write(string.Concat(data.first_name, " ", data.last_name));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td>");
#nullable restore
#line 32 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
                           Write(data.address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
                           Write(data.email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 34 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
                           Write(data.phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 35 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
                           Write(data.ktp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td><a");
            BeginWriteAttribute("href", " href=\"", 1354, "\"", 1410, 2);
            WriteAttributeValue("", 1361, "https://localhost:44360/patient/editpage/", 1361, 41, true);
#nullable restore
#line 36 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
WriteAttributeValue("", 1402, data.id, 1402, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a></td>\r\n                            <td><a");
            BeginWriteAttribute("href", " href=\"", 1461, "\"", 1515, 2);
            WriteAttributeValue("", 1468, "https://localhost:44360/patient/delete/", 1468, 39, true);
#nullable restore
#line 37 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
WriteAttributeValue("", 1507, data.id, 1507, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a></td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 40 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\Patient\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </tbody>
            </table>
        </div>
    </div>

    <button type=""button"" class=""btn btn-primary"" onclick=""ToCreate()"">New Patient</button>

</div>


<script>
    function ToCreate() {
        window.location = ""/patient/AddPage"";
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Black_Rose.Models.PatientModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591