<%@ Page Title="" Language="C#" MasterPageFile="~/Eshopper/afterlogin.master" AutoEventWireup="true" CodeFile="productdetails.aspx.cs" Inherits="Eshopper_productdetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager> 
    
    <section>
		<div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 class="title text-center">Product Details</h2>
                </div>
            </div>

            <asp:Panel ID="pnl_beforebuy" Visible="false" runat="server">
			<div class="row">
    <div class="col-sm-2"></div>
    <div class="col-sm-9 padding-right">
					<div class="product-details">
                         <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                        <asp:Literal ID="ltr_data1" runat="server"></asp:Literal>
                        <asp:ImageButton ID="img_main" runat="server" alt="" width='260px' height='380px'  />
                        <asp:Literal ID="ltr_data2" runat="server"></asp:Literal>
                        <asp:ImageButton ID="img1" runat="server" alt="" width='84px' height='84px'  OnClick="img1_Click" />
                        <asp:ImageButton ID="img2" runat="server" alt="" width='84px' height='84px'  OnClick="img2_Click" />
                        <asp:ImageButton ID="img3" runat="server" alt="" width='84px' height='84px'  OnClick="img3_Click" />
					    <asp:Literal ID="ltr_data3" runat="server"></asp:Literal>
                            <span>
                                <span><b><center><font size="12"><font color="orange">US $<asp:Label id="lbl_baseprice" runat="server"></asp:Label></font color></font size></center></b></span>
                            </span>
                        <asp:Literal ID="ltr_data4" runat="server"></asp:Literal>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_buy" class="btn btn-fefault cart" runat="server" Text="Buy" OnClick="btn_buy_Click" />
                        <asp:Panel ID="pnl_auction" Visible="false" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                &nbsp;&nbsp;&nbsp;&nbsp;Time Remaining : <asp:Label ID="lblTime" runat="server" ForeColor="Red"></asp:Label>
                                <asp:Timer ID="timer_auction" OnTick="GetTime" Interval="1000" runat="server"></asp:Timer>
                        </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_highestbidder" runat="server" Text="You are the Highest Bidder" Visible="False" ForeColor="#990033"></asp:Label>
                                <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_bid" placeholder="Bid Price" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqd_bid" runat="server" ErrorMessage="Please set the bid price*" ForeColor="Red" ControlToValidate="txt_bid" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rng_bid" runat="server" ErrorMessage="Should be greater than base price" ForeColor="Red" ControlToValidate="txt_bid" ValidationGroup="r" Display="Dynamic" Type="Integer" MaximumValue="1000000" MinimumValue="0"></asp:RangeValidator>
                                <br /><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_bid" class="btn btn-fefault cart" ValidationGroup="r" runat="server" Text="Bid" OnClick="btn_bid_Click" />
                            </asp:Panel>    
                            </div>
				</div>
    <div class="col-sm-1"></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnl_afterbuy" Visible="false" runat="server">
        <center>
        <h1><u><font color="orange">Congratulations....Product Purchased Successfully !!!</font color></u></h1>
        <h3>Your details are shared to the seller who posted the product and will contact you for the further transaction.</h3>
        </center>
        </asp:Panel>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            </div>
        </section>
</asp:Content>

