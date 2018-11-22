using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class DsSanPham
    {
        public int masach { get; set; }
    public string tensach { get; set; }
    public string mota { get; set; }
    public string anhbia { get; set; }
    public float giaban { get; set; }
    public DateTime ngayCapNhap { get; set; }
    public int soLuongTon { get; set; }
    public int maChuDe { get; set; }
    public int maNXB { get; set; }
    public DsSanPham()
        {

        }

    public DsSanPham(int masach, string tensach, string mota, string anhbia, float giaban, DateTime ngayCapNhap, int soLuongTon, int maChuDe, int maNXB)
    {
        this.masach = masach;
        this.tensach = tensach;
        this.mota = mota;
        this.anhbia = anhbia;
        this.giaban = giaban;
        this.ngayCapNhap = ngayCapNhap;
        this.soLuongTon = soLuongTon;
        this.maChuDe = maChuDe;
        this.maNXB = maNXB;
    }
}