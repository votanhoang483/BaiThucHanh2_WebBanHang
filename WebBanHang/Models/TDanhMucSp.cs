using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TDanhMucSp
{
    public string MaSp { get; set; } = null!;

    public string? TenSp { get; set; }

    public string? MaChatLieu { get; set; }

    public string? MaHangSx { get; set; }

    public string? MaNuocSx { get; set; }

    public string? Website { get; set; }

    public int? ThoiGianBaoHanh { get; set; }

    public string? GioiThieuSp { get; set; }

    public double? ChietKhau { get; set; }

    public string? MaLoai { get; set; }

    public string? AnhDaiDien { get; set; }

    public double? GiaLonNhat { get; set; }

    public double? GiaNhoNhat { get; set; }

    public string? Model { get; set; }

    public virtual TChatLieu? MaChatLieuNavigation { get; set; }

    public virtual THangSx? MaHangSxNavigation { get; set; }

    public virtual TLoaiSp? MaLoaiNavigation { get; set; }

    public virtual TQuocGium? MaNuocSxNavigation { get; set; }

    public virtual ICollection<TAnhSp> TAnhSps { get; set; } = new List<TAnhSp>();

    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; set; } = new List<TChiTietSanPham>();
}
