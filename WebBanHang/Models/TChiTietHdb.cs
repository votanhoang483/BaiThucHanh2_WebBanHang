﻿using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TChiTietHdb
{
    public string MaHoaDon { get; set; } = null!;

    public string MaChiTietSp { get; set; } = null!;

    public int? SoLuongBan { get; set; }

    public double? DonGiaBan { get; set; }

    public double? GiamGia { get; set; }

    public string? GhiChu { get; set; }

    public virtual TChiTietSanPham MaChiTietSpNavigation { get; set; } = null!;

    public virtual THoaDonBan MaHoaDonNavigation { get; set; } = null!;
}
