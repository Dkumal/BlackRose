#pragma checksum "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48e09a3d5f9e22cc646110063ffa1a333be3b0d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MedicalRecord_History), @"mvc.1.0.view", @"/Views/MedicalRecord/History.cshtml")]
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
#line 2 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\_ViewImports.cshtml"
using Black_Rose.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48e09a3d5f9e22cc646110063ffa1a333be3b0d9", @"/Views/MedicalRecord/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e9cbc1ccda0650b5901adfc6c71915a02083964", @"/Views/_ViewImports.cshtml")]
    public class Views_MedicalRecord_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
  
    ViewData["Title"] = "Medical Records History";
    Layout = "~/Views/Shared/admin/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\nNama Hewan : ");
#nullable restore
#line 6 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
        Write(ViewData["NamaHewan"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n");
            WriteLiteral(@"            <td>Tanggal Periksa</td>
            <td>Dokter</td>
            <td>Bobot</td>
            <td>Umur</td>
            <td>Diagnosa</td>
            <td>Terapi</td>
            <td colspan=""2"" align=""center"">Action</td>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 22 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
         foreach (var data in ViewData["DataHistory"] as IEnumerable<Black_Rose.Models.ExaminationFormModel>)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 25 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
           Write(String.Format("{0:dd/MM/yyyy}", data.examdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
           Write(data.iddokter);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n            <td>");
#nullable restore
#line 27 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
           Write(data.weight);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n            <td>");
#nullable restore
#line 28 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
           Write(data.age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 29 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
           Write(data.diagnose);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n            <td>");
#nullable restore
#line 30 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
           Write(data.therapy);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n            <td>");
            WriteLiteral("</td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 34 "D:\G\latian\Black Rose\Black Rose\Black Rose\Views\MedicalRecord\History.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
