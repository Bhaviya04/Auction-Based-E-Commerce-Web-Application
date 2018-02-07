<%@ Page Title="" Language="C#" MasterPageFile="~/Eshopper/Home.master" AutoEventWireup="true" CodeFile="register_success.aspx.cs" Inherits="Eshopper_register_success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="form">
        <asp:Panel ID="pnl_success" runat="server" Visible="False">
        <center>
        <h1><u>Registration Successful !!!</u></h1>
        <h3><a href="login.aspx">Click Here</a> To Login</h3>
        </center>
        </asp:Panel>

        <asp:Panel ID="pnl_exists" runat="server" Visible="False">
        <center>
        <h1><u>User With Same Email Address Already Exists</u></h1>
        <h3><a href="register.aspx">Click Here</a> To Register With Different Email Address</h3>
        </center>
        </asp:Panel>

        </section>
    <br />
</asp:Content>

