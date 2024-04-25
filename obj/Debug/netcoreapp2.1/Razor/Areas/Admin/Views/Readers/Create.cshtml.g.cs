#pragma checksum "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Create.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1e5d2c7f161f6328bd8ffc5b3d74042c1341424c43fdaff8eb153364bc4ebb77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Readers_Create), @"mvc.1.0.view", @"/Areas/Admin/Views/Readers/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Readers/Create.cshtml", typeof(AspNetCore.Areas_Admin_Views_Readers_Create))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"1e5d2c7f161f6328bd8ffc5b3d74042c1341424c43fdaff8eb153364bc4ebb77", @"/Areas/Admin/Views/Readers/Create.cshtml")]
    public class Areas_Admin_Views_Readers_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Areas/Admin/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
            BeginContext(108, 984, true);
            WriteLiteral(@"

<section class=""content"" style=""padding-top: 20px"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""card card-primary"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">Thêm mới độc giả</h3>
                    </div>

                    <form action=""/Admin/Readers/Create"" method=""POST"" enctype=""multipart/form-data"">
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <div class=""form-group"">
                                        <label for=""NameReader""> Tên độc giả<span style=""color: red"">(*)</span></label>
                                        <input type=""text"" name=""NameReader"" class=""form-control"" placeholder=""Nhập tên độc giả"">
                                        <b class=""text-danger"">");
            EndContext();
            BeginContext(1093, 12, false);
#line 24 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Create.cshtml"
                                                          Write(ViewBag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1105, 1029, true);
            WriteLiteral(@"</b>
                                    </div>
                                </div>
                                <div class=""col-md-6"">
                                    <div class=""form-group"">
                                        <label for=""AddressReader""> Địa chỉ</label>
                                        <input type=""text"" name=""AddressReader"" class=""form-control"" placeholder=""Nhập địa chỉ"">
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <div class=""form-group"">
                                        <label for=""PhoneReader""> Số điện thoại<span style=""color: red"">(*)</span></label>
                                        <input type=""text"" name=""PhoneReader"" class=""form-control"" placeholder=""Nhập số điện thoại"">
                                        <b class=""text-dan");
            WriteLiteral("ger\">");
            EndContext();
            BeginContext(2135, 13, false);
#line 39 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Create.cshtml"
                                                          Write(ViewBag.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(2148, 69, true);
            WriteLiteral("</b>\r\n                                        <b class=\"text-danger\">");
            EndContext();
            BeginContext(2218, 18, false);
#line 40 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Create.cshtml"
                                                          Write(ViewBag.CheckPhone);

#line default
#line hidden
            EndContext();
            BeginContext(2236, 478, true);
            WriteLiteral(@"</b>
                                    </div>
                                </div>
                                <div class=""col-md-6"">
                                    <div class=""form-group"">
                                        <label for=""EmailReader""> Email</label>
                                        <input type=""text"" name=""EmailReader"" class=""form-control"" placeholder=""Nhập email"">
                                        <b class=""text-danger"">");
            EndContext();
            BeginContext(2715, 18, false);
#line 47 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Create.cshtml"
                                                          Write(ViewBag.CheckEmail);

#line default
#line hidden
            EndContext();
            BeginContext(2733, 961, true);
            WriteLiteral(@"</b>
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <div class=""form-group"">
                                        <label for=""Avatar""> Ảnh đại diện</label>
                                        <input type=""file"" class=""form-control-file"" name=""Avatar"">
                                    </div>
                                </div>
                                <div class=""col-md-6"">
                                    <div class=""form-group"">
                                        <label for=""DateOfBirth""> Ngày sinh<span style=""color: red"">(*)</span></label>
                                        <input type=""date"" name=""DateOfBirth"" class=""form-control"">
                                        <b class=""text-danger"">");
            EndContext();
            BeginContext(3695, 19, false);
#line 62 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Create.cshtml"
                                                          Write(ViewBag.DateOfBirth);

#line default
#line hidden
            EndContext();
            BeginContext(3714, 604, true);
            WriteLiteral(@"</b>
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <div class=""form-group"">
                                        <label for=""Passport""> Số CMT, CCCD<span style=""color: red"">(*)</span></label>
                                        <input type=""text"" name=""Passport"" class=""form-control"" placeholder=""Nhập số CMT, CCCD"">
                                        <b class=""text-danger"">");
            EndContext();
            BeginContext(4319, 16, false);
#line 71 "D:\SEM_IV\QLTV\QLTV\Areas\Admin\Views\Readers\Create.cshtml"
                                                          Write(ViewBag.Passport);

#line default
#line hidden
            EndContext();
            BeginContext(4335, 452, true);
            WriteLiteral(@"</b>
                                    </div>
                                </div>
                            </div>
                            <div class=""card-footer"">
                                <button type=""submit"" class=""btn btn-primary"">Lưu</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
