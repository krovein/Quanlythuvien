using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChiThuc
{
    public partial class SanPham : System.Web.UI.Page
    {
        public SanPham()
        {
            if (sanpham == null || sanpham.Count == 0)
            {
                sanpham = (List<DsSanPham>)Application["sanpham"];
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != null)
            {
                string type = Request.QueryString["type"];
                if (type == "1") { titleproducts.Text = "SÁCH KHOA HỌC"; }
                else if (type == "2") { titleproducts.Text = "SÁCH KINH TẾ"; }
                else if (type == "3") { titleproducts.Text = "SÁCH THIẾU NHI"; }
                else if (type == "4") { titleproducts.Text = "SÁCH GIÁO KHOA - GIÁO TRÌNH"; }
                else if (type == "5") { titleproducts.Text = "TẠP CHÍ - VĂN PHÒNG PHẨM"; }
                else { titleproducts.Text = "SÁCH VĂN HỌC"; }

                List<DsSanPham> arr = (List<DsSanPham>)Application["sanpham"];
                List<DsSanPham> arrtype = new List<DsSanPham>();
                foreach (DsSanPham sp in arr)
                {
                    if (sp.maChuDe.ToString() == type) { arrtype.Add(sp); }
                }
                ListViewProducts.DataSource = arrtype;
                ListViewProducts.DataBind();
            }
            else
            {
                if (Request.QueryString["search"] == null)
                {
                    titleproducts.Text = "Danh sách tất cả sách";
                    List<DsSanPham> arr = (List<DsSanPham>)Application["sanpham"];
                    ListViewProducts.DataSource = arr;
                    ListViewProducts.DataBind();
                }
                else
                {
                    string search = Request.QueryString["search"];
                    string typesearch = " ";
                    if (search == "Khoa Học") { typesearch = "1"; }
                    else if (search == "Kinh Tế") { typesearch = "2"; }
                    else if (search == "Thiếu Nhi") { typesearch = "3"; }
                    else if (search == "Giáo Khoa" || search == "Giáo Trình") { typesearch = "4"; }
                    else if (search == "Tạp Chí") { typesearch = "5"; }
                    else if (search == "Văn Học") { typesearch = "6"; }
                    else
                    {
                        titleproducts.Text = "Kết quả tìm kiếm";
                        List<DsSanPham> arr = (List<DsSanPham>)Application["sanpham"];
                        List<DsSanPham> arr1 = new List<DsSanPham>();
                        foreach (DsSanPham sp in arr)
                        {
                            string s = sp.tensach.IndexOf(search).ToString();
                            if (s != "-1") { arr1.Add(sp); }
                        }
                        ListViewProducts.DataSource = arr1;
                        ListViewProducts.DataBind();
                        return;
                    }
                    titleproducts.Text = "Kết quả tìm kiếm";
                    List<DsSanPham> arr2 = (List<DsSanPham>)Application["sanpham"];
                    List<DsSanPham> arr3 = new List<DsSanPham>();
                    foreach (DsSanPham sp in arr2) { if (sp.maChuDe.ToString() == typesearch) { arr3.Add(sp); } }
                    ListViewProducts.DataSource = arr3;
                    ListViewProducts.DataBind();
                    return;
                }
            }
        }
        protected void btnthemsanpham_Click(object sender, EventArgs e)
        {

            string id = ((Button)sender).CommandArgument.ToString();

            List<DsSanPham> arr = (List<DsSanPham>)Application["giohang"];
            List<DsSanPham> arrsp = (List<DsSanPham>)Application["sanpham"];
            if (arr == null || arr.Count == 0) { arr = new List<DsSanPham>(); }
            foreach (DsSanPham sp in arrsp) { if (sp.masach.ToString() == id) { arr.Add(sp); break; } }
            Application["giohang"] = arr;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }

        private static List<DsSanPham> giohang;
        private static List<DsSanPham> sanpham;
        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static int InsertToCart(int id)
        {
            if (giohang == null || giohang.Count == 0) giohang = new List<DsSanPham>();
            if (sanpham == null || sanpham.Count == 0) sanpham = new List<DsSanPham>();
            foreach (DsSanPham sp in sanpham)
            {
                if (sp.masach == id) { giohang.Add(sp); break; }
            }
            var tongtien = 0;
            //foreach (DsSanPham sp in giohang)
            //{
            //    tongtien += 
            //}
            return 1;
        }
    }
}