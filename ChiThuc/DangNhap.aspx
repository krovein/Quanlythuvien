<%@ Page Title="Đăng nhập" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="ChiThuc.DangNhap" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style6 {
            width: 129px;
        }
        .auto-style8 {
            width: 451px;
        }
        .auto-style15 {
            height: 49px;
        }
        .auto-style16 {
            height: 49px;
            width: 129px;
        }
        .auto-style17 {
            width: 451px;
            height: 49px;
        }
        .auto-style18 {
            height: 49px;
            width: 300px;
        }
        .auto-style19 {
            height: 51px;
        }
        .auto-style20 {
            height: 51px;
            width: 129px;
        }
        .auto-style21 {
            width: 451px;
            height: 51px;
        }
        .auto-style22 {
            height: 51px;
            width: 300px;
        }
        .auto-style26 {
            width: 56px;
        }
        .auto-style27 {
            height: 51px;
            width: 56px;
        }
        .auto-style28 {
            height: 49px;
            width: 177px;
        }
        .auto-style29 {
            height: 51px;
            width: 177px;
        }
        .auto-style30 {
            width: 177px;
        }
        .auto-style31 {
            height: 36px;
        }
    </style>
    <form id="form1" runat="server">
        <div class="col-md-9">
            <ul class="breadcrumb">
                <li><a href="Trangchu.aspx">Trang chủ</a> <span class="divider"></span></li>
                <li class="active">Đăng nhập</li>
            </ul>
            <h3>Đăng nhập</h3>
            <hr />
            <div class="well">
                <div class="panel-heading">
                    <div class="panel-title text-center">
                        <h1 class="title">Thông tin đăng nhập</h1>
                        <hr />
                    </div>
                </div>

                <div class="main-login main-center">
                    <table class="auto-style1">
                        <tr>
                            <td colspan="6" style="text-align: center; vertical-align: top" class="auto-style31">
                                <p style="color: red">
                                    <asp:Label ID="loidangnhap" runat="server"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style28"></td>
                            <td style="text-align: center" class="auto-style16">
                                </td>
                            <td class="auto-style17">
                                <asp:Label ID="Label2" runat="server"  Text="Tên đăng nhập: "></asp:Label>
                            </td>
                            <td class="auto-style18">
                                <asp:TextBox ID="txtUsername" runat="server" Width="275px" Height="29px" ></asp:TextBox>
                            </td>
                            <td class="auto-style26">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="Tên đăng nhập không được để trống">*</asp:RequiredFieldValidator>
             
                            </td>
                            <td class="auto-style15"></td>
                        </tr>
                        <tr>
                            <td class="auto-style29"></td>
                            <td style="text-align: center" class="auto-style20">
                                </td>
                            <td  class="auto-style21">
                                <asp:Label ID="Label3" runat="server" Text="Mật khẩu: "></asp:Label>
                            </td>
                            <td class="auto-style22">
                                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="278px" Height="28px"></asp:TextBox>
                            </td>
                            <td class="auto-style27">
                                <asp:RequiredFieldValidator ID="rfvTenhang" runat="server" 
                        ControlToValidate="txtPass" Display="Dynamic" ErrorMessage="Mật khẩu không được để trống">*</asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style19"></td>
                        </tr>
                        <tr>
                            <td class="auto-style30"></td>
                            <td class="auto-style6"></td>
                            <td class="auto-style8"></td>
                            <td class="modal-sm">
                                <asp:Button ID="btnDangNhap" runat="server" BorderStyle="None" Text="Đăng nhập" Height="35px" Width="98px" class="exclusive shopBtn" OnClick="btnDangNhap_Click" />
                            &nbsp;&nbsp;
                                <asp:Button ID="btnHuy" runat="server" BorderStyle="None" Text="Hủy" Height="35px" Width="98px"   class="exclusive shopBtn"/>
                            </td>
                            <td class="auto-style26"></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style30"></td>
                            <td class="auto-style6"></td>
                            <td style="text-align: center" class="auto-style8">
                                &nbsp;</td>
                            <td class="modal-sm"></td>
                            <td class="auto-style26"></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style30"></td>
                            <td class="auto-style6"></td>
                            <td class="auto-style8">
                                &nbsp;</td>
                            <td class="modal-sm"></td>
                            <td class="auto-style26"></td>
                            <td></td>
                        </tr>
                    </table>
                   
                </div>
            </div>
        </div>
    </form>
</asp:Content>
