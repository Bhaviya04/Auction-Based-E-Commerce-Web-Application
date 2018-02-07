<%@ Page Title="" Language="C#" MasterPageFile="~/Eshopper/afterlogin.master" AutoEventWireup="true" CodeFile="messages.aspx.cs" Inherits="Eshopper_messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
		<div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 class="title text-center">Messages - Buyer Details</h2>
                </div>
            </div>
            </div>
        </section>
    <asp:Panel ID="pnl_msg" runat="server" Visible="False">
    <section id="cart_items">
		<div class="container">
			<div class="table-responsive cart_info">
				<table class="table table-condensed">
					<thead>
						<tr class="cart_menu">
							<td class="image">Product</td>
							<td class="description"></td>
							<td class="price">Buyer Name</td>
							<td class="quantity">Buyer Email</td>
							<td class="total">Buyer Mobile</td>
							<td></td>
						</tr>
					</thead>
					<tbody>
						<asp:Literal ID="ltr_msg" runat="server"></asp:Literal>
					</tbody>
				</table>
			</div>
			
		</div>
	</section>
        </asp:Panel>
    <asp:Panel ID="pnl_nomsg" runat="server" Visible="False">
        <section>
		<div class="container">
        <center>
        <h1><u>No Messages</u></h1>
        </center>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            </div>
    </section>
        </asp:Panel>
</asp:Content>

