#pragma checksum "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23428c03ee74c522d29758de7aad0a475618aef1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_courses_admin_Views_Users_ChangeRole), @"mvc.1.0.view", @"/Areas/courses-admin/Views/Users/ChangeRole.cshtml")]
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
#line 1 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\_ViewImports.cshtml"
using BackProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\_ViewImports.cshtml"
using BackProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23428c03ee74c522d29758de7aad0a475618aef1", @"/Areas/courses-admin/Views/Users/ChangeRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5eddc7a407ccd33b9c5b140008f03f87a0dfb251", @"/Areas/courses-admin/Views/_ViewImports.cshtml")]
    public class Areas_courses_admin_Views_Users_ChangeRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
  
    ViewData["Title"] = "Change Role";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""card"">
    <div class=""card-header header-elements-inline"">
        <h5 class=""card-title"">Category</h5>
        <div class=""header-elements"">
            <div class=""list-icons"">
                <a class=""list-icons-item"" data-action=""collapse""></a>
                <a class=""list-icons-item"" data-action=""reload""></a>
            </div>
        </div>
    </div>
    <div class=""card-body"">
        <p class=""text-capitalize"">Name: ");
#nullable restore
#line 16 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                                    Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"text-capitalize\">Surname: ");
#nullable restore
#line 17 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                                       Write(Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"text-capitalize\">Phone Number: ");
#nullable restore
#line 18 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                                            Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"text-capitalize\">Image: ");
#nullable restore
#line 19 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                                     Write(Model.Image);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"text-capitalize\">Email: ");
#nullable restore
#line 20 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                                     Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"text-capitalize\">Username: ");
#nullable restore
#line 21 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                                        Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"text-capitalize\">Role: ");
#nullable restore
#line 22 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                                    Write(Model.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 23 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
         if (TempData["error"] != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div>");
#nullable restore
#line 25 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
            Write(TempData["error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 26 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23428c03ee74c522d29758de7aad0a475618aef17901", async() => {
                WriteLiteral("\r\n            <div>\r\n");
#nullable restore
#line 30 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                 foreach (string item in Model.Roles)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                     if (Model.Role == item)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"radio\" name=\"role\"");
                BeginWriteAttribute("value", " value=\"", 1273, "\"", 1286, 1);
#nullable restore
#line 34 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
WriteAttributeValue("", 1281, item, 1281, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 1287, "\"", 1297, 1);
#nullable restore
#line 34 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
WriteAttributeValue("", 1292, item, 1292, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" checked />\r\n");
#nullable restore
#line 35 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"radio\" name=\"role\"");
                BeginWriteAttribute("value", " value=\"", 1438, "\"", 1451, 1);
#nullable restore
#line 38 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
WriteAttributeValue("", 1446, item, 1446, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("id", " id=\"", 1452, "\"", 1462, 1);
#nullable restore
#line 38 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
WriteAttributeValue("", 1457, item, 1457, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 39 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <label");
                BeginWriteAttribute("for", " for=\"", 1517, "\"", 1528, 1);
#nullable restore
#line 40 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
WriteAttributeValue("", 1523, item, 1523, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"text-capitalize\"> ");
#nullable restore
#line 40 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                                                           Write(item);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n");
#nullable restore
#line 41 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Areas\courses-admin\Views\Users\ChangeRole.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        <div class=\"card-footer d-flex flex-row-reverse mt-3\" >\r\n            <button type=\"submit\" class=\"btn btn-success\">Save</button>\r\n        </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    \r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
