<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="QLTruyen.aspx.cs" Inherits="Web_Doc_Truyen.QLTruyen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="Title-QL">
            <h1>Quản Lý Truyện</h1>
        </div>
        <div class="contairner-QL">
            <div class="Input-Contairner-QL">
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label1" runat="server" Text="Mã T: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtMaT" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label2" runat="server" Text="Tên T: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtTenT" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label3" runat="server" Text="Danh Mục: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtMaDM" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label4" runat="server" Text="Thể Loại: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtMaTL" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label5" runat="server" Text="Mã TG: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtMaTG" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label6" runat="server" Text="Nguồn: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtNguon" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label7" runat="server" Text="Ảnh MH: " CssClass="lb-QL" ></asp:Label>
                    <asp:FileUpload ID="ful" runat="server" accept=".png,.jpg,.jpeg,.gif" CssClass="ful-Ip"/>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label8" runat="server" Text="Mô tả: " CssClass="lb-QL"></asp:Label>
                    <textarea id="txtMoTa" cols="28" rows="5" CssClass="ip-QLMT" autocomplete="off" runat="server"></textarea>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label9" runat="server" Text="Trạng Thái: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtTT" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <asp:Label ID="lbThongBao" runat="server" CssClass="lbTB-QL"></asp:Label>
                <div class="Input-Contairner-QL-Item" style="display: flex; justify-content: space-around; height: 70px;">
                    <asp:Button ID="Button2" runat="server" CssClass="btnIp" Text="Thêm SP" OnClick="Button2_Click"/>
                    <asp:Button ID="Button3" runat="server" CssClass="btnIp" Text="Sửa SP" OnClick="Button3_Click"/>
                    <asp:Button ID="Button4" runat="server" CssClass="btnIp" Text="Xóa SP" OnClick="Button4_Click"/>
                    <asp:Button ID="Button1" runat="server" CssClass="btnIp" Text="Làm Tươi" OnClick="Button1_Click"/>
                </div>
            </div>
            <div class="Tbl-Contairner-QL">
                <div class="row-tbl">
                    <div class="type-collumm1">
                        Mã T
                    </div>
                    <div class="type-collumm2">
                        Tên T
                    </div>
                    <div class="type-collumm1">
                        Danh Mục
                    </div>
                    <div class="type-collumm1">
                        Thể Loại
                    </div>
                    <div class="type-collumm1">
                        Mã TG
                    </div>
                    <div class="type-collumm2">
                        Nguồn
                    </div>
                    <div class="type-collumm4">
                        Ảnh MH
                    </div>
                    <div class="type-collumm5">
                        Mô Tả
                    </div>
                    <div class="type-collumm3">
                        TT
                    </div>
                </div>
                <asp:DataList ID="DLTruyen" runat="server">
                    <ItemTemplate>
                        <div class="row-tbl" style="background: white; height: 50px;">
                            <div class="type-collumm1 newheight">
                                <asp:LinkButton ID="btnDL" runat="server" CommandArgument='<%# Eval("MaT") %>' OnClick="btnDoDL_Click">
                                    <i class="fas fa-arrow-left" style="cursor: pointer;padding: 2px 4.5px;border: 1px solid black; border-radius: 50%;"></i>
                                </asp:LinkButton>
                                <%#Eval("MaT") %>
                            </div>
                            <div class="type-collumm2 newheight">
                                <%#Eval("TenT") %>
                            </div>
                            <div class="type-collumm1 newheight">
                                <%#Eval("TenDM") %>
                            </div>
                            <div class="type-collumm1 newheight">
                                <%#Eval("TenTL") %>
                            </div>
                            <div class="type-collumm1 newheight">
                                <%#Eval("MaTG") %>
                            </div>
                            <div class="type-collumm2 newheight">
                                <%#Eval("Nguon") %>
                            </div>
                            <div class="type-collumm4 newheight">
                                <img src="<%#Eval("HinhAnh") %>" height="45"/>
                            </div>
                            <div class="type-collumm5 newheight">
                                <%#Eval("Mota") %>
                            </div>
                            <div class="type-collumm3 newheight">
                                <%#Eval("TrangThai") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
