using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChiThuc.App_Code
{
    public class GioHang
    {
        public int maSach { get; set; }
        public string tenSach { get; set; }
        public string hinhAnh { get; set; }
        public double donGia { get; set; }
        public int soLuong { get; set; }
        public double ThanhTien
        {
            get { return soLuong * donGia; }
        }

        public GioHang()
        {
           

        }
        //Hàm tạo giỏ hàng
        public GioHang(int maSach)
        {
            this.maSach = maSach;

        }



  

    }
}