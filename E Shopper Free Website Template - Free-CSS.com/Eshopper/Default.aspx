<%@ Page Title="" Language="C#" MasterPageFile="~/Eshopper/Home.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Eshopper_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
	<div class="row">
        <%--<div class="col-sm-2">
            </div>--%>
    <%--<div class="col-sm-10">
    <div id="carousel" class="carousel slide carousel-fade" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carousel" data-slide-to="0" class="active"></li>
            <li data-target="#carousel" data-slide-to="1"></li>
            <li data-target="#carousel" data-slide-to="2"></li>
        </ol>
        <!-- Carousel items -->
        <div class="carousel-inner">
            <div class="active item"><img src="images/auction5.png" alt="banner" /></div>
            <div class="item"><img src="images/auction2.jpg" alt="banner" /></div>
            <div class="item"><img src="images/auction3.jpg" alt="banner" /></div>
        </div>
        
    </div>
    </div>--%>
        <section id="slider"><!--slider-->
		<div class="container">
			<div class="row">
				<div class="col-sm-12">
					<div id="slider-carousel" class="carousel slide" data-ride="carousel">
						<ol class="carousel-indicators">
							<li data-target="#slider-carousel" data-slide-to="0" class="active"></li>
							<li data-target="#slider-carousel" data-slide-to="1"></li>
							<li data-target="#slider-carousel" data-slide-to="2"></li>
						</ol>
						
						<div class="carousel-inner">
							<div class="item active">
								<div class="col-sm-6">
									<h1><span>E</span>-COMMERCE</h1>
									<h2>Auction Based Web Application</h2>
									<p>We were not thinking about numbers then, but we knew something big can be built out of ecommerce.</p>
									<a href="register.aspx" class="btn btn-default get">Buy now</a>
								</div>
								<div class="col-sm-6">
									<img src="images/home/mobile.png" class="girl img-responsive" alt="" />
									<img src="images/home/price-tag-512.png" height="150px" width="150px"  class="pricing" alt="" />
								</div>
							</div>
							<div class="item">
								<div class="col-sm-6">
									<h1><span>E</span>-COMMERCE</h1>
									<h2>Auction Based Web Application</h2>
									<p>In eCommerce, your prices have to be better because the consumer has to take a leap of faith in your product.</p>
									<a href="register.aspx" class="btn btn-default get">Buy now</a>
								</div>
								<div class="col-sm-6">
									<img src="images/home/bag.png" class="girl img-responsive" alt="" />
									<img src="images/home/price-tag-512.png" height="150px" width="150px"  class="pricing" alt="" />
								</div>
							</div>
							
							<div class="item">
								<div class="col-sm-6">
									<h1><span>E</span>-COMMERCE</h1>
									<h2>Auction Based Web Application</h2>
									<p>Thus, in the future, instead of buying bananas in a grocery store, you could go pick them off a tree in a virtual jungle.</p>
									<a href="register.aspx" class="btn btn-default get">Buy now</a>
								</div>
								<div class="col-sm-6">
									<img src="images/home/refrigerator.png" class="girl img-responsive" alt="" />
									<img src="images/home/price-tag-512.png" height="150px" width="150px"  class="pricing" alt="" />
								</div>
							</div>
							
						</div>
						
						<a href="#slider-carousel" class="left control-carousel hidden-xs" data-slide="prev">
							<i class="fa fa-angle-left"></i>
						</a>
						<a href="#slider-carousel" class="right control-carousel hidden-xs" data-slide="next">
							<i class="fa fa-angle-right"></i>
						</a>
					</div>
					
				</div>
			</div>
		</div>
	</section>
        <div class="col-sm-2">
            </div>
    </div>
    </div>
    <br />
    <div class="container">
	<div class="row">
    <div class="col-sm-12">
        
        <h4 style="font-family: 'Trebuchet MS'; text-align: justify;"><b>Auction Based E-Commerce Web Application</b> is an application in which the seller posts the product for sale
         and as soon as it is posted, the auction timer generates under which multiple buyers can bid for that product 
         in order to buy. The buyer who places the highest bid for that product under the auction timer will be able to successfully purchase the product.
         This web application gives the flexibility to both - Buyers and Sellers.</h4> 
        
        </div>
        </div>
        </div>

    <br />

    <center><h3>HOW IT WORKS</h3></center>

    <section>
    <div class="container">
	<div class="row">
    <div class="col-sm-9 padding-right">
        <div class="col-sm-4">
       <img src="images/How_It_Works.png" height="250" width="1200" alt="banner" />
        </div>
        </div>
        </div>
        </div>
    </section>

    <br />
</asp:Content>

