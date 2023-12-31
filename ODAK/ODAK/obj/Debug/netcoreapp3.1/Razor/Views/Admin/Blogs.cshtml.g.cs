#pragma checksum "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e534649f33290cf14fad987f466cefc7ab1a0b7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Blogs), @"mvc.1.0.view", @"/Views/Admin/Blogs.cshtml")]
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
#line 1 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\_ViewImports.cshtml"
using DentistCalendar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\_ViewImports.cshtml"
using DentistCalendar.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
using DentistCalendar.Data.Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e534649f33290cf14fad987f466cefc7ab1a0b7a", @"/Views/Admin/Blogs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71332de244a4adad55165bc5a286c630534707e1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_Blogs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Blog>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("120"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("60"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
  
    ViewData["Title"] = "Blogs";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
<h1>Bloglar</h1>
<hr />
<br />

<table class=""table table-bordered table-striped table-hover table-dark"">

    <thead>
       <tr>
            <th>Blog Adı</th>
            <th>Blog Başlığı</th>
            <th>Blog İçeriği</th>
            <th>Blog Resmi</th>
            <th>Blog Yazarı</th>
            <th>Sil </th>
       </tr>
    </thead>

    <tbody>

");
#nullable restore
#line 27 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
               Write(item.BlogName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
               Write(item.BlogTitle.Substring(0,25));

#line default
#line hidden
#nullable disable
            WriteLiteral("...</td>\r\n                <td>");
#nullable restore
#line 32 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
               Write(item.BlogContent.Substring(0,40));

#line default
#line hidden
#nullable disable
            WriteLiteral("...</td>\r\n                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e534649f33290cf14fad987f466cefc7ab1a0b7a6513", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 822, "~/blogimage/", 822, 12, true);
#nullable restore
#line 33 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
AddHtmlAttributeValue("", 834, item.BlogImageUrl, 834, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n");
#nullable restore
#line 34 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
                 foreach (var doctor in ViewBag.Blogs)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
                     if (doctor.Id==item.DoctorId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td> Dt. ");
#nullable restore
#line 38 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
                            Write(doctor.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 38 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
                                         Write(doctor.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 39 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                  \r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e534649f33290cf14fad987f466cefc7ab1a0b7a10020", async() => {
                WriteLiteral("Sil");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1193, "~/admin/DeleteBlog/", 1193, 19, true);
#nullable restore
#line 43 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"
AddHtmlAttributeValue("", 1212, item.Id, 1212, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 46 "C:\Users\Metin Yıldız\OneDrive - klu.edu.tr\Masaüstü\FullCalendar\DentistCalendar\DentistCalendar\Views\Admin\Blogs.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    </tbody>\r\n</table>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Blog>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
