#pragma checksum "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cc9ee90393bfd6ef2f1e95d92a75580befdaa30"
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
using RentABag.Web.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cc9ee90393bfd6ef2f1e95d92a75580befdaa30", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7551c6c4c1b08464879f0bca5d7b649ea68017e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\VSProjects\RentABag\RentABag.Web\RentABag.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "RentABag";

#line default
#line hidden
            BeginContext(44, 30765, true);
            WriteLiteral(@"
<!-- Slider -->

<div class=""main_slider"" style=""background-image:url(images/slider_1.jpg)"">
    <div class=""container fill_height"">
        <div class=""row align-items-center fill_height"">
            <div class=""col"">
                <div class=""main_slider_content"">
                    <h6>Spring / Summer Collection 2017</h6>
                    <h1>Get up to 30% Off New Arrivals</h1>
                    <div class=""red_button shop_now_button""><a href=""#"">shop now</a></div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Banner -->

<div class=""banner"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-4"">
                <div class=""banner_item align-items-center"" style=""background-image:url(images/banner_1.jpg)"">
                    <div class=""banner_category"">
                        <a href=""categories.html"">women's</a>
                    </div>
                </div>
            </div>
            <div ");
            WriteLiteral(@"class=""col-md-4"">
                <div class=""banner_item align-items-center"" style=""background-image:url(images/banner_2.jpg)"">
                    <div class=""banner_category"">
                        <a href=""categories.html"">accessories's</a>
                    </div>
                </div>
            </div>
            <div class=""col-md-4"">
                <div class=""banner_item align-items-center"" style=""background-image:url(images/banner_3.jpg)"">
                    <div class=""banner_category"">
                        <a href=""categories.html"">men's</a>
                    </div>
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
        <div");
            WriteLiteral(@" class=""row align-items-center"">
            <div class=""col text-center"">
                <div class=""new_arrivals_sorting"">
                    <ul class=""arrivals_grid_sorting clearfix button-group filters-button-group"">
                        <li class=""grid_sorting_button button d-flex flex-column justify-content-center align-items-center active is-checked"" data-filter=""*"">all</li>
                        <li class=""grid_sorting_button button d-flex flex-column justify-content-center align-items-center"" data-filter="".women"">women's</li>
                        <li class=""grid_sorting_button button d-flex flex-column justify-content-center align-items-center"" data-filter="".accessories"">accessories</li>
                        <li class=""grid_sorting_button button d-flex flex-column justify-content-center align-items-center"" data-filter="".men"">men's</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col"">
");
            WriteLiteral(@"                <div class=""product-grid"" data-isotope='{ ""itemSelector"": "".product-item"", ""layoutMode"": ""fitRows"" }'>

                    <!-- Product 1 -->

                    <div class=""product-item men"">
                        <div class=""product discount product_filter"">
                            <div class=""product_image"">
                                <img src=""images/product_1.png"" alt="""">
                            </div>
                            <div class=""favorite favorite_left""></div>
                            <div class=""product_bubble product_bubble_right product_bubble_red d-flex flex-column align-items-center""><span>-$20</span></div>
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""single.html"">Fujifilm X100T 16 MP Digital Camera (Silver)</a></h6>
                                <div class=""product_price"">$520.00<span>$590.00</span></div>
                            </div>
                    ");
            WriteLiteral(@"    </div>
                        <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
                    </div>

                    <!-- Product 2 -->

                    <div class=""product-item women"">
                        <div class=""product product_filter"">
                            <div class=""product_image"">
                                <img src=""images/product_2.png"" alt="""">
                            </div>
                            <div class=""favorite""></div>
                            <div class=""product_bubble product_bubble_left product_bubble_green d-flex flex-column align-items-center""><span>new</span></div>
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""single.html"">Samsung CF591 Series Curved 27-Inch FHD Monitor</a></h6>
                                <div class=""product_price"">$610.00</div>
                            </div>
                        </div>
    ");
            WriteLiteral(@"                    <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
                    </div>

                    <!-- Product 3 -->

                    <div class=""product-item women"">
                        <div class=""product product_filter"">
                            <div class=""product_image"">
                                <img src=""images/product_3.png"" alt="""">
                            </div>
                            <div class=""favorite""></div>
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""single.html"">Blue Yeti USB Microphone Blackout Edition</a></h6>
                                <div class=""product_price"">$120.00</div>
                            </div>
                        </div>
                        <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
                    </div>

                    <!-- Product 4 -->

           ");
            WriteLiteral(@"         <div class=""product-item accessories"">
                        <div class=""product product_filter"">
                            <div class=""product_image"">
                                <img src=""images/product_4.png"" alt="""">
                            </div>
                            <div class=""product_bubble product_bubble_right product_bubble_red d-flex flex-column align-items-center""><span>sale</span></div>
                            <div class=""favorite favorite_left""></div>
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""single.html"">DYMO LabelWriter 450 Turbo Thermal Label Printer</a></h6>
                                <div class=""product_price"">$410.00</div>
                            </div>
                        </div>
                        <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
                    </div>

                    <!-- Product 5 -->

      ");
            WriteLiteral(@"              <div class=""product-item women men"">
                        <div class=""product product_filter"">
                            <div class=""product_image"">
                                <img src=""images/product_5.png"" alt="""">
                            </div>
                            <div class=""favorite""></div>
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""single.html"">Pryma Headphones, Rose Gold & Grey</a></h6>
                                <div class=""product_price"">$180.00</div>
                            </div>
                        </div>
                        <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
                    </div>

                    <!-- Product 6 -->

                    <div class=""product-item accessories"">
                        <div class=""product discount product_filter"">
                            <div class=""product_image"">
  ");
            WriteLiteral(@"                              <img src=""images/product_6.png"" alt="""">
                            </div>
                            <div class=""favorite favorite_left""></div>
                            <div class=""product_bubble product_bubble_right product_bubble_red d-flex flex-column align-items-center""><span>-$20</span></div>
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""#single.html"">Fujifilm X100T 16 MP Digital Camera (Silver)</a></h6>
                                <div class=""product_price"">$520.00<span>$590.00</span></div>
                            </div>
                        </div>
                        <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
                    </div>

                    <!-- Product 7 -->

                    <div class=""product-item women"">
                        <div class=""product product_filter"">
                            <div class=""pro");
            WriteLiteral(@"duct_image"">
                                <img src=""images/product_7.png"" alt="""">
                            </div>
                            <div class=""favorite""></div>
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""single.html"">Samsung CF591 Series Curved 27-Inch FHD Monitor</a></h6>
                                <div class=""product_price"">$610.00</div>
                            </div>
                        </div>
                        <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
                    </div>

                    <!-- Product 8 -->

                    <div class=""product-item accessories"">
                        <div class=""product product_filter"">
                            <div class=""product_image"">
                                <img src=""images/product_8.png"" alt="""">
                            </div>
                            <div class=""favori");
            WriteLiteral(@"te""></div>
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""single.html"">Blue Yeti USB Microphone Blackout Edition</a></h6>
                                <div class=""product_price"">$120.00</div>
                            </div>
                        </div>
                        <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
                    </div>

                    <!-- Product 9 -->

                    <div class=""product-item men"">
                        <div class=""product product_filter"">
                            <div class=""product_image"">
                                <img src=""images/product_9.png"" alt="""">
                            </div>
                            <div class=""product_bubble product_bubble_right product_bubble_red d-flex flex-column align-items-center""><span>sale</span></div>
                            <div class=""favorite favorite_left""></div>");
            WriteLiteral(@"
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""single.html"">DYMO LabelWriter 450 Turbo Thermal Label Printer</a></h6>
                                <div class=""product_price"">$410.00</div>
                            </div>
                        </div>
                        <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
                    </div>

                    <!-- Product 10 -->

                    <div class=""product-item men"">
                        <div class=""product product_filter"">
                            <div class=""product_image"">
                                <img src=""images/product_10.png"" alt="""">
                            </div>
                            <div class=""favorite""></div>
                            <div class=""product_info"">
                                <h6 class=""product_name""><a href=""single.html"">Pryma Headphones, Rose Gold & Grey</a");
            WriteLiteral(@"></h6>
                                <div class=""product_price"">$180.00</div>
                            </div>
                        </div>
                        <div class=""red_button add_to_cart_button""><a href=""#"">add to cart</a></div>
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
                <div class=""deal_ofthe_week_content d-flex flex-column align-items-center float-right"">
                    <div class=""section_title"">
                        <h2>Deal Of The Week</h2>
                    </div>
                    <ul class");
            WriteLiteral(@"=""timer"">
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
                        </li>
                        <li class=""d-inline-flex flex-column justify-content-center align-items-center"">
                            <div id=""second"" class=""timer_num"">23</div>
                 ");
            WriteLiteral(@"           <div class=""timer_unit"">Sec</div>
                        </li>
                    </ul>
                    <div class=""red_button deal_ofthe_week_button""><a href=""#"">shop now</a></div>
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

                        <!-- Slide 1 -->

                        <div class=""owl-item product_slider_item"">
                            <div class=""product-item"">
                                <div class=""product discount"">");
            WriteLiteral(@"
                                    <div class=""product_image"">
                                        <img src=""images/product_1.png"" alt="""">
                                    </div>
                                    <div class=""favorite favorite_left""></div>
                                    <div class=""product_bubble product_bubble_right product_bubble_red d-flex flex-column align-items-center""><span>-$20</span></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">Fujifilm X100T 16 MP Digital Camera (Silver)</a></h6>
                                        <div class=""product_price"">$520.00<span>$590.00</span></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 2 -->

                        <div class=""owl-item product_slider_item"">
            ");
            WriteLiteral(@"                <div class=""product-item women"">
                                <div class=""product"">
                                    <div class=""product_image"">
                                        <img src=""images/product_2.png"" alt="""">
                                    </div>
                                    <div class=""favorite""></div>
                                    <div class=""product_bubble product_bubble_left product_bubble_green d-flex flex-column align-items-center""><span>new</span></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">Samsung CF591 Series Curved 27-Inch FHD Monitor</a></h6>
                                        <div class=""product_price"">$610.00</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 3 -->

       ");
            WriteLiteral(@"                 <div class=""owl-item product_slider_item"">
                            <div class=""product-item women"">
                                <div class=""product"">
                                    <div class=""product_image"">
                                        <img src=""images/product_3.png"" alt="""">
                                    </div>
                                    <div class=""favorite""></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">Blue Yeti USB Microphone Blackout Edition</a></h6>
                                        <div class=""product_price"">$120.00</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 4 -->

                        <div class=""owl-item product_slider_item"">
                            <div class=");
            WriteLiteral(@"""product-item accessories"">
                                <div class=""product"">
                                    <div class=""product_image"">
                                        <img src=""images/product_4.png"" alt="""">
                                    </div>
                                    <div class=""product_bubble product_bubble_right product_bubble_red d-flex flex-column align-items-center""><span>sale</span></div>
                                    <div class=""favorite favorite_left""></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">DYMO LabelWriter 450 Turbo Thermal Label Printer</a></h6>
                                        <div class=""product_price"">$410.00</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 5 -->

             ");
            WriteLiteral(@"           <div class=""owl-item product_slider_item"">
                            <div class=""product-item women men"">
                                <div class=""product"">
                                    <div class=""product_image"">
                                        <img src=""images/product_5.png"" alt="""">
                                    </div>
                                    <div class=""favorite""></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">Pryma Headphones, Rose Gold & Grey</a></h6>
                                        <div class=""product_price"">$180.00</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 6 -->

                        <div class=""owl-item product_slider_item"">
                            <div class=""product-");
            WriteLiteral(@"item accessories"">
                                <div class=""product discount"">
                                    <div class=""product_image"">
                                        <img src=""images/product_6.png"" alt="""">
                                    </div>
                                    <div class=""favorite favorite_left""></div>
                                    <div class=""product_bubble product_bubble_right product_bubble_red d-flex flex-column align-items-center""><span>-$20</span></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">Fujifilm X100T 16 MP Digital Camera (Silver)</a></h6>
                                        <div class=""product_price"">$520.00<span>$590.00</span></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 7 -->");
            WriteLiteral(@"

                        <div class=""owl-item product_slider_item"">
                            <div class=""product-item women"">
                                <div class=""product"">
                                    <div class=""product_image"">
                                        <img src=""images/product_7.png"" alt="""">
                                    </div>
                                    <div class=""favorite""></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">Samsung CF591 Series Curved 27-Inch FHD Monitor</a></h6>
                                        <div class=""product_price"">$610.00</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 8 -->

                        <div class=""owl-item product_slider_item"">
                       ");
            WriteLiteral(@"     <div class=""product-item accessories"">
                                <div class=""product"">
                                    <div class=""product_image"">
                                        <img src=""images/product_8.png"" alt="""">
                                    </div>
                                    <div class=""favorite""></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">Blue Yeti USB Microphone Blackout Edition</a></h6>
                                        <div class=""product_price"">$120.00</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 9 -->

                        <div class=""owl-item product_slider_item"">
                            <div class=""product-item men"">
                                <div class=""product"">
  ");
            WriteLiteral(@"                                  <div class=""product_image"">
                                        <img src=""images/product_9.png"" alt="""">
                                    </div>
                                    <div class=""product_bubble product_bubble_right product_bubble_red d-flex flex-column align-items-center""><span>sale</span></div>
                                    <div class=""favorite favorite_left""></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">DYMO LabelWriter 450 Turbo Thermal Label Printer</a></h6>
                                        <div class=""product_price"">$410.00</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Slide 10 -->

                        <div class=""owl-item product_slider_item"">
                            <d");
            WriteLiteral(@"iv class=""product-item men"">
                                <div class=""product"">
                                    <div class=""product_image"">
                                        <img src=""images/product_10.png"" alt="""">
                                    </div>
                                    <div class=""favorite""></div>
                                    <div class=""product_info"">
                                        <h6 class=""product_name""><a href=""single.html"">Pryma Headphones, Rose Gold & Grey</a></h6>
                                        <div class=""product_price"">$180.00</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Slider Navigation -->

                    <div class=""product_slider_nav_left product_slider_nav d-flex align-items-center justify-content-center flex-column"">
                        <i class=");
            WriteLiteral(@"""fa fa-chevron-left"" aria-hidden=""true""></i>
                    </div>
                    <div class=""product_slider_nav_right product_slider_nav d-flex align-items-center justify-content-center flex-column"">
                        <i class=""fa fa-chevron-right"" aria-hidden=""true""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Benefit -->

<div class=""benefit"">
    <div class=""container"">
        <div class=""row benefit_row"">
            <div class=""col-lg-3 benefit_col"">
                <div class=""benefit_item d-flex flex-row align-items-center"">
                    <div class=""benefit_icon""><i class=""fa fa-truck"" aria-hidden=""true""></i></div>
                    <div class=""benefit_content"">
                        <h6>free shipping</h6>
                        <p>Suffered Alteration in Some Form</p>
                    </div>
                </div>
            </div>
            <div class=""col-lg-3 benefit_col"">");
            WriteLiteral(@"
                <div class=""benefit_item d-flex flex-row align-items-center"">
                    <div class=""benefit_icon""><i class=""fa fa-money"" aria-hidden=""true""></i></div>
                    <div class=""benefit_content"">
                        <h6>cach on delivery</h6>
                        <p>The Internet Tend To Repeat</p>
                    </div>
                </div>
            </div>
            <div class=""col-lg-3 benefit_col"">
                <div class=""benefit_item d-flex flex-row align-items-center"">
                    <div class=""benefit_icon""><i class=""fa fa-undo"" aria-hidden=""true""></i></div>
                    <div class=""benefit_content"">
                        <h6>45 days return</h6>
                        <p>Making it Look Like Readable</p>
                    </div>
                </div>
            </div>
            <div class=""col-lg-3 benefit_col"">
                <div class=""benefit_item d-flex flex-row align-items-center"">
                    <di");
            WriteLiteral(@"v class=""benefit_icon""><i class=""fa fa-clock-o"" aria-hidden=""true""></i></div>
                    <div class=""benefit_content"">
                        <h6>opening all week</h6>
                        <p>8AM - 09PM</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Blogs -->

<div class=""blogs"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col text-center"">
                <div class=""section_title"">
                    <h2>Latest Blogs</h2>
                </div>
            </div>
        </div>
        <div class=""row blogs_container"">
            <div class=""col-lg-4 blog_item_col"">
                <div class=""blog_item"">
                    <div class=""blog_background"" style=""background-image:url(images/blog_1.jpg)""></div>
                    <div class=""blog_content d-flex flex-column align-items-center justify-content-center text-center"">
                        <h4 class=""blog_titl");
            WriteLiteral(@"e"">Here are the trends I see coming this fall</h4>
                        <span class=""blog_meta"">by admin | dec 01, 2017</span>
                        <a class=""blog_more"" href=""#"">Read more</a>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 blog_item_col"">
                <div class=""blog_item"">
                    <div class=""blog_background"" style=""background-image:url(images/blog_2.jpg)""></div>
                    <div class=""blog_content d-flex flex-column align-items-center justify-content-center text-center"">
                        <h4 class=""blog_title"">Here are the trends I see coming this fall</h4>
                        <span class=""blog_meta"">by admin | dec 01, 2017</span>
                        <a class=""blog_more"" href=""#"">Read more</a>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 blog_item_col"">
                <div class=""blog_item"">
                    <div c");
            WriteLiteral(@"lass=""blog_background"" style=""background-image:url(images/blog_3.jpg)""></div>
                    <div class=""blog_content d-flex flex-column align-items-center justify-content-center text-center"">
                        <h4 class=""blog_title"">Here are the trends I see coming this fall</h4>
                        <span class=""blog_meta"">by admin | dec 01, 2017</span>
                        <a class=""blog_more"" href=""#"">Read more</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Newsletter -->

<div class=""newsletter"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6"">
                <div class=""newsletter_text d-flex flex-column justify-content-center align-items-lg-start align-items-md-center text-center"">
                    <h4>Newsletter</h4>
                    <p>Subscribe to our newsletter and get 20% off your first purchase</p>
                </div>
            </div>
       ");
            WriteLiteral("     <div class=\"col-lg-6\">\r\n                ");
            EndContext();
            BeginContext(30809, 530, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d01119c43fb4324b948cc913074c787", async() => {
                BeginContext(30829, 503, true);
                WriteLiteral(@"
                    <div class=""newsletter_form d-flex flex-md-row flex-column flex-xs-column align-items-center justify-content-lg-end justify-content-center"">
                        <input id=""newsletter_email"" type=""email"" placeholder=""Your email"" required=""required"" data-error=""Valid email is required."">
                        <button id=""newsletter_submit"" type=""submit"" class=""newsletter_submit_btn trans_300"" value=""Submit"">subscribe</button>
                    </div>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(31339, 56, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
