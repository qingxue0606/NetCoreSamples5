#pragma checksum "D:\net\NetCoreSamples5\Views\POBrowser\Word.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2aee686100c7bf3fa016519e1f52cee4f659386c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_POBrowser_Word), @"mvc.1.0.view", @"/Views/POBrowser/Word.cshtml")]
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
#line 1 "D:\net\NetCoreSamples5\Views\_ViewImports.cshtml"
using NetCoreSamples5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\net\NetCoreSamples5\Views\_ViewImports.cshtml"
using NetCoreSamples5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2aee686100c7bf3fa016519e1f52cee4f659386c", @"/Views/POBrowser/Word.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"505bb543589943979fe8508ca1881952d0e3a17b", @"/Views/_ViewImports.cshtml")]
    public class Views_POBrowser_Word : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("lang", new global::Microsoft.AspNetCore.Html.HtmlString("en"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\net\NetCoreSamples5\Views\POBrowser\Word.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2aee686100c7bf3fa016519e1f52cee4f659386c4578", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <title> 选项卡</title>
    <style type=""text/css"">
        /* CSS样式制作 */
        * {
            padding: 0px;
            margin: 0px;
        }

        a {
            text-decoration: none;
            color: black;
        }

            a:hover {
                text-decoration: none;
                color: #336699;
            }

        #tab {
            width: auto;
            padding: 5px;
            height: 150px;
            margin: 20px;
        }

            #tab ul {
                list-style: none;
                height: 30px;
                line-height: 30px;
                border-bottom: 2px #C88 solid;
            }

                #tab ul li {
                    background: #FFF;
                    cursor: pointer;
                    float: left;
                    list-style: none height:29px;
                    line-height: 29px;
                    padding: 0px 10px;
                    margin: 0px 3px;");
                WriteLiteral(@"
                    border: 1px solid #BBB;
                    border-bottom: 2px solid #C88;
                }

                    #tab ul li.on {
                        border-top: 2px solid Saddlebrown;
                        border-bottom: 2px solid #FFF;
                    }

            #tab div {
                height: 700px;
                width: auto;
                line-height: 24px;
                border-top: none;
                padding: 1px;
                border: 1px solid #336699;
                padding: 10px;
            }

        .hide {
            display: none;
        }

        .show {
            display: block;
        }

        .page {
        }
    </style>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2aee686100c7bf3fa016519e1f52cee4f659386c6638", async() => {
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
                WriteLiteral(@"
    <script type=""text/javascript"">
        // JS实现选项卡切换
        window.onload = function() {
            var myTab = document.getElementById(""tab"");    //整个div
            var myUl = myTab.getElementsByTagName(""ul"")[0]; //一个节点
            var myLi = myUl.getElementsByTagName(""li"");    //数组
            var myDiv = $("".page""); //myTab.getElementsByTagName(""div""); //数组

            for (var i = 0; i < myLi.length; i++) {
                myLi[i].index = i;
                myLi[i].onclick = function() {
                    for (var j = 0; j < myLi.length; j++) {
                        myLi[j].className = ""off"";
                        myDiv[j].className = ""hide"";
                    }
                    this.className = ""on"";
                    myDiv[this.index].className = ""show"";
                }
            }
        }
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2aee686100c7bf3fa016519e1f52cee4f659386c9499", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"">
        function SaveDocument() {
            document.getElementById(""PageOfficeCtrl1"").WebSave();
        }
        function PrintSet() {
            document.getElementById(""PageOfficeCtrl1"").ShowDialog(5);
        }
        function PrintFile() {
            document.getElementById(""PageOfficeCtrl1"").ShowDialog(4);
        }
        function Close() {
            window.external.close();
        }
        function IsFullScreen() {
            document.getElementById(""PageOfficeCtrl1"").FullScreen = !document.getElementById(""PageOfficeCtrl1"").FullScreen;
        }
        //文档关闭前先提示用户是否保存
        function BeforeBrowserClosed() {
            if (document.getElementById(""PageOfficeCtrl1"").IsDirty) {
                if (confirm(""提示：文档已被修改，是否继续关闭放弃保存 ？"")) {
                    return true;

                } else {

                    return false;
                }

            }

        }
    </script>

    <div style="" text-align:cente");
                WriteLiteral(@"r; margin:10px; background-color:#D19275; color:White; padding:8px;""><h1>某某Web办公系统</h1></div>
    <!-- HTML页面布局 -->
    <div id=""tab"">
        <ul>
            <li class=""on"">Word文件</li>
            <li class=""off"">文档属性</li>
            <li class=""off"">XX选项卡</li>
        </ul>
        <div id=""firstPage"" class=""page show"">
            <div style=""width: auto; height: 700px;"">
                ");
#nullable restore
#line 148 "D:\net\NetCoreSamples5\Views\POBrowser\Word.cshtml"
           Write(Html.Raw(ViewBag.POCtrl));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </div>
        <div id=""secondPage"" class=""page hide"" style=""  "">
            <p style="" line-height:40px;"">
                文件格式：word<br />
                作者：张三<br />
                XXXX：-----<br />
                XXXX：---<br />
                XXXX：------------------<br />
                XXXX：xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            </p>
        </div>
        <div id=""AAPage"" class=""page hide"">
            XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        </div>

    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
