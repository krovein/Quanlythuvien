using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ChiThuc
{
    public partial class Master : System.Web.UI.MasterPage
    {
        static DataTable tbGioHang = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            float totalprice = 0;
            
                if (Session["GioHang"] != null)
                {
                    tbGioHang = Session["GioHang"] as DataTable;
                    foreach (DataRow row in tbGioHang.Rows)
                    {
                        totalprice += Convert.ToSingle((Convert.ToSingle(row["donGia"].ToString()) * Convert.ToInt32(row["soLuong"].ToString())));
                    }
                    
                }
                else
                {

                    tbGioHang.Rows.Clear();
                    tbGioHang.Columns.Clear();
                    tbGioHang.Columns.Add("maSach", typeof(int));
                    tbGioHang.Columns.Add("tenSach", typeof(string));
                    tbGioHang.Columns.Add("hinhAnh", typeof(string));
                    tbGioHang.Columns.Add("donGia", typeof(float));
                    tbGioHang.Columns.Add("soLuong", typeof(int));
                   
                }
            TotalPrice.Text = totalprice.ToString();

            if (Session["login"].ToString() == "1")
            {
                loregisterlogin.InnerHtml = "<div class=\"userinfo pull-right row\">" +
                    "<a href=\"ThongTinCaNhan.aspx\"><i class=\"icon-user\" aria-hidden=\"true\"></i>" + Session["name"].ToString() + "</a>" +
                    "<span>|</span> <a href=\"DangXuat.aspx\" >Đăng xuất</a></div>";
                Session["url"] = Page.Request.Url.ToString();

            }
            else
            {
                loregisterlogin.InnerHtml = "<a href=\"DangNhap.aspx\" style=\"font-size: 15px\">Đăng nhập</a><span>|</span>" +
                           "<a href=\"DangKy.aspx\" style=\"font-size: 15px\">Đăng ký</a> ";

            }

            hienChuDe();
        }

        private void hienChuDe()
        {
            using (DataTable dt = getChuDe())
            {
                rptChuDe.DataSource = dt;
                rptChuDe.DataBind();
            }
        }

        private DataTable getChuDe()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanSach"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("selectAllChuDe", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private DataTable getAllSachByChuDe(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanSach"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("selectSachByChuDe", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@chude", id);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected void rptChuDe_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int soLuongTon = 0;
            int idChuDe = Convert.ToInt32(
            DataBinder.Eval(e.Item.DataItem, "MaChuDe"));

            Literal ltr = (Literal)e.Item.FindControl("ltrSoluong");
            if (ltr != null)
            {
                using (DataTable getSachByChuDe = getAllSachByChuDe(idChuDe))
                {
                    if (getSachByChuDe != null)
                    {
                        foreach (DataRow row in getSachByChuDe.Rows)
                        {
                            int soluong = Convert.ToInt32(row["SoLuongTon"].ToString());
                            soLuongTon = soLuongTon + soluong;
                        }

                    }
                }
                ltr.Text = "( " + soLuongTon.ToString() + ")";
            }
        }
    }
}