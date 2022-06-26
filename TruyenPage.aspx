<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="TruyenPage.aspx.cs" Inherits="Web_Doc_Truyen.TruyenPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="HomePage">
        <div class="TieuDe">
            <asp:Label ID="lbTieuDe" runat="server" Text="Truyên"></asp:Label>
        </div>
        <div class="DSTuyen">
            <asp:DataList ID="DLT" runat="server">
                <ItemTemplate>
                    <div class="DLT-it">
                        <div style="height: 100%; display: flex; align-items: center; justify-content: center; width: 200px;">
                            <img src="<%#Eval("HinhAnh") %>"  style="width: 180px; height: 80px; object-fit: cover; object-position: 100% 40%;"/>
                        </div>
                        <div class="DLT-it-c2">
                            <div class="DLT-c2-c">
                                <a href="TruyenDetail.aspx?ID=<%#Eval("MaT") %>" style="text-decoration: none; color: #A9A9A9; font-size: 19px;">
                                    <i class="fa-solid fa-book marginr"></i>
                                    <%#Eval("TenT") %>
                                </a>
                            </div>
                            <div class="DLT-c2-c">
                                <i class="fa-solid fa-pen marginr"></i>
                                <%#Eval("TenTG") %>
                            </div>
                        </div>
                        <a href="TruyenDetail.aspx?ID=<%#Eval("MaT") %>" style="text-decoration: none;">
                            <div style="height: 100%; display: flex; align-items: center; justify-content: center; width: 200px; color: #92BB35; font-family: Arial;">
                                <%#Eval("soCT") %> CHƯƠNG
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
