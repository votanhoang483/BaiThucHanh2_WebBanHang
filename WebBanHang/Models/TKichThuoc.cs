using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TKichThuoc
{
    public string MaKichThuoc { get; set; } = null!;

    public int? KichThuoc { get; set; }

    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; set; } = new List<TChiTietSanPham>();
}
