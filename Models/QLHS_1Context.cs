using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebQLHS.Models
{
    public partial class QLHS_1Context : DbContext
    {
        public QLHS_1Context()
        {
        }

        public QLHS_1Context(DbContextOptions<QLHS_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BaiTap> BaiTaps { get; set; } = null!;
        public virtual DbSet<BangDiem> BangDiems { get; set; } = null!;
        public virtual DbSet<ChucVu> ChucVus { get; set; } = null!;
        public virtual DbSet<HocSinh> HocSinhs { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<MonHocTkb> MonHocTkbs { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<NhapDiem> NhapDiems { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;
        public virtual DbSet<ThuChi> ThuChis { get; set; } = null!;
        public virtual DbSet<Tkb> Tkbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=QLHSConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiTap>(entity =>
            {
                entity.HasKey(e => e.MaBaiTap)
                    .HasName("PK__BaiTap__3AF6A91584D8C7EE");

                entity.ToTable("BaiTap");

                entity.Property(e => e.MaBaiTap)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaLopHoc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaNv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.HasOne(d => d.MaLopHocNavigation)
                    .WithMany(p => p.BaiTaps)
                    .HasForeignKey(d => d.MaLopHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BaiTap__MaLopHoc__3F466844");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.BaiTaps)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BaiTap__MaNV__3E52440B");
            });

            modelBuilder.Entity<BangDiem>(entity =>
            {
                entity.HasKey(e => e.MaBangDiem)
                    .HasName("PK__BangDiem__9D44FE48327549F4");

                entity.ToTable("BangDiem");

                entity.HasIndex(e => new { e.MaHs, e.MaMh }, "UQ__BangDiem__A557FB139EF3E120")
                    .IsUnique();

                entity.Property(e => e.MaBangDiem)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaHs)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaHS")
                    .IsFixedLength();

                entity.Property(e => e.MaMh)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaMH")
                    .IsFixedLength();

                entity.HasOne(d => d.MaHsNavigation)
                    .WithMany(p => p.BangDiems)
                    .HasForeignKey(d => d.MaHs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BangDiem__MaHS__59063A47");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.BangDiems)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BangDiem__MaMH__59FA5E80");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("PK__ChucVu__27258E768B459AE8");

                entity.ToTable("ChucVu");

                entity.Property(e => e.MaCv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaCV")
                    .IsFixedLength();

                entity.Property(e => e.MaNv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.Property(e => e.TenChucVu).HasMaxLength(50);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.ChucVus)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChucVu__MaNV__4222D4EF");
            });

            modelBuilder.Entity<HocSinh>(entity =>
            {
                entity.HasKey(e => e.MaHs)
                    .HasName("PK__HocSinh__2725A6EF79DE009C");

                entity.ToTable("HocSinh");

                entity.Property(e => e.MaHs)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaHS")
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.EmailHocSinh).HasMaxLength(100);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaLopHoc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaTk)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaTK")
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.HasOne(d => d.MaLopHocNavigation)
                    .WithMany(p => p.HocSinhs)
                    .HasForeignKey(d => d.MaLopHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HocSinh__MaLopHo__47DBAE45");

                entity.HasOne(d => d.MaTkNavigation)
                    .WithMany(p => p.HocSinhs)
                    .HasForeignKey(d => d.MaTk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HocSinh__MaTK__48CFD27E");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLopHoc)
                    .HasName("PK__Lop__FEE0578410A94583");

                entity.ToTable("Lop");

                entity.Property(e => e.MaLopHoc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenLop).HasMaxLength(100);
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("PK__MonHoc__2725DFD979F42C5F");

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaMH")
                    .IsFixedLength();

                entity.Property(e => e.TenMonHoc).HasMaxLength(50);
            });

            modelBuilder.Entity<MonHocTkb>(entity =>
            {
                entity.HasKey(e => e.MaMhTkb)
                    .HasName("PK__MonHoc_T__8A44B1D6D7BB5549");

                entity.ToTable("MonHoc_TKB");

                entity.HasIndex(e => new { e.MaMh, e.MaTkb }, "UQ__MonHoc_T__D43142B80427D49C")
                    .IsUnique();

                entity.Property(e => e.MaMhTkb)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaMH_TKB")
                    .IsFixedLength();

                entity.Property(e => e.MaMh)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaMH")
                    .IsFixedLength();

                entity.Property(e => e.MaTkb)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaTKB")
                    .IsFixedLength();

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.MonHocTkbs)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonHoc_TKB__MaMH__5441852A");

                entity.HasOne(d => d.MaTkbNavigation)
                    .WithMany(p => p.MonHocTkbs)
                    .HasForeignKey(d => d.MaTkb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonHoc_TK__MaTKB__5535A963");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A38314326");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.MaLopHoc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.HasOne(d => d.MaLopHocNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaLopHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhanVien__MaLopH__3B75D760");
            });

            modelBuilder.Entity<NhapDiem>(entity =>
            {
                entity.HasKey(e => e.MaNhapDiem)
                    .HasName("PK__NhapDiem__FCC9F48B3AC1B78A");

                entity.ToTable("NhapDiem");

                entity.HasIndex(e => new { e.MaMh, e.MaNv }, "UQ__NhapDiem__955782A8EE35622A")
                    .IsUnique();

                entity.Property(e => e.MaNhapDiem)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaBangDiem)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaMh)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaMH")
                    .IsFixedLength();

                entity.Property(e => e.MaNv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.HasOne(d => d.MaBangDiemNavigation)
                    .WithMany(p => p.NhapDiems)
                    .HasForeignKey(d => d.MaBangDiem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhapDiem__MaBang__5FB337D6");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.NhapDiems)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhapDiem__MaMH__5DCAEF64");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.NhapDiems)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhapDiem__MaNV__5EBF139D");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTk)
                    .HasName("PK__TaiKhoan__27250070B2D309CD");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.MaTk)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaTK")
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.LoaiTaiKhoan).HasMaxLength(20);

                entity.Property(e => e.MaNv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.Property(e => e.Mk)
                    .HasMaxLength(100)
                    .HasColumnName("MK");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TaiKhoan__MaNV__44FF419A");
            });

            modelBuilder.Entity<ThuChi>(entity =>
            {
                entity.HasKey(e => e.MaGiaoDich)
                    .HasName("PK__ThuChi__0A2A24EB12D1440D");

                entity.ToTable("ThuChi");

                entity.Property(e => e.MaGiaoDich)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LoaiGiaoDich).HasMaxLength(20);

                entity.Property(e => e.MaHs)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaHS")
                    .IsFixedLength();

                entity.Property(e => e.MaNv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.Property(e => e.MoTa).HasMaxLength(200);

                entity.Property(e => e.NgayGiaoDich).HasColumnType("date");

                entity.HasOne(d => d.MaHsNavigation)
                    .WithMany(p => p.ThuChis)
                    .HasForeignKey(d => d.MaHs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThuChi__MaHS__4F7CD00D");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.ThuChis)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThuChi__MaNV__5070F446");
            });

            modelBuilder.Entity<Tkb>(entity =>
            {
                entity.HasKey(e => e.MaTkb)
                    .HasName("PK__TKB__3149D60EC16D6E7C");

                entity.ToTable("TKB");

                entity.Property(e => e.MaTkb)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaTKB")
                    .IsFixedLength();

                entity.Property(e => e.MaHs)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaHS")
                    .IsFixedLength();

                entity.Property(e => e.MaNv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.Property(e => e.Thu).HasMaxLength(20);

                entity.Property(e => e.Tiet).HasMaxLength(20);

                entity.HasOne(d => d.MaHsNavigation)
                    .WithMany(p => p.Tkbs)
                    .HasForeignKey(d => d.MaHs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TKB__MaHS__4BAC3F29");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Tkbs)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TKB__MaNV__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
