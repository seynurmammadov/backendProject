#pragma checksum "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5c7b70ce7cd04087d6b2bc651a5bfd9a7f1e792"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 1 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\_ViewImports.cshtml"
using BackProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\_ViewImports.cshtml"
using BackProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5c7b70ce7cd04087d6b2bc651a5bfd9a7f1e792", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5eddc7a407ccd33b9c5b140008f03f87a0dfb251", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SiteInfo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/site/img/contact/contact1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("contact"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/site/img/contact/contact2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/site/img/contact/contact3.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "contact";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml"
Write(await Component.InvokeAsync("SiteTitle", "contact"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Contact Start -->
<div class=""map-area"">
    <!-- google-map-area start -->
    <div class=""google-map-area"">
        <!--  Map Section -->
        <div id=""contacts"" class=""map-area"">
            <div id=""googleMap"" style=""width:100%;height:440px;""></div>
        </div>
    </div>
</div>
<div class=""contact-area pt-150 pb-140"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-5 col-sm-5 col-xs-12"">
                <div class=""contact-contents text-center"">
                    <div class=""single-contact mb-65"">
                        <div class=""contact-icon"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d5c7b70ce7cd04087d6b2bc651a5bfd9a7f1e7925825", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"contact-add\">\r\n                            <h3>address</h3>\r\n                            <p>");
#nullable restore
#line 27 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml"
                          Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"single-contact mb-65\">\r\n                        <div class=\"contact-icon\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d5c7b70ce7cd04087d6b2bc651a5bfd9a7f1e7927596", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"contact-add\">\r\n                            <h3>Phone</h3>\r\n                            <p>");
#nullable restore
#line 36 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml"
                          Write(Model.PhoneNumber1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"single-contact\">\r\n                        <div class=\"contact-icon\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d5c7b70ce7cd04087d6b2bc651a5bfd9a7f1e7929364", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"contact-add\">\r\n                            <h3>Email Address</h3>\r\n                            <p>");
#nullable restore
#line 45 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml"
                          Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-7 col-sm-7 col-xs-12\">\r\n                ");
#nullable restore
#line 51 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml"
           Write(await Component.InvokeAsync("LeaveReply"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- Contact End -->\r\n");
#nullable restore
#line 58 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml"
Write(await Component.InvokeAsync("Subscribe"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyDSLSFRa0DyBj9VGzT7GM6SFbSMcG0YNBM""></script>
    <script type=""text/javascript"">
        google.maps.event.addDomListener(window, 'load', init);
        function init() {
            var mapOptions = {
                zoom: 11,
                center: new google.maps.LatLng(");
#nullable restore
#line 66 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml"
                                          Write(Model.LocationLatitude);

#line default
#line hidden
#nullable disable
                WriteLiteral(", ");
#nullable restore
#line 66 "C:\Users\agase\OneDrive\Рабочий стол\p314-asp-mvc-project-seynurmammadov\BackProject\Views\Contact\Index.cshtml"
                                                                   Write(Model.LocationLongitude);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"), // New York
                styles: [{ ""featureType"": ""water"", ""elementType"": ""geometry"", ""stylers"": [{ ""color"": ""#e9e9e9"" }, { ""lightness"": 17 }] }, { ""featureType"": ""landscape"", ""elementType"": ""geometry"", ""stylers"": [{ ""color"": ""#f5f5f5"" }, { ""lightness"": 20 }] }, { ""featureType"": ""road.highway"", ""elementType"": ""geometry.fill"", ""stylers"": [{ ""color"": ""#ffffff"" }, { ""lightness"": 17 }] }, { ""featureType"": ""road.highway"", ""elementType"": ""geometry.stroke"", ""stylers"": [{ ""color"": ""#ffffff"" }, { ""lightness"": 29 }, { ""weight"": 0.2 }] }, { ""featureType"": ""road.arterial"", ""elementType"": ""geometry"", ""stylers"": [{ ""color"": ""#ffffff"" }, { ""lightness"": 18 }] }, { ""featureType"": ""road.local"", ""elementType"": ""geometry"", ""stylers"": [{ ""color"": ""#ffffff"" }, { ""lightness"": 16 }] }, { ""featureType"": ""poi"", ""elementType"": ""geometry"", ""stylers"": [{ ""color"": ""#f5f5f5"" }, { ""lightness"": 21 }] }, { ""featureType"": ""poi.park"", ""elementType"": ""geometry"", ""stylers"": [{ ""color"": ""#dedede"" }, { ""lightness"": 21 }] }, { ""elementType"":");
                WriteLiteral(@" ""labels.text.stroke"", ""stylers"": [{ ""visibility"": ""on"" }, { ""color"": ""#ffffff"" }, { ""lightness"": 16 }] }, { ""elementType"": ""labels.text.fill"", ""stylers"": [{ ""saturation"": 36 }, { ""color"": ""#333333"" }, { ""lightness"": 40 }] }, { ""elementType"": ""labels.icon"", ""stylers"": [{ ""visibility"": ""off"" }] }, { ""featureType"": ""transit"", ""elementType"": ""geometry"", ""stylers"": [{ ""color"": ""#f2f2f2"" }, { ""lightness"": 19 }] }, { ""featureType"": ""administrative"", ""elementType"": ""geometry.fill"", ""stylers"": [{ ""color"": ""#fefefe"" }, { ""lightness"": 20 }] }, { ""featureType"": ""administrative"", ""elementType"": ""geometry.stroke"", ""stylers"": [{ ""color"": ""#fefefe"" }, { ""lightness"": 17 }, { ""weight"": 1.2 }] }]
            };
            var mapElement = document.getElementById('googleMap');
            var map = new google.maps.Map(mapElement, mapOptions);
            var marker = new google.maps.Marker({
                position: map.getCenter(),
                animation: google.maps.Animation.BOUNCE,
                icon: 'img/map");
                WriteLiteral("-marker.png\',\r\n                map: map\r\n            });\r\n        }\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SiteInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591
