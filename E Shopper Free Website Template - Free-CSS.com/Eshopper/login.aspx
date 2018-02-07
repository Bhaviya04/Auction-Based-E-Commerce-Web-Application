<%@ Page Title="" Language="C#" MasterPageFile="~/Eshopper/Home.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Eshopper_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="form">
    <%--<br /><br />--%>
		<div class="container">
			<div class="row">
				
				<div class="col-sm-4">
					
				</div>
				<div class="col-sm-4">
					<div class="signup-form"><!--sign up form-->
						<h2>Login to your account</h2>
                            <asp:RequiredFieldValidator ID="rqd_email" runat="server" ErrorMessage="Email Required*" ForeColor="Red" ControlToValidate="txt_email" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt_email" placeholder="Email*" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqd_password" runat="server" ErrorMessage="Please Choose Password*" ForeColor="Red" ControlToValidate="txt_password" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt_password" placeholder="Password*" runat="server" TextMode="Password"></asp:TextBox>
                            <br />
                            <asp:Button ID="btn_login" BackColor="#FE980F" ForeColor="#FFFFFF" ValidationGroup="r" runat="server" Text="Login" OnClick="btn_login_Click" />
                            <asp:Label ID="lbl_note" ForeColor="Red" runat="server" Text="Note - '*' indicates madatory fields"></asp:Label>
                            <br /><br />
                            <asp:Label ID="lbl_nomatch" ForeColor="Red" runat="server" Text="Email and Password does not match" Visible="false"></asp:Label>
					</div><!--/sign up form-->
				</div>

                <div class="col-sm-4">
					
				</div>

			</div>
		</div>
	<%--<br /><br />--%>
        </section>
</asp:Content>

