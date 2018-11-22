using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ChiThuc
{
    public partial class GioHang : System.Web.UI.Page
    {
        static DataTable tbGioHang = new DataTable();
        float tongTienDonHang = 0;
        int hoaDonIDMax;
        protected void Page_Load(object sender, EventArgs e)
        {
            load_data();
            lbTongDonHang.Text = tongTienDonHang.ToString();
        }

        private void load_data()
        {
            if (Session["GioHang"] == null)
            {

            }
            tbGioHang = (DataTable)Session["GioHang"];
            grvGioHang.DataSource = tbGioHang;
            grvGioHang.DataBind();
        }


        protected void btnthanhtoan_Click(object sender, EventArgs e)
        {
            if (tbGioHang == null)
            {
                Response.Write("<script>confirm('Giỏ hàng của bạn không có sản phẩm nào cả!')</script>");
            }
            else
            {
                createDonHang();
                createChiTietHoaDon();
            }
        }

        private void createDonHang()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanSach"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("insertDonHang", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@thanhToan", 0);
                    cmd.Parameters.AddWithValue("@tinhTrang", 0);
                    cmd.Parameters.AddWithValue("@ngayDat", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ngayGiao", DateTime.Now.AddDays(7));
                    cmd.Parameters.AddWithValue("@maKH", Convert.ToInt32(Session["idKH"].ToString()));
                    cmd.Parameters.AddWithValue("@tongTien", tongTienDonHang);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                }
            }

        }

        private void createChiTietHoaDon()
        {
            int hoaDonId = layMaDHMax();
            if (tbGioHang.Rows.Count > 0)
            {
                foreach (DataRow r in tbGioHang.Rows)
                {
                    int ms = int.Parse(r["maSach"].ToString());
                    int SoLuong = int.Parse(r["SoLuong"].ToString());
                    float Gia = float.Parse(r["donGia"].ToString());
                    insertCTHD(hoaDonId, ms, SoLuong, Gia);
                }
            }
            Session["GioHang"] = null;
            Response.Redirect("~/Trangchu.aspx");
        }

        private void insertCTHD(int maDH, int ms, int soluong, float donGia)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanSach"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("createCTDH", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    cmd.Parameters.AddWithValue("@ms", ms);
                    cmd.Parameters.AddWithValue("@soluong", soluong);
                    cmd.Parameters.AddWithValue("@dongia", donGia);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                }
            }
        }

        private int layMaDHMax()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanSach"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("getDonHangByIdMax", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cnn.Open();
                    hoaDonIDMax = Convert.ToInt32(cmd.ExecuteScalar());
                    cnn.Close();

                }
            }
            return hoaDonIDMax;
        }
        public void ThemVaoGioHang(int idSP, string TenSP, int Dongia, int Soluong)
        {
            DataTable dt;
            if (Session["GioHang"] == null)
            {
                dt = new DataTable();
                dt.Columns.Add("maSach");
                dt.Columns.Add("tenSach");
                dt.Columns.Add("donGia");
                dt.Columns.Add("soLuong");
                dt.Columns.Add("tongTien");
            }
            else
                dt = (DataTable)Session["GioHang"];
            int dong = SPdacotronggiohang(idSP, dt);
            if (dong != -1)
            {
                dt.Rows[dong]["SoLuong"] = Convert.ToInt32(dt.Rows[dong]["SoLuong"]) + Soluong;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["idSP"] = idSP;
                dr["tenSach"] = TenSP;
                dr["donGia"] = Dongia;
                dr["soLuong"] = Soluong;
                dr["tongTien"] = Dongia * Soluong;
                dt.Rows.Add(dr);
            }
            Session["GioHang"] = dt;
        }
        public static int SPdacotronggiohang(int maSan, DataTable dt)
        {
            int dong = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["idSP"].ToString()) == maSan)
                {
                    dong = i;
                    break;
                }
            }
            return dong;
        }


        protected void grvGioHang_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("xoa"))
            {
                int maSach = Convert.ToInt32(e.CommandArgument);
                try
                {
                    
                    tbGioHang.Rows.RemoveAt(maSach);
                    Session["GioHang"] = tbGioHang;
                    Response.Redirect("~/GioHang.aspx");

                    //tbGioHang = (DataTable)Session["GioHang"];
                    //grvGioHang.DataSource = tbGioHang;
                    //grvGioHang.DataBind();

                    //Application["giohang"] = arr;
                    //DsGiohang.DataSource = arr;
                    //DsGiohang.DataBind();
                    //TotalProduct.Text = arr.Count.ToString();
                    //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/GioHang.aspx");

                }
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument.ToString();
            DataTable dt = (DataTable)Session["GioHang"];
           
                foreach (DataRow r in tbGioHang.Rows)
                {
                    if (r["maSach"].ToString() == id)
                    {
                    dt.Rows.RemoveAt(Convert.ToInt32(r["maSach"].ToString()));
                        break;

                    }
                }
               
            Session["GioHang"] = dt;
            grvGioHang.DataSource = dt;
            grvGioHang.DataBind();
            //TotalProduct.Text = dt;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void grvGioHang_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                float tongTien = 0;
                int maSach = Convert.ToInt32(
               DataBinder.Eval(e.Row.DataItem, "maSach"));

                Literal ltr = (Literal)e.Row.FindControl("ltrthanhTien");
                if (ltr != null)
                {
                    if (tbGioHang != null)
                    {
                        foreach (DataRow row in tbGioHang.Rows)
                        {
                            if ((int)row["maSach"] == maSach)
                            {
                                tongTien = (Convert.ToSingle(row["donGia"].ToString()) * Convert.ToInt32(row["soLuong"].ToString()));
                            }
                        }

                        ltr.Text = tongTien.ToString();
                        tongTienDonHang = tongTienDonHang + tongTien;
                    }
                }
            }
        }
    }
}