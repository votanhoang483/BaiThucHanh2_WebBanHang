﻿using System;
using System.Collections.Generic;

namespace WebBanHang.Models;

public partial class TUser
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? LoaiUser { get; set; }

    public virtual ICollection<TKhachHang> TKhachHangs { get; set; } = new List<TKhachHang>();

    public virtual ICollection<TNhanVien> TNhanViens { get; set; } = new List<TNhanVien>();
}
