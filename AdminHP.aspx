<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="AdminHP.aspx.cs" Inherits="Web_Doc_Truyen.AdminHP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="HomePage-Ad">
        <div class="overview-HomePage-Ad">
            <div class="overview-It" style="background: #61D270;">
                <i class="fa-solid fa-book" style="margin-right: 10px;"></i>
                <div>
                    <asp:Label ID="lbTongT" runat="server" Text="1" CssClass="Num-Ov"></asp:Label>
                    <p class="Content-Ov">Tổng Truyện</p>
                </div>
            </div>
            <div class="overview-It" style="background: #FBA026;">
                <i class="fa-solid fa-book" style="margin-right: 10px;"></i>
                <div>
                    <asp:Label ID="lbTongCT" runat="server" Text="1" CssClass="Num-Ov" ></asp:Label>
                    <p class="Content-Ov">Tổng Chương Truyện</p>
                </div>
            </div>
            <div class="overview-It" style="background: #E25041;">
                <i class="fas fa-users" style="margin-right: 10px;"></i>
                <div>
                    <asp:Label ID="lbTongTG" runat="server" Text="1" CssClass="Num-Ov" ></asp:Label>
                    <p class="Content-Ov">Tổng Tác Giả</p>
                </div>
            </div>
            <div class="overview-It" style="background: #26B7FB;">
                <i class="fas fa-comment-dots" style="margin-right: 10px;"></i>
                <div>
                    <asp:Label ID="lbTongBL" runat="server" Text="..." CssClass="Num-Ov" ></asp:Label>
                    <p class="Content-Ov">Tổng Bình Luận</p>
                </div>
            </div>
        </div>
        <div class="Contairner-HomePage-Ad">
            <div class="Contairner-HP-Ad-List">
                <div class="Item">
                    <a href="QLTruyen.aspx" class="nav-Item-HP-Ad">
                        <p style="font-size: 20px; font-weight: 600; margin-left: 10px;">Quản lý Truyện</p>
                    </a>
                    <a href="QLChuongTruyen.aspx" class="nav-Item-HP-Ad">
                        <p style="font-size: 20px; font-weight: 600; margin-left: 10px;">Quản lý Chương Truyện</p>
                    </a>
                </div>
                <div class="Item">
                    <a href="QLTacGia.aspx" class="nav-Item-HP-Ad">
                        <p style="font-size: 20px; font-weight: 600; margin-left: 10px;">Quản lý Tác Giả</p>
                    </a>
                    <a href="#" class="nav-Item-HP-Ad">
                        <p style="font-size: 20px; font-weight: 600; margin-left: 10px;">Thông Tin Quản Trị</p>
                    </a>
                </div>
            </div>
            <div class="Web-Infor">
                <p class="Title-Web-Infor">Thông Tin Website</p>
                <p>Thông Tin Hosting: </p>
                <p>Ngày Khởi Tạo Website: 20-5-2022</p>
                <p>Ngày Khởi Chạy Website: 20-5-2022</p>
            </div>
        </div>
    </div>
</asp:Content>
