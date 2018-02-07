<%@ Page Title="" Language="C#" MasterPageFile="~/Eshopper/afterlogin.master" AutoEventWireup="true" CodeFile="auction.aspx.cs" Inherits="Eshopper_auction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:Panel ID="pnl_available" runat="server" Visible="False">
    <section>
		<div class="container">
			<div class="row">
                <div class="col-sm-12 padding-right">
					<div class="features_items">
						<h2 class="title text-center">Products in Auction</h2>
                    <asp:Literal ID="ltr_data" runat="server"></asp:Literal>
					</div>
					
				</div>
            </div>
        </div>
    </section>
        </asp:Panel>
     <asp:Panel ID="pnl_noavailable" runat="server" Visible="False">
        <section>
		<div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 class="title text-center">Products in Auction</h2>
                </div>
            </div>
        <center>
        <h1><u>No Products Available In Auction</u></h1>
        </center>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            </div>
    </section>
        </asp:Panel>
</asp:Content>

