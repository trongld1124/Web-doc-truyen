<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ChuongTruyenDetail.aspx.cs" Inherits="Web_Doc_Truyen.ChuongTruyenDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="height:30px;">

        </div>
        <div class="ct-TenT">
            <asp:Label ID="lbTenT" runat="server" Text=""></asp:Label>
        </div>
        <div class="ct-TenCT">
            <asp:Label ID="lbTenCT" runat="server" Text=""></asp:Label>
        </div>
        <div class="ct-control">
            <asp:Button ID="btnTruoc" runat="server" Text="Chương trước" CssClass="btnControl" OnClick="btnTruoc_Click"/>
            <asp:Button ID="btnSau" runat="server" Text="Chương tiếp" CssClass="btnControl" OnClick="btnSau_Click"/>
        </div>
        <div class="TieuDe">
            NỘI DUNG CHƯƠNG
        </div>
        <div class="List-ND">
            <asp:DataList ID="DLND" runat="server">
                <ItemTemplate>
                    <div style="color: #A7A7A7; font-family: 'Times New Roman'; font-size: 29px; margin-bottom: 5px;">
                        <%#Eval("nd") %>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
