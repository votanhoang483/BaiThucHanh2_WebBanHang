using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanHang.Models;

public partial class QlbanGiayContext : DbContext
{
    public QlbanGiayContext()
    {
    }

    public QlbanGiayContext(DbContextOptions<QlbanGiayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAnhChiTietSp> TAnhChiTietSps { get; set; }

    public virtual DbSet<TAnhSp> TAnhSps { get; set; }

    public virtual DbSet<TChatLieu> TChatLieus { get; set; }

    public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; }

    public virtual DbSet<TChiTietSanPham> TChiTietSanPhams { get; set; }

    public virtual DbSet<TDanhMucSp> TDanhMucSps { get; set; }

    public virtual DbSet<THangSx> THangSxes { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TKichThuoc> TKichThuocs { get; set; }

    public virtual DbSet<TLoaiSp> TLoaiSps { get; set; }

    public virtual DbSet<TMauSac> TMauSacs { get; set; }

    public virtual DbSet<TNhanVien> TNhanViens { get; set; }

    public virtual DbSet<TQuocGium> TQuocGia { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TANHOANG;Initial Catalog=QLBanGiay;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAnhChiTietSp>(entity =>
        {
            entity.HasKey(e => new { e.MaChiTietSp, e.TenFileAnh }).HasName("PK__tAnhChiT__6DFA6335DEC0E794");

            entity.ToTable("tAnhChiTietSP");

            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.TenFileAnh).HasMaxLength(255);
            entity.Property(e => e.ViTri).HasMaxLength(255);

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TAnhChiTietSps)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhChiTietSP_tChiTietSanPham");
        });

        modelBuilder.Entity<TAnhSp>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.TenFileAnh }).HasName("PK__tAnhSP__2FC2FB7E2827B683");

            entity.ToTable("tAnhSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.TenFileAnh).HasMaxLength(255);
            entity.Property(e => e.ViTri).HasMaxLength(255);

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TAnhSps)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhSP_tDanhMucSP");
        });

        modelBuilder.Entity<TChatLieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu).HasName("PK__tChatLie__453995BC6847F4BE");

            entity.ToTable("tChatLieu");

            entity.Property(e => e.MaChatLieu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ChatLieu).HasMaxLength(50);
        });

        modelBuilder.Entity<TChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaChiTietSp }).HasName("PK__tChiTiet__E50F083E446ED4F5");

            entity.ToTable("tChiTietHDB");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.GhiChu).HasMaxLength(255);

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tChiTietH__MaChi__5FB337D6");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tChiTietH__MaHoa__5EBF139D");
        });

        modelBuilder.Entity<TChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSp).HasName("PK__tChiTiet__651D9057A340F93F");

            entity.ToTable("tChiTietSanPham");

            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaMauSac)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.Slton).HasColumnName("SLTon");

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .HasConstraintName("FK__tChiTietS__MaKic__4E88ABD4");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaMauSac)
                .HasConstraintName("FK__tChiTietS__MaMau__4F7CD00D");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK__tChiTietSa__MaSP__4D94879B");
        });

        modelBuilder.Entity<TDanhMucSp>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__tDanhMuc__2725081C22632332");

            entity.ToTable("tDanhMucSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.GioiThieuSp)
                .HasMaxLength(255)
                .HasColumnName("GioiThieuSP");
            entity.Property(e => e.MaChatLieu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaHangSx)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaHangSX");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNuocSx)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNuocSX");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.TenSp)
                .HasMaxLength(255)
                .HasColumnName("TenSP");
            entity.Property(e => e.Website).HasMaxLength(255);

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaChatLieu)
                .HasConstraintName("FK__tDanhMucS__MaCha__412EB0B6");

            entity.HasOne(d => d.MaHangSxNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaHangSx)
                .HasConstraintName("FK__tDanhMucS__MaHan__4222D4EF");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK__tDanhMucS__MaLoa__440B1D61");

            entity.HasOne(d => d.MaNuocSxNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaNuocSx)
                .HasConstraintName("FK__tDanhMucS__MaNuo__4316F928");
        });

        modelBuilder.Entity<THangSx>(entity =>
        {
            entity.HasKey(e => e.MaHangSx).HasName("PK__tHangSX__8C6D28FEDF6BF7D0");

            entity.ToTable("tHangSX");

            entity.Property(e => e.MaHangSx)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaHangSX");
            entity.Property(e => e.HangSx)
                .HasMaxLength(50)
                .HasColumnName("HangSX");
            entity.Property(e => e.MaNuocThuongHieu)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__tHoaDonB__835ED13B1C10480E");

            entity.ToTable("tHoaDonBan");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.GiamGiaHd).HasColumnName("GiamGiaHD");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaSoThue).HasMaxLength(50);
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.ThongTinThue).HasMaxLength(255);
            entity.Property(e => e.TongTienHd).HasColumnName("TongTienHD");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__tHoaDonBa__MaKha__5AEE82B9");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__tHoaDonBa__MaNha__5BE2A6F2");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__tKhachHa__88D2F0E5CEB0E4F5");

            entity.ToTable("tKhachHang");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.LoaiKhachHang).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenKhachHang).HasMaxLength(255);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TKhachHangs)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK__tKhachHan__usern__5535A963");
        });

        modelBuilder.Entity<TKichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc).HasName("PK__tKichThu__22BFD6645756ECC2");

            entity.ToTable("tKichThuoc");

            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TLoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__tLoaiSP__730A575988ACFAF1");

            entity.ToTable("tLoaiSP");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Loai).HasMaxLength(50);
        });

        modelBuilder.Entity<TMauSac>(entity =>
        {
            entity.HasKey(e => e.MaMauSac).HasName("PK__tMauSac__B9A91162E1D18885");

            entity.ToTable("tMauSac");

            entity.Property(e => e.MaMauSac)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenMauSac).HasMaxLength(50);
        });

        modelBuilder.Entity<TNhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__tNhanVie__77B2CA47E78FF814");

            entity.ToTable("tNhanVien");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenNhanVien).HasMaxLength(50);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TNhanViens)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK__tNhanVien__usern__5812160E");
        });

        modelBuilder.Entity<TQuocGium>(entity =>
        {
            entity.HasKey(e => e.MaNuoc).HasName("PK__tQuocGia__21306FEAAEA52ACA");

            entity.ToTable("tQuocGia");

            entity.Property(e => e.MaNuoc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenNuoc).HasMaxLength(50);
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__tUser__F3DBC57324925418");

            entity.ToTable("tUser");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.LoaiUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
