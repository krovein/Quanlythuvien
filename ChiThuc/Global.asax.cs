using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChiThuc
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Session["giohang"] = new List<GioHang>();
            Application["sanpham"] = new List<DsSanPham>();
            Application["user"] = new List<User>();

            List<DsSanPham> arr = getAllSachs();

            Application["sanpham"] = arr;

            //List<GioHang> giohang = LayGioHang();
            //Session["giohang"] = giohang;


        }
        private List<DsSanPham> getAllSachs()
        {
            List<DsSanPham> sachList = new List<DsSanPham>();
            sachList = (from DataRow row in getAllSach().Rows
                        select new DsSanPham
                        {
                            masach = Convert.ToInt32(row["MaSach"].ToString()),
                            tensach = row["TenSach"].ToString(),
                            mota = row["MoTa"].ToString(),
                            anhbia = row["AnhBia"].ToString(),
                            giaban = Convert.ToSingle(row["GiaBan"].ToString()),
                            ngayCapNhap = Convert.ToDateTime(row["NgayCapNhat"].ToString()),
                            soLuongTon = Convert.ToInt32(row["SoLuongTon"].ToString()),
                            maChuDe = Convert.ToInt32(row["MaChuDe"].ToString()),
                            maNXB = Convert.ToInt32(row["maNXB"].ToString()),

                        }).ToList();
            return sachList;
        }

        private DataTable getAllSach()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanSach"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sachSelectAll", cnn))
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

        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //nếu giỏ hàng hcuwa tồn tại thì mh tiến hành khởi tạo giỏ hàng
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }


        protected void Session_Start(object sender, EventArgs e)
        {
            Session["login"] = 0;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}