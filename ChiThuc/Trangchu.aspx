<%@ Page Title="Trang chủ" Language="C#" EnableEventValidation="false" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Trangchu.aspx.cs" Inherits="ChiThuc.Trangchu" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-9">
        <form runat="server">
            <div class="well np">
                <div id="myCarousel" class="carousel slide homBook">
                    <div class="carousel-inner">
                        <div class="item">
                            <img class="img-rounded" style="width: 100%" src="assets/img/banner1.jpg" alt="" />
                        </div>
                        <div class="item">
                            <img class="img-rounded" style="width: 100%" src="assets/img/banner2.jpg" alt="" />
                        </div>
                        <div class="item active">
                            <img class="img-rounded" style="width: 100%" src="assets/img/banner3.jpg" alt="" />
                        </div>
                        <div class="item">
                            <img class="img-rounded" style="width: 100%" src="assets/img/banner4.jpg" alt="" />
                        </div>
                    </div>
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">&lsaquo;</a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">&rsaquo;</a>
                </div>
            </div>
            <!--
New Products
-->
            <div class="well well-small">
                <h3>Sách mới </h3>
                <hr class="soften" />
                <div class="row">
                    <asp:ListView ID="ListViewNewProducts" runat="server" >
                        <ItemTemplate>
                            <div class="col-md-3 col-sm-4 col-xs-6" style="padding-left: 3px; padding-right: 3px">
                                <div class="thumbnail">
                                    <a class="zoomTool" href="ThongTinSanPham.aspx?id=<%# Eval("masach") %>" title="XEM CHI TIẾT"><span class="icon-search"></span>CHI TIẾT</a>
                                    <a href="ThongTinSanPham.aspx?id=<%# Eval("masach") %>">
                                        <img id="imgNew" src="<%# Eval("anhbia") %>" alt=""></a>
                                     <%--<asp:Image ID="img" runat="server" ImageUrl="<%# Eval("anhbia") %>" AlternateText="" />--%>
                                    <div class="caption cntr">
                                        <asp:Label ID="lbTenSachNew" runat="server" ><%# Eval("tensach") %></asp:Label>
                                        <br />
                                        <asp:Label ID="lbGiaBanNew" runat="server"><strong><%# Eval("giaban") %>đ</strong></asp:Label>
                                        <br />
                                        <asp:Button runat="server" CommandArgument='<%# Eval("masach") %>' CssClass="shopBtn" OnClick="btnthemsanpham_Click" Text="Thêm vào giỏ hàng" />

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>



                </div>
            </div>
            <!--
	Featured Products
	-->
            <div class="well well-small">
                <h3><a class="btn btn-info pull-right" href="SanPham.aspx">Xem thêm <span class="icon-plus"></span></a>Sách hay  </h3>
                <hr class="soften" />
                <div class="row">


                    <asp:ListView ID="ListViewFeaturedProducts" runat="server" >
                        <ItemTemplate>
                            <div class="col-md-3 col-sm-4 col-xs-6" style="padding-left: 3px; padding-right: 3px">
                                <div class="thumbnail">
                                    <a class="zoomTool" href="ThongTinSanPham.aspx?id=<%# Eval("masach") %>" title="XEM CHI TIẾT"><span class="icon-search"></span>CHI TIẾT</a>
                                    <a href="ThongTinSanPham.aspx?id=<%# Eval("masach") %>">
                                        <img src="<%# Eval("anhbia") %>" alt=""></a>
                                    <div class="caption cntr">
                                        <asp:Label ID="lbTenSach" runat="server" ><%# Eval("tensach") %></asp:Label>
                                        <br />
                                        <asp:Label ID="lbGiaBan" runat="server"><strong><%# Eval("giaban") %>đ</strong></asp:Label>
                                        <br />
                                        <%--<asp:Button ID="ibtMuaHang" runat="server" CommandArgument='<%# Eval("masach") %>' CommandName="ibtMuaHang" CssClass="shopBtn" Text="Thêm vào giỏ hàng" OnClick="btnthemsanpham_Click"/>--%>
                                        <asp:Button runat="server" CommandArgument='<%# Eval("masach") %>' CssClass="shopBtn" OnClick="btnthemsanpham_Click" Text="Thêm vào giỏ hàng" />


                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>


                </div>
            </div>
            <hr />
            <div class="well well-small">
                <a class="btn btn-info pull-right" href="#">Xem thêm <span class="icon-plus"></span></a>
                Sách nổi bật
            </div>

        </form>
    </div>
</asp:Content>
