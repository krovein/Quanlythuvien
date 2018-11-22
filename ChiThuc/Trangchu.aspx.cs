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
    public partial class Trangchu : System.Web.UI.Page
    {
        static DataTable tbGioHang = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GioHang"] != null)
                {
                    tbGioHang = Session["GioHang"] as DataTable;
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
                    tbGioHang.Columns.Add("tongTien", typeof(int));
                }
            }
            List<DsSanPham> arr = (List<DsSanPham>)Application["sanpham"];
            List<DsSanPham> arrFeaturedProducts = new List<DsSanPham>();
            List<DsSanPham> arrNewProducts = new List<DsSanPham>();
            foreach (DsSanPham sp in arr)
            {
                int soluong = sp.soLuongTon;
                DateTime ngayCapNhap = sp.ngayCapNhap;
                if (soluong < 50)
                {
                    arrFeaturedProducts.Add(sp);
                }
                if (ngayCapNhap.Month == DateTime.Now.Month && ngayCapNhap.Year == DateTime.Now.Year)
                {
                    arrNewProducts.Add(sp);
                }
            }
            ListViewFeaturedProducts.DataSource = arrFeaturedProducts;
            ListViewFeaturedProducts.DataBind();

            ListViewNewProducts.DataSource = arrNewProducts;
            ListViewNewProducts.DataBind();




        }

        protected void btnthemsanpham_Click(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                int maSach = int.Parse(((Button)sender).CommandArgument.ToString());
                DataTable sachByMaSach = getAllSachByMaSach(maSach);
                
                string tenSach = sachByMaSach.Rows[0]["TenSach"].ToString();
                string hinhAnh = sachByMaSach.Rows[0]["AnhBia"].ToString();
                float giaBan = Convert.ToSingle(sachByMaSach.Rows[0]["GiaBan"].ToString());
                int intSoLuong = 1;

                //Add vao gio hang

                foreach (DataRow row in tbGioHang.Rows)
                {//Kiem tr neu mat hang da co roi thi tang so luong len 1
                    if ((int)row["maSach"] == maSach)
                    {
                        row["soLuong"] = (int)row["SoLuong"] + 1;
                        goto GioHang;
                    }
                }
                tbGioHang.Rows.Add(maSach, tenSach, hinhAnh, giaBan, intSoLuong);
            GioHang:
                Session["GioHang"] = tbGioHang;

                //Response.Write("<script>alert('Đã thêm vào giỏ hàng ^.*!...')</script>");
            }
            
        }

        private DataTable getAllSachByMaSach(int maSach)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuanLyBanSach"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("selectSachByMaSach", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@masach", maSach);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }


        protected void ListViewFeaturedProducts_ItemCommand1(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToLower().Equals("ibtMuaHang"))
                {
                    if (Session["name"] == null)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        int maSach = int.Parse(ListViewFeaturedProducts.DataKeys[e.Item.DisplayIndex].ToString());
                        string tenSach = ((Label)e.Item.FindControl("lbTenSach")).Text;
                        string hinhAnh = ((Image)e.Item.FindControl("img")).ImageUrl;
                        float giaBan = float.Parse(((Label)e.Item.FindControl("lbGiaBan")).Text);
                        int intSoLuong = 1;

                        //Add vao gio hang

                        foreach (DataRow row in tbGioHang.Rows)
                        {//Kiem tr neu mat hang da co roi thi tang so luong len 1
                            if ((int)row["maSach"] == maSach)
                            {
                                row["soLuong"] = (int)row["SoLuong"] + 1;
                                goto GioHang;
                            }
                        }
                        tbGioHang.Rows.Add(maSach, tenSach, hinhAnh, giaBan, intSoLuong);
                    GioHang:
                        Session["GioHang"] = tbGioHang;

                        Response.Write("<script>alert('Đã thêm vào giỏ hàng ^.*!...')</script>");
                    }
                }
            }

            catch (Exception ex)
            {
                String strBuilder = "<script language='javascript'>alert('" + "Hàng hóa đã lên hóa đơn ko thể xóa" + "')</script>";
                Response.Write(strBuilder);
                //throw new Exception("Hàng hóa đã lên hóa đơn ko thể xóa"+ex);
            }

        }
    }


}