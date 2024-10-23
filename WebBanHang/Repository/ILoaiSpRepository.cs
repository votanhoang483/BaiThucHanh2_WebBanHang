﻿using WebBanHang.Models;
namespace WebBanHang.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(string maloaiSp);
        TLoaiSp GetLoaiSp(string maloaiSp);
        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
