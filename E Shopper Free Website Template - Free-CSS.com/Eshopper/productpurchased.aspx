<%@ Page Title="" Language="C#" MasterPageFile="~/Eshopper/afterlogin.master" AutoEventWireup="true" CodeFile="productpurchased.aspx.cs" Inherits="Eshopper_productpurchased" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section>
		<div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 class="title text-center">Products Purchased</h2>
                </div>
            </div>
            </div>
        </section>
    <asp:Panel ID="pnl_purchased" runat="server" Visible="False">
    <section id="cart_items">
		<div class="container">
			<div class="table-responsive cart_info">
				<table class="table table-condensed">
					<thead>
						<tr class="cart_menu">
							<td class="image">Product</td>
							<td class="description"></td>
							<td class="price">Price</td>
							<td class="quantity">Category</td>
							<td class="total">Purchased Date</td>
							<td></td>
						</tr>
					</thead>
					<tbody>
						<asp:Literal ID="ltr_purchased" runat="server"></asp:Literal>
					</tbody>
				</table>
			</div>
			
		</div>
	</section>
        </asp:Panel>
    <asp:Panel ID="pnl_nopurchased" runat="server" Visible="False">
        <section>
		<div class="container">
        <center>
        <h1><u>No Product Purchased</u></h1>
        </center>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            </div>
    </section>
        </asp:Panel>
</asp:Content>

