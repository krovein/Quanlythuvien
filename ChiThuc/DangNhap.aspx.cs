using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChiThuc
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.Form["email"] != null)
            //{
            //    string email = Request.Form["email"];
            //    string pass = Request.Form["password"];
            //    //List<User> arr = (List<User>)Application["user"];
            //    int kt = kiemtra(email, pass);
            //    if (kt > 0)
            //    {
            //        Response.Redirect("Trangchu.aspx");
            //        Session["login"] = 1;
            //        //Session["name"] = u.name;
            //        //Session["email"] = u.email;
            //    }
            //    else
            //    {
            //        loidangnhap.Text = "Tài khoản hoặc mật khẩu không chính xác.Vui lòng kiểm tra lại email và mật khẩu !";
            //    }

            //}
            

        }

        private int kiemtra(string email, string pass)
        {
            int kiemtra=0;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanSach"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("kt_login", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", email);
                        cmd.Parameters.AddWithValue("@pass", pass);
                        cnn.Open();

                        kiemtra = (int)cmd.ExecuteScalar();
                    }
                }
            }catch(Exception ex)
            {
                loidangnhap.Text = "Tài khoản hoặc mật khẩu không chính xác.Vui lòng kiểm tra lại email và mật khẩu !";
            }
            
            return kiemtra;

        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPass.Text;
            int idKH = kiemtra(username, password);
            if (username != null || password != null)
            {
                if (idKH > 0)
                {
                    Session["login"] = 1;
                    Session["idKH"] = idKH;
                    Session["name"] = username;
                    Response.Redirect("Trangchu.aspx");
                }
                else
                {
                    loidangnhap.Text = "Tài khoản hoặc mật khẩu không chính xác.Vui lòng kiểm tra lại email và mật khẩu !";
                }

            }
            else
            {
                loidangnhap.Text = "Tên đăng nhập và mật khẩu không được để trống!";

            }
        }
    }
}