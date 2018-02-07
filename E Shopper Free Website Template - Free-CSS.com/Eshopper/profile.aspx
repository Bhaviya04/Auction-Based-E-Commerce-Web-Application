<%@ Page Title="" Language="C#" MasterPageFile="~/Eshopper/afterlogin.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="Eshopper_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
		<div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 class="title text-center">Edit Profile</h2>
                </div>
            </div>
            </div>
        </section>
    <asp:Panel ID="pnl_profileedit" runat="server" Visible="False">
    <section>
		<div class="container">
			<div class="row">
				
				<div class="col-sm-4">
					
				</div>
				<div class="col-sm-4">
					<div class="signup-form">
                            <asp:RequiredFieldValidator ID="rqd_fname" runat="server" ErrorMessage="First Name Required*" ForeColor="Red" ControlToValidate="txt_fname" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt_fname" placeholder="First Name*" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqd_lname" runat="server" ErrorMessage="Last Name Required*" ForeColor="Red" ControlToValidate="txt_lname" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt_lname" placeholder="Last Name*" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqd_email" runat="server" ErrorMessage="Email Required*" ForeColor="Red" ControlToValidate="txt_email" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="reg_email" runat="server" ErrorMessage="Invalid Email Address" ForeColor="Red" ControlToValidate="txt_email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="r" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txt_email" placeholder="Email*" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="reg_phone" runat="server" ErrorMessage="Invalid U.S Number" ForeColor="Red" ControlToValidate="txt_phone" ValidationExpression="\d{10}" ValidationGroup="r" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txt_phone" placeholder="Phone No (U.S No Only) Eg. xxxxxxxxxx" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqd_country" runat="server" ErrorMessage="Country Required*" ForeColor="Red" ControlToValidate="txt_country" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt_country" placeholder="Country*" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqd_state" runat="server" ErrorMessage="State Required*" ForeColor="Red" ControlToValidate="txt_state" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt_state" placeholder="State*" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqd_city" runat="server" ErrorMessage="City Required*" ForeColor="Red" ControlToValidate="txt_city" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt_city" placeholder="City*" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqd_address" runat="server" ErrorMessage="Address Required*" ForeColor="Red" ControlToValidate="txt_address" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt_address" placeholder="Address*" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqd_password" runat="server" ErrorMessage="Please Choose Password*" ForeColor="Red" ControlToValidate="txt_password" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txt_password" ID="reg_password" ForeColor="Red" ValidationExpression = "^[\s\S]{8,16}$" runat="server" ErrorMessage="Minimum 8 and Maximum 16 characters required"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txt_password" placeholder="Password* (Min 8 and Max 16 Characters Required)" runat="server" TextMode="Password"></asp:TextBox>
                            
                            <br />
                            <asp:Button ID="btn_save" BackColor="#FE980F" ForeColor="#FFFFFF" ValidationGroup="r" runat="server" Text="Save" OnClick="btn_save_Click" />
					</div><!--/sign up form-->
				</div>

                <div class="col-sm-4">
					
				</div>

			</div>
		</div>
	<%--<br /><br />--%>
</section>
        </asp:Panel>
    <asp:Panel ID="pnl_profileedited" runat="server" Visible="False">
        <section>
		<div class="container">
        <center>
        <h1><u>Your Profile Is Edited....</u></h1>
        </center>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            </div>
    </section>
        </asp:Panel>
</asp:Content>

