<%@ Page Title="Thông tin sản phẩm" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ThongTinSanPham.aspx.cs" Inherits="ChiThuc.ThongTinSanPham" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-9">
        <ul class="breadcrumb">
            <li><a href="Trangchu.aspx">Trang chủ</a> <span class="divider"></span></li>
            <li><a href="SanPham.aspx">Sản phẩm</a> <span class="divider"></span></li>
            <li class="active">Chi tiết sản phẩm</li>
        </ul>
        <div class="well well-small">
            <div class="row">
                <div class="col-md-5">
                    <div>
                        <asp:Image ID="Image1" CssClass="" runat="server" />
                    </div>
                </div>
                <div class="col-md-7">

                    <hr style="margin: 10px 0" />
                    <label class="control-label" style="font-size: 23px">
                        <asp:Label ID="name" runat="server" Text="Label"></asp:Label></label>
                    <form class="form-horizontal qtyFrm" runat="server">
                        <div class="control-group">
                            <label class="control-label">
                                <asp:Label ID="price" runat="server" Text="Label" ForeColor="Red"></asp:Label></label>
                        </div>
                        <h4>Trạng thái: Còn hàng</h4>
                        <p>
                            <a href="#productDetail">Mô tả</a>
                        </p>
                        <asp:Button runat="server" CommandArgument="" CssClass="shopBtn" OnClick="btnthemsanpham_Click" Text="Thêm vào giỏ hàng" ID="ibtMuaHang" CommandName="ibtMuaHang" />
                    </form>
                </div>
            </div>
            <hr class="softn clr" />


            <ul id="productDetail" class="nav nav-tabs">
                <li class="active"><a href="#home" data-toggle="tab">Mô tả sản phẩm</a></li>
            </ul>
            <div id="myTabContent" class="tab-content tabWrapper">
                <div class="tab-pane fade active in" id="home">
                    <h4>Mô tả:</h4>
                    <table class="table table-striped">
                        <asp:Label ID="details" runat="server" Text="Label"></asp:Label>
                    </table>

                </div>

            </div>

        </div>
    </div>
</asp:Content>
