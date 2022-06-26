<%@ Page Title="" Language="C#" MasterPageFile="~/LoginSite.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Web_Doc_Truyen.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="LoginPage">
        <div class="Login-contairner">
            <div class="TieuDe">
                Admin Login
            </div>
            <div class="ip-contairner">
                <div>
                    <input type="text" runat="server" id="txtUsername" placeholder="Your username..."  class="ip-login"/>
                </div>
                <div>
                    <input type="password" runat="server" id="txtPassword" placeholder="Your password..."  class="ip-login"/>
                </div>
            </div>
            <div class="btn-contairner">
                <asp:Button ID="tbnLogin" runat="server" Text="Login" CssClass="btnLogin" OnClick="tbnLogin_Click"/>
            </div>
            <div class="lb-contairner">
                <asp:Label ID="lbTB" runat="server" Text="" CssClass="lbTB"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
