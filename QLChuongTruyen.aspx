<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="QLChuongTruyen.aspx.cs" Inherits="Web_Doc_Truyen.QLChuongTruyen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="Title-QL">
            <h1>Quản Lý Chương Truyện</h1>
        </div>
        <div class="contairner-QL">
            <div class="Input-Contairner-QL">
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label1" runat="server" Text="Mã CT: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtMaCT" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label2" runat="server" Text="Tên CT: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtTenCT" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label3" runat="server" Text="Mã T: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtMaT" runat="server" CssClass="ip-MaT" autocomplete="off"></asp:TextBox>
                    <asp:Button ID="Button5" runat="server" CssClass="btnIp" Text="Kiểm tra" OnClick="Button5_Click" />
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label4" runat="server" Text="Tên T: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtTenT" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label8" runat="server" Text="Nội Dung: " CssClass="lb-QL"></asp:Label>
                    <textarea id="txtND" cols="28" rows="15" CssClass="ip-QLMT" autocomplete="off" runat="server"></textarea>
                </div>
                <asp:Label ID="lbThongBao" runat="server" CssClass="lbTB-QL"></asp:Label>
                <div class="Input-Contairner-QL-Item" style="display: flex; justify-content: space-around; height: 70px;">
                    <asp:Button ID="Button2" runat="server" CssClass="btnIp" Text="Thêm CT" OnClick="Button2_Click" />
                    <asp:Button ID="Button3" runat="server" CssClass="btnIp" Text="Sửa CT" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" CssClass="btnIp" Text="Xóa CT" OnClick="Button4_Click" />
                    <asp:Button ID="Button1" runat="server" CssClass="btnIp" Text="Làm Tươi" OnClick="Button1_Click" />
                </div>
            </div>
            <div class="Tbl-Contairner-QL">
                <div class="row-tbl">
                    <div class="type-collumm1">
                        Mã CT
                    </div>
                    <div class="type-collumm2">
                        Tên CT
                    </div>
                    <div class="type-collumm1">
                        Mã T
                    </div>
                    <div class="type-collumm2">
                        TênT
                    </div>
                    <div class="NDCT">
                        Mô Tả
                    </div>
                </div>
                <asp:DataList ID="DLChuongTruyen" runat="server">
                    <ItemTemplate>
                        <div class="row-tbl" style="background: white; height: 50px;">
                            <div class="type-collumm1 newheight">
                                <asp:LinkButton ID="btnDL" runat="server" CommandArgument='<%# Eval("MaCT") %>' OnClick="btnDoDL_Click">
                                    <i class="fas fa-arrow-left" style="cursor: pointer;padding: 2px 4.5px;border: 1px solid black; border-radius: 50%;"></i>
                                </asp:LinkButton>
                                <%#Eval("MaCT") %>
                            </div>
                            <div class="type-collumm2 newheight">
                                <%#Eval("TenCT") %>
                            </div>
                            <div class="type-collumm1 newheight">
                                <%#Eval("MaT") %>
                            </div>
                            <div class="type-collumm2 newheight">
                                <%#Eval("TenT") %>
                            </div>
                            <div class="NDCT newheight">
                                <%#Eval("NoiDung") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
