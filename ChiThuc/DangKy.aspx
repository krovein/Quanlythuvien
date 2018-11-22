<%@ Page Title="Đăng ký" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="ChiThuc.DangKy" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-9">
        <ul class="breadcrumb">
            <li><a href="Trangchu.aspx">Trang chủ</a> <span class="divider"></span></li>
            <li class="active">Đăng ký</li>
        </ul>
        <h3>Đăng ký tài khoản</h3>

        <div class="well">
            <div class="panel-heading">
	               <div class="panel-title text-center">
	               		<h1 class="title">Thông tin đăng ký</h1>
	               		<hr />
	               	</div>
	            </div>
            <div class="main-login main-center">
                <form id="form" class="form-horizontal" method="post" runat="server" onsubmit="return (check())">
                    <p style=" color: red">
                        <asp:Label ID="loi" runat="server"></asp:Label>
                    </p>
                    <div class="form-group">
                        <label for="name" class="cols-sm-2 control-label">Your Name</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="icon-user" aria-hidden="true"></i></span>
                                <input class="inputregister" type="text" id="nameRegister" name="nameRegister" placeholder="Your Name" required="required" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="email" class="cols-sm-2 control-label">Your Email</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="icon-envelope-alt" aria-hidden="true"></i></span>
                                <input  class="inputregister" type="email" id="emailRegister" name="emailRegister" placeholder="Your Email" required="required" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="password" class="cols-sm-2 control-label">Password</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="icon-lock" aria-hidden="true"></i></span>
                                <input  class="inputregister" type="password" id="PasswordRegister" name="PasswordRegister" placeholder="Password" required="required" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="confirm" class="cols-sm-2 control-label">Confirm Password</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="icon-lock" aria-hidden="true"></i></span>
                                <input class="inputregister" type="password" id="RePasswordRegister" name="RePasswordRegister" placeholder="Confirm Password" required="required" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="confirm" class="cols-sm-2 control-label">Ngày sinh</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="icon-calendar" aria-hidden="true"></i></span>
                                <input class="inputregister" type="date" id="dobRegister" name="dobRegister" required="required" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group " style="text-align:center">
                        <asp:Button ID="Button1" runat="server" Text="Đăng ký" OnClick="btndangky_click" CssClass="exclusive shopBtn" />
                        <input type="reset" name="reset" id="reset" value="Đặt lại" class="exclusive shopBtn" />
                    </div>
                   
                </form>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function check() {
            var name = document.getElementById("nameRegister").value;
            var pas = document.getElementById("PasswordRegister");
            var dob = document.getElementById("dobRegister");
            var loi = document.getElementById("MainContent_loi");
            datenow = new Date();
            datedob = new Date(dob.value);
            if (datenow.getTime() < datedob.getTime()) {
                loi.innerText = "Vui lòng nhập đúng ngày sinh.bạn đang nhập ngày sinh lớn hơn ngày hiện tại";
                dob.focus();
                return false;
            }
            if (pas.value.length < 5) {
                loi.innerText = "Mật khẩu phải đủ 5 ký tự trở lên";
                pas.focus();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
