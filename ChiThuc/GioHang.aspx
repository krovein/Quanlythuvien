<%@ Page Title="Giỏ hàng" Language="C#" EnableEventValidation="false" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="ChiThuc.GioHang" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-9">
        <ul class="breadcrumb">
            <li><a href="index.html">Trang chủ</a> <span class="divider"></span></li>
            <li class="active">Giỏ hàng</li>
        </ul>
        <div class="well well-small">
            <h1>Giỏ hàng của bạn <small class="pull-right">
                <asp:Label ID="TotalProduct" runat="server" Text="Label"></asp:Label>
                sản phẩm </small></h1>

            <hr class="soften" />
            <form id="formgiohang" runat="server">
                <asp:GridView ID="grvGioHang" runat="server" AutoGenerateColumns="False" CssClass="grv" class="table table-bordered table-condensed" style="width:100%" OnRowCommand="grvGioHang_RowCommand" OnRowDataBound="grvGioHang_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="tenSach" HeaderText="Tên sách" />
                        <asp:TemplateField HeaderText="Ảnh bìa">
                            <ItemTemplate>
                                <img width="100" src="<%# Eval("hinhAnh") %>" alt="">
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mô tả">
                            <ItemTemplate>
                                <a href="ThongTinSanPham.aspx?id=<%# Eval("maSach") %>">Chi tiết</a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="donGia" HeaderText="Giá bán" />
                        <asp:BoundField DataField="soLuong" HeaderText="Số lượng" />
                        
                        <asp:TemplateField HeaderText="Thành tiền">
                            <ItemTemplate>
                                <asp:Literal runat="server" ID="ltrthanhTien" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-mini btn-danger"
                                    CommandName="xoa"
                                    CommandArgument='<%# Eval("maSach") %>'
                                    OnClientClick='return confirm("Có chắc chắn muốn xoá không?");'>Xóa</asp:LinkButton>
                                <%--<asp:Button runat="server" CssClass="btn btn-mini btn-danger" CommandArgument='<%# Eval("maSach") %>' Text="X" OnClick="btnRemove_Click" />--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
                <div class="alignR">
                    Tổng tiền :
                     <asp:Label ID="lbTongDonHang" runat="server" Text="Label"></asp:Label>đ
                </div>

                <br />
                <a href="Trangchu.aspx" class="shopBtn btn-large">Quay lại trang mua sắm </a>
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".bs-example-modal-sm">Small modal</button>

                <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
                    <div class="modal-dialog modal-sm" role="document">
                        <div class="modal-content">
                            <button>x</button>
                        </div>
                    </div>
                </div>
                <asp:Button runat="server" CssClass="shopBtn btn-large pull-right" CommandArgument='<%# Eval("id") %>' Text="Thanh toán" OnClick="btnthanhtoan_Click" />
            </form>
        </div>
    </div>
</asp:Content>

