<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="TruyenDetail.aspx.cs" Inherits="Web_Doc_Truyen.TruyenDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="TieuDe">
            THÔNG TIN TRUYỆN
            <i class="fa-solid fa-circle-info marginl"></i>
        </div>
        <div class="Detail">
            <div class="Detail-contairner1">
                <img class="img-D" runat="server" id="imgTruyen" src="a" alt="Hình Ảnh"/>
                <div class="tt-D">
                    <div class="lbtt">
                        <asp:Label ID="lbTacGia" runat="server" Text="a" ></asp:Label>
                    </div>
                    <div class="lbtt">
                        <asp:Label ID="lbTheLoai" runat="server" Text="a" ></asp:Label>
                    </div>
                    <div class="lbtt">
                        <asp:Label ID="lbNguon" runat="server" Text="a" ></asp:Label>
                    </div>
                    <div class="lbtt">
                        <asp:Label ID="lbTrangThai" runat="server" Text="a" ></asp:Label>
                    </div>
                </div>
            </div>
            <div class="Detail-contairner2">
                <div class="Ten-D">
                    <asp:Label ID="lbTenTruyen" runat="server" Text=""></asp:Label>
                </div>
                <div class="Mota-D">
                    <asp:Label ID="lbMota" runat="server" Text="Truyên"></asp:Label>
                </div>
            </div>
        </div>
        <div class="TieuDe">
            DANH SÁCH CHƯƠNG
        </div>
        <div class="DSChuong">
            <asp:DataList ID="DLCT" runat="server" RepeatColumns="2">
                <ItemTemplate>
                    <a href="ChuongTruyenDetail.aspx?ID=<%#Eval("MaCT") %>" style="text-decoration: none;">
                        <div class="ct">
                            <i class="fa-solid fa-star-of-life marginr"></i>
                            Chương <%#Eval("stt") %>: <%#Eval("TenCT") %>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
