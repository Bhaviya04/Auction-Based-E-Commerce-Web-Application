<%@ Page Title="" Language="C#" MasterPageFile="~/Eshopper/afterlogin.master" AutoEventWireup="true" CodeFile="postproduct.aspx.cs" Inherits="Eshopper_postproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section>
		<div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h2 class="title text-center">Post a Product</h2>
                </div>
            </div>
        <asp:Panel ID="pnl_post" Visible="false" runat="server">
            <div class="signup-form">
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-2">
					PRODUCT NAME
				</div>
                <div class="col-sm-4">
                    <asp:TextBox ID="txt_pname" placeholder="Product Name*" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <asp:RequiredFieldValidator ID="rqd_pname" runat="server" ErrorMessage="Product Name Required*" ForeColor="Red" ControlToValidate="txt_pname" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>


                <div class="row">
                    <div class="col-sm-2"></div>
                <div class="col-sm-2">
					PRODUCT BASE PRICE
				</div>
                <div class="col-sm-4">
                    <asp:TextBox ID="txt_price" placeholder="Base Price (In Dollars)" runat="server"></asp:TextBox>
                </div>
                    <div class="col-sm-4">
                        <asp:RegularExpressionValidator ID="reg_price" runat="server" ErrorMessage="Invalid Base Price" ForeColor="Red" ControlToValidate="txt_price" ValidationExpression="\d+" ValidationGroup="r" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rqd_price" runat="server" ErrorMessage="Base Price Required*" ForeColor="Red" ControlToValidate="txt_price" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>    
                    </div>
            </div>


               <div class="row">
                   <div class="col-sm-2"></div>
                <div class="col-sm-2">
					DESCRIPTION
				</div>
                <div class="col-sm-4">
                            <asp:TextBox ID="txt_pdescribe" runat="server" placeholder="Product Description*" TextMode="MultiLine"></asp:TextBox>
                </div>
                   <div class="col-sm-4">
                       <asp:RequiredFieldValidator ID="rqd_pdescribe" runat="server" ErrorMessage="Product Description Required*" ForeColor="Red" ControlToValidate="txt_pdescribe" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                       </div>
            </div>


                <div class="row">
                    <div class="col-sm-2"></div>
                <div class="col-sm-2">
					<br />PRODUCT CATEGORY
				</div>
                <div class="col-sm-4">
                    <br />
                            <asp:DropDownList ID="drp_pcategory" placeholder="Product Category*" runat="server"></asp:DropDownList>                        
                </div>
                    <div class="col-sm-4">
                        <br />
                    <asp:RequiredFieldValidator ID="rqd_pcategory" runat="server" ErrorMessage="Product Category Required*" ForeColor="Red" ControlToValidate="drp_pcategory" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
            </div>


                <div class="row">
                    <div class="col-sm-2"></div>
                <div class="col-sm-2">
					<br/>IMAGE UPLOAD 1
				</div>
                <div class="col-sm-4">
                    <br /><asp:FileUpload ID="img1" runat="server" />
                </div>
                    <div class="col-sm-4">
                        <br />
                    <asp:RegularExpressionValidator ID="reg_img1" runat="server" ErrorMessage="Upload Only PNG or JPEG files" ForeColor="Red" ControlToValidate="img1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$" ValidationGroup="r" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rqd_img1" runat="server" ErrorMessage="Image 1 Required*" ForeColor="Red" ControlToValidate="img1" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
            </div>

                 <div class="row">
                    <div class="col-sm-2"></div>
                <div class="col-sm-2">
					IMAGE UPLOAD 2
				</div>
                <div class="col-sm-4">
                    <asp:FileUpload ID="img2" runat="server" />
                </div>
                    <div class="col-sm-4">
                    <asp:RegularExpressionValidator ID="reg_img2" runat="server" ErrorMessage="Upload Only PNG or JPEG files" ForeColor="Red" ControlToValidate="img2" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$" ValidationGroup="r" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rqd_img2" runat="server" ErrorMessage="Image 2 Required*" ForeColor="Red" ControlToValidate="img2" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
            </div>

                <div class="row">
                    <div class="col-sm-2"></div>
                <div class="col-sm-2">
					IMAGE UPLOAD 3
				</div>
                <div class="col-sm-4">
                    <asp:FileUpload ID="img3" runat="server" />
                </div>
                    <div class="col-sm-4">
                    <asp:RegularExpressionValidator ID="reg_img3" runat="server" ErrorMessage="Upload Only PNG or JPEG files" ForeColor="Red" ControlToValidate="img3" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$" ValidationGroup="r" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rqd_img3" runat="server" ErrorMessage="Image 3 Required*" ForeColor="Red" ControlToValidate="img3" ValidationGroup="r" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
            </div>

                <div class="row">
                    <div class="col-sm-2"></div>
                <div class="col-sm-2">
				</div>
                <div class="col-sm-4">
                    <br /><asp:Button ID="btn_post" BackColor="#FE980F" ForeColor="#FFFFFF" ValidationGroup="r" runat="server" Text="Post" OnClick="btn_post_Click" />
                </div>
                    <div class="col-sm-4">
                        </div>
            </div>

                <div class="row">
                    <div class="col-sm-2"></div>
                <div class="col-sm-2">
				</div>
                <div class="col-sm-4">
                    <asp:Label ID="Label2" ForeColor="Red" runat="server" Text="Note - '*' indicates madatory fields"></asp:Label>
                </div>
                    <div class="col-sm-4">
                        </div>
            </div>

            </div>
			</asp:Panel>
            <asp:Panel ID="pnl_posted" runat="server" Visible="False">
        <center>
        <h1><u>Product Posted Successfully !!!</u></h1>
        <h3><a href="postproduct.aspx">Click Here</a> To Post More Products</h3>
        </center>
        </asp:Panel>
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        </div>
    </section>
    <br /><br />
</asp:Content>

