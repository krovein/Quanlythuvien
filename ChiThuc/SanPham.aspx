<%@ Page Title="Sản phẩm" Language="C#" EnableEventValidation="false" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="ChiThuc.SanPham" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-9">
        <ul class="breadcrumb">
            <li><a href="Trangchu.aspx">Trang chủ</a> <span class="divider"></span></li>
            <li class="active">Sản phẩm</li>
        </ul>
        <div class="well well-small">
            <h3>
                <asp:Label ID="titleproducts" runat="server" Text="Label"></asp:Label></h3>
            <div class="row">

                <form id="formproducts" runat="server">
                    <asp:ListView ID="ListViewProducts" runat="server">
                        <ItemTemplate>
                            <div class="col-md-3 col-sm-4 col-xs-6" style="padding-left: 3px; padding-right: 3px; margin-top: 5px">
                                <div class="thumbnail" style="margin-bottom: 0">
                                    <a href="product_details.html" class="overlay"></a>
                                    <a class="zoomTool" href="ThongTinSanPham.aspx?id=<%# Eval("masach") %>" title="Chi tiết sản phẩm"><span class="icon-search"></span>Chi tiết</a>
                                    <a href="ThongTinSanPham.aspx?id=<%# Eval("masach") %>">
                                        <img src="<%# Eval("anhbia") %>" alt="" style="margin-top: 5px" />
                                    </a>
                                    <div class="caption cntr">
                                        <p><%# Eval("tensach") %></p>
                                        <p><strong><%# Eval("giaban") %>đ</strong></p>
                                        <asp:Button runat="server" CommandArgument='<%# Eval("masach") %>' CssClass="shopBtn" OnClick="btnthemsanpham_Click" Text="Thêm vào giỏ hàng" ID="ibtMuaHang" CommandName="ibtMuaHang" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </form>

            </div>
        </div>
    </div>
</asp:Content>
