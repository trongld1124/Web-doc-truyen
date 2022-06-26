<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Web_Doc_Truyen.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="HomePage">
        <div class="TieuDe">
            TRUYỆN HOT
            <i class="fa-brands fa-hotjar marginl"></i>
        </div>
        <div class="DSTuyen">
            <asp:DataList ID="DLTH" runat="server" RepeatColumns="5" CssClass="">
                <ItemTemplate>
                    <a href="TruyenDetail.aspx?ID=<%#Eval("MaT") %>">
                        <div class="Truyen-it">
                            <img src="<%#Eval("HinhAnh") %>" style="width: 170px; height: 226px;"/>
                            <p class="tenTruyen"><%#Eval("TenT") %></p>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
