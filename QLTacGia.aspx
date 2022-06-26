<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="QLTacGia.aspx.cs" Inherits="Web_Doc_Truyen.QLTacGia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="Title-QL">
            <h1>Quản Lý Tác Giả</h1>
        </div>
        <div class="contairner-QL">
            <div class="Input-Contairner-QL">
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label1" runat="server" Text="Mã TG: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtMaTG" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label2" runat="server" Text="Tên TG: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtTenTG" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <asp:Label ID="lbThongBao" runat="server" CssClass="lbTB-QL"></asp:Label>
                <div class="Input-Contairner-QL-Item" style="display: flex; justify-content: space-around; height: 70px;">
                    <asp:Button ID="Button2" runat="server" CssClass="btnIp" Text="Thêm TG" OnClick="Button2_Click" />
                    <asp:Button ID="Button3" runat="server" CssClass="btnIp" Text="Sửa TG" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" CssClass="btnIp" Text="Xóa TG" OnClick="Button4_Click" />
                    <asp:Button ID="Button1" runat="server" CssClass="btnIp" Text="Làm Tươi" OnClick="Button1_Click"/>
                </div>
            </div>
            <div class="Tbl-Contairner-QL">
                <div class="row-TG">
                    <div class="MaTG-Collumm">
                        Mã TG
                    </div>
                    <div class="TenTG-Collumm">
                        Tên TG
                    </div>
                </div>
                <asp:DataList ID="DLTacGia" runat="server">
                    <ItemTemplate>
                        <div class="row-TG" style="background: white;">
                            <div class="MaTG-Collumm">
                                <asp:LinkButton ID="btnDL" runat="server" CommandArgument='<%# Eval("MaTG") %>' OnClick="btnDoDL_Click">
                                    <i class="fas fa-arrow-left" style="cursor: pointer;padding: 2px 4.5px;border: 1px solid black; border-radius: 50%;"></i>
                                </asp:LinkButton>
                                <%#Eval("MaTG") %>
                            </div>
                            <div class="TenTG-Collumm">
                                <%#Eval("TenTG") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
