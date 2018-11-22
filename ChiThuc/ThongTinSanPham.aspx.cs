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
    public partial class ThongTinSanPham : System.Web.UI.Page
    {
        static DataTable tbGioHang = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Trangchu.aspx",true);
               
            }
            else
            {
                List<DsSanPham> arr = (List<DsSanPham>)Application["sanpham"];
                foreach (DsSanPham sp in arr)
                {
                    if (sp.masach.ToString() == Request.QueryString["id"])
                    {
                        name.Text = sp.tensach;
                        price.Text = "Giá bán:" + sp.giaban.ToString()+"đ";
                        Image1.ImageUrl = sp.anhbia;
                        //btnthem.CommandArgument = sp.masach.ToString();
                        details.Text = sp.mota;
                    }
                }

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

                }

            }
            
        }

        protected void btnthemsanpham_Click(object sender, EventArgs e)
        {

            if (Session["name"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                int maSach = Convert.ToInt32(Request.QueryString["id"]);
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
        }
    }