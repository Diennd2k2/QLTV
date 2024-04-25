#pragma checksum "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "83c08ce0ee35d6d5ca64f86065d80b82cb250f808f8a979bd7a1bd98c622db44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Readers_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Readers/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Readers/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Readers_Index))]
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
#line 2 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"83c08ce0ee35d6d5ca64f86065d80b82cb250f808f8a979bd7a1bd98c622db44", @"/Areas/Admin/Views/Readers/Index.cshtml")]
    public class Areas_Admin_Views_Readers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<QLTV.Models.Readers>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
            BeginContext(187, 1285, true);
            WriteLiteral(@"
<section class=""content"" style=""padding-top: 20px"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">Danh sách độc giả</h3>
                        <div class=""card-tools"">
                            <form action=""/Admin/Readers/Index"" method=""GET"">
                                <div class=""input-group input-group-sm"" style=""width: 350px;"">
                                    <input type=""text"" name=""Search"" class=""form-control float-right"" placeholder=""Nhâp tên độc giả..."">
                                    <div class=""input-group-append"">
                                        <button type=""submit"" class=""btn btn-default"">
                                            <i class=""fas fa-search""></i>
                                        </button>
                                    </div>
                         ");
            WriteLiteral(@"       </div>
                            </form>
                        </div>
                    </div>

                    <div class=""card-body"">
                        <a class=""btn btn-primary"" href=""/Admin/Readers/Create"">Thêm mới độc giả</a>
");
            EndContext();
#line 31 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                         if (TempData["success"] != null)
                        {

#line default
#line hidden
            BeginContext(1558, 132, true);
            WriteLiteral("                            <div class=\"alert alert-success\" role=\"alert\" style=\"margin-top:20px\">\r\n                                ");
            EndContext();
            BeginContext(1691, 29, false);
#line 34 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                           Write(Html.Raw(TempData["success"]));

#line default
#line hidden
            EndContext();
            BeginContext(1720, 38, true);
            WriteLiteral("\r\n                            </div>\r\n");
            EndContext();
#line 36 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                        }

#line default
#line hidden
#line 37 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                         if (TempData["eror"] != null)
                        {

#line default
#line hidden
            BeginContext(1868, 131, true);
            WriteLiteral("                            <div class=\"alert alert-danger\" role=\"alert\" style=\"margin-top:20px\">\r\n                                ");
            EndContext();
            BeginContext(2000, 26, false);
#line 40 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                           Write(Html.Raw(TempData["eror"]));

#line default
#line hidden
            EndContext();
            BeginContext(2026, 38, true);
            WriteLiteral("\r\n                            </div>\r\n");
            EndContext();
#line 42 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(2091, 918, true);
            WriteLiteral(@"                        <table class=""table table-bordered"" style=""margin-top: 20px"">
                            <h5>ViewBag.UserName</h5>
                            <thead>
                                <tr>
                                    <th style=""text-align: center"">Tên độc giả</th>
                                    <th style=""text-align: center"">Địa chỉ</th>
                                    <th style=""text-align: center"">Số điện thoại</th>
                                    <th style=""text-align: center"">Email</th>
                                    <th style=""text-align: center"">Ảnh đại diện</th>
                                    <th style=""text-align: center"">Ngày sinh</th>
                                    <th style=""text-align: center"">Số CMT, CCCD</th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 57 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                                 foreach (var readers in Model)
                                {

#line default
#line hidden
            BeginContext(3109, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(3196, 18, false);
#line 60 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                                       Write(readers.NameReader);

#line default
#line hidden
            EndContext();
            BeginContext(3214, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(3266, 21, false);
#line 61 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                                       Write(readers.AddressReader);

#line default
#line hidden
            EndContext();
            BeginContext(3287, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(3339, 19, false);
#line 62 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                                       Write(readers.PhoneReader);

#line default
#line hidden
            EndContext();
            BeginContext(3358, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(3410, 19, false);
#line 63 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                                       Write(readers.EmailReader);

#line default
#line hidden
            EndContext();
            BeginContext(3429, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(3480, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "83c08ce0ee35d6d5ca64f86065d80b82cb250f808f8a979bd7a1bd98c622db449903", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3490, "~/Avatars/", 3490, 10, true);
#line 64 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
AddHtmlAttributeValue("", 3500, readers.Avatar, 3500, 15, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 64 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
AddHtmlAttributeValue("", 3522, readers.NameReader, 3522, 19, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3556, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(3608, 48, false);
#line 65 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                                       Write(readers.DateOfBirth.Value.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(3656, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(3708, 16, false);
#line 66 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                                       Write(readers.Passport);

#line default
#line hidden
            EndContext();
            BeginContext(3724, 147, true);
            WriteLiteral("</td>\r\n                                        <td style=\"text-align: center\">\r\n                                            <a style=\"color: green\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3871, "\"", 3918, 2);
            WriteAttributeValue("", 3878, "/Admin/Readers/Edit?id=", 3878, 23, true);
#line 68 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
WriteAttributeValue("", 3901, readers.IdReader, 3901, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3919, 157, true);
            WriteLiteral(" title=\"Sửa thông tin\"><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></a>\r\n                                            <a style=\"color: red;padding-left: 20px\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4076, "\"", 4125, 2);
            WriteAttributeValue("", 4083, "/Admin/Readers/Delete?id=", 4083, 25, true);
#line 69 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
WriteAttributeValue("", 4108, readers.IdReader, 4108, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4126, 163, true);
            WriteLiteral(" title=\"Xóa bản ghi\"><i class=\"fa fa-trash\" aria-hidden=\"true\"></i></a>\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 72 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(4324, 265, true);
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>

                    <div class=""card-footer clearfix"">
                        <ul class=""pagination pagination-sm m-0 float-right"">
                            ");
            EndContext();
            BeginContext(4590, 401, false);
#line 79 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Index.cshtml"
                       Write(Html.PagedListPager(Model, page => Url.Action("Index", new { page = page }),
                                     new PagedListRenderOptions
                            {
                                LiElementClasses = new string[] { "page-item" },
                                PageClasses = new string[] { "page-link" }
                            }
                                     ));

#line default
#line hidden
            EndContext();
            BeginContext(4991, 147, true);
            WriteLiteral("\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<QLTV.Models.Readers>> Html { get; private set; }
    }
}
#pragma warning restore 1591
