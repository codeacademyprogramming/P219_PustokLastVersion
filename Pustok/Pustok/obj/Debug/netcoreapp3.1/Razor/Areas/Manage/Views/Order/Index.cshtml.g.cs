#pragma checksum "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbd1d5a37eefb20dea384a0dadfec45c0be5e117"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Order_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/Order/Index.cshtml")]
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
#line 1 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\_ViewImports.cshtml"
using Pustok.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbd1d5a37eefb20dea384a0dadfec45c0be5e117", @"/Areas/Manage/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d031d3b56a8961b643bb2c798b149e0470578013", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Manage/Views/Shared/_Layout.cshtml";

    int selectedPage = (int)ViewBag.SelectedPage;
    int totalPage = (int)ViewBag.TotalPage;

    int i = ((int)ViewBag.SelectedPage - 1) * 5;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <table class=""table table-bordered"">
        <thead>
            <tr class=""row"">
                <th class=""col-md-1"">#</th>
                <th class=""col-md-2"">User</th>
                <th class=""col-md-1"">Item count</th>
                <th class=""col-md-2"">TotalPrice</th>
                <th class=""col-md-1"">Benefit</th>
                <th class=""col-md-2"">Date</th>
                <th class=""col-md-2"">Status</th>
                <th class=""col-md-1""></th>
            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 28 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
             foreach (var item in Model)
            {
                i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"row\">\r\n                <td class=\"col-md-1\">");
#nullable restore
#line 32 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-md-2\">");
#nullable restore
#line 33 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-md-1\">");
#nullable restore
#line 34 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                Write(item.OrderBooks.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-md-2\">");
#nullable restore
#line 35 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 36 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                  
                    var totalPrPrice = item.OrderBooks.Sum(x => (x.ProducingPrice * x.Count));
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"col-md-1\">");
#nullable restore
#line 39 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                 Write(item.TotalPrice - totalPrPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-md-2\">");
#nullable restore
#line 40 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                Write(item.CreatedAt.ToString("dd MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"col-md-2\">\r\n");
#nullable restore
#line 42 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                      

                        if (item.Status == Pustok.Enums.OrderStatus.Accepted)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span style=\"padding:10px\" class=\"badge badge-pill badge-secondary\">Accepted</span>\r\n");
#nullable restore
#line 47 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                        }
                        else if (item.Status == Pustok.Enums.OrderStatus.Pending)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span style=\"padding:10px\" class=\"badge badge-pill badge-info\">Pending</span>\r\n");
#nullable restore
#line 51 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span style=\"padding:10px\" class=\"badge badge-pill badge-danger\">");
#nullable restore
#line 54 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                                                                     Write(item.Status == Pustok.Enums.OrderStatus.UserReject?"User rejected":"Admin rejected");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 55 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                        }


                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td class=\"col-md-1\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbd1d5a37eefb20dea384a0dadfec45c0be5e11710193", async() => {
                WriteLiteral("Detail");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 64 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </tbody>\r\n\r\n    </table>\r\n    <nav aria-label=\"Page navigation example\">\r\n        <ul class=\"pagination\">\r\n            <li");
            BeginWriteAttribute("class", " class=\"", 2683, "\"", 2733, 2);
            WriteAttributeValue("", 2691, "page-item", 2691, 9, true);
#nullable restore
#line 71 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
WriteAttributeValue(" ", 2700, selectedPage==1?"disabled":"", 2701, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbd1d5a37eefb20dea384a0dadfec45c0be5e11713404", async() => {
                WriteLiteral("Previous");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                                                                                                WriteLiteral(selectedPage-1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n\r\n");
#nullable restore
#line 73 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
              
                int startpage = selectedPage - 1;
                int endPage = selectedPage + 1;

                if (selectedPage == 1)
                {
                    startpage = 1;
                    endPage = 3 > totalPage ? totalPage : 3;
                }
                else if (selectedPage == totalPage)
                {
                    startpage = (selectedPage - 2) < 1 ? 1 : selectedPage - 2;
                    endPage = totalPage;
                }

            

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
             for (int j = startpage; j <= endPage; j++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li");
            BeginWriteAttribute("class", " class=\"", 3446, "\"", 3494, 2);
            WriteAttributeValue("", 3454, "page-item", 3454, 9, true);
#nullable restore
#line 91 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
WriteAttributeValue(" ", 3463, j==selectedPage?"active":"", 3464, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbd1d5a37eefb20dea384a0dadfec45c0be5e11717278", async() => {
#nullable restore
#line 91 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                                                                                                            Write(j);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 91 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                                                                                                 WriteLiteral(j);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 92 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li");
            BeginWriteAttribute("class", " class=\"", 3599, "\"", 3658, 3);
            WriteAttributeValue("", 3607, "page-item", 3607, 9, true);
#nullable restore
#line 93 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
WriteAttributeValue(" ", 3616, selectedPage==totalPage?"disabled":"", 3617, 40, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3657, "", 3658, 1, true);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbd1d5a37eefb20dea384a0dadfec45c0be5e11720718", async() => {
                WriteLiteral("Next");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "C:\Users\Eagha\Desktop\CodeLessons\P219\Asp\PustokProject\Pustok\Pustok\Areas\Manage\Views\Order\Index.cshtml"
                                                                                                                         WriteLiteral(selectedPage+1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n        </ul>\r\n    </nav>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
