#pragma checksum "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e23af86d0c035d18adbfed689368ef7e6722014"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\_ViewImports.cshtml"
using RentABag.Web;

#line default
#line hidden
#line 2 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\_ViewImports.cshtml"
using RentABag.Models;

#line default
#line hidden
#line 3 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\_ViewImports.cshtml"
using RentABag.Web.Models;

#line default
#line hidden
#line 4 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\_ViewImports.cshtml"
using RentABag.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e23af86d0c035d18adbfed689368ef7e6722014", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70395050207b6ba9435e36ca82eb396df6506f98", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CollectionViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Bag", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(28, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "RentABag";
    BagViewModel dealOfTheWeek = ViewData["DealOfTheWeek"] as BagViewModel;
    var bestSellers = ViewData["BestSellers"] as IEnumerable<BagViewModel>;

#line default
#line hidden
            BeginContext(228, 304, true);
            WriteLiteral(@"
<!-- Slider -->


<div class=""main_slider"" style=""background-image:url(images/slider1.jpg)"">
    <div class=""container fill_height"">
        <div class=""row align-items-center fill_height"">
            <div class=""col"">
                <div class=""main_slider_content"">
                    <h6>");
            EndContext();
            BeginContext(533, 10, false);
#line 17 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\Home\Index.cshtml"
                   Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(543, 750, true);
            WriteLiteral(@"</h6>
                    <h1>Get up to 30% Off New Arrivals</h1>
                    <div class=""red_button shop_now_button""><a href=""#"">rent now</a></div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- New Arrivals -->

<div class=""new_arrivals"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col text-center"">
                <div class=""section_title new_arrivals_title"">
                    <h2>New Arrivals</h2>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col"">
                <div class=""product_slider_container"">
                    <div class=""owl-carousel owl-theme product_slider"">

");
            EndContext();
#line 42 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\Home\Index.cshtml"
                         foreach (var bag in Model.Bags)
                        {
                            await Html.RenderPartialAsync("BagScrollableDisplayTemplate", bag, ViewData);
                        }

#line default
#line hidden
            BeginContext(1512, 2412, true);
            WriteLiteral(@"
                    </div>
                    <div class=""product_slider_nav_left product_slider_nav  align-items-center justify-content-center flex-column"">
                        <i class=""fa fa-chevron-left""></i>
                    </div>
                    <div class=""product_slider_nav_right product_slider_nav d-flex align-items-center justify-content-center flex-column"">
                        <i class=""fa fa-chevron-right""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Deal of the week -->

<div class=""deal_ofthe_week"">
    <div class=""container"">
        <div class=""row align-items-center"">
            <div class=""col-lg-6"">
                <div class=""deal_ofthe_week_img"">
                    <img src=""images/deal_ofthe_week.png"" alt="""">
                </div>
            </div>
            <div class=""col-lg-6 text-right deal_ofthe_week_col"">
                <div class=""deal_ofthe_week_content d-flex fle");
            WriteLiteral(@"x-column align-items-center float-right"">
                    <div class=""section_title"">
                        <h2>Deal Of The Week</h2>
                    </div>
                    <ul class=""timer"">
                        <li class=""d-inline-flex flex-column justify-content-center align-items-center"">
                            <div id=""day"" class=""timer_num"">03</div>
                            <div class=""timer_unit"">Day</div>
                        </li>
                        <li class=""d-inline-flex flex-column justify-content-center align-items-center"">
                            <div id=""hour"" class=""timer_num"">15</div>
                            <div class=""timer_unit"">Hours</div>
                        </li>
                        <li class=""d-inline-flex flex-column justify-content-center align-items-center"">
                            <div id=""minute"" class=""timer_num"">45</div>
                            <div class=""timer_unit"">Mins</div>
                        </l");
            WriteLiteral(@"i>
                        <li class=""d-inline-flex flex-column justify-content-center align-items-center"">
                            <div id=""second"" class=""timer_num"">23</div>
                            <div class=""timer_unit"">Sec</div>
                        </li>
                    </ul>
                    <div class=""red_button shop_now_button"">");
            EndContext();
            BeginContext(3924, 102, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80da540c86d24a44b4a661673a5c2af7", async() => {
                BeginContext(4014, 8, true);
                WriteLiteral("rent now");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 93 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\Home\Index.cshtml"
                                                                                                                       WriteLiteral(dealOfTheWeek.Id);

#line default
#line hidden
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
            EndContext();
            BeginContext(4026, 598, true);
            WriteLiteral(@"</div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Best Sellers -->

<div class=""best_sellers"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col text-center"">
                <div class=""section_title new_arrivals_title"">
                    <h2>Best Sellers</h2>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col"">
                <div class=""product_slider_container"">
                    <div class=""owl-carousel owl-theme product_slider"">

");
            EndContext();
#line 116 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\Home\Index.cshtml"
                         foreach (var bag in bestSellers)
                        {
                            await Html.RenderPartialAsync("BagScrollableDisplayTemplate", bag, ViewData);
                        }

#line default
#line hidden
            BeginContext(4844, 552, true);
            WriteLiteral(@"
                    </div>
                    <div class=""product_slider_nav_left product_slider_nav  align-items-center justify-content-center flex-column"">
                        <i class=""fa fa-chevron-left""></i>
                    </div>
                    <div class=""product_slider_nav_right product_slider_nav d-flex align-items-center justify-content-center flex-column"">
                        <i class=""fa fa-chevron-right""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CollectionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
