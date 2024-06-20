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
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=TEE;Initial Catalog=QLHS_1;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiTap>(entity =>
            {
                entity.HasKey(e => e.MaBaiTap)
                    .HasName("PK__BaiTap__3AF6A91511B810CD");

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
                    .HasConstraintName("FK__BaiTap__MaLopHoc__4AB81AF0");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.BaiTaps)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BaiTap__MaNV__49C3F6B7");
            });

            modelBuilder.Entity<BangDiem>(entity =>
            {
                entity.HasKey(e => e.MaBangDiem)
                    .HasName("PK__BangDiem__9D44FE48BC614A6F");

                entity.ToTable("BangDiem");

                entity.HasIndex(e => new { e.MaHs, e.MaMh }, "UQ__BangDiem__A557FB1307DE30CA")
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
                    .HasConstraintName("FK__BangDiem__MaHS__619B8048");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.BangDiems)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BangDiem__MaMH__628FA481");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("PK__ChucVu__27258E7631377CA8");

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
                    .HasConstraintName("FK__ChucVu__MaNV__4D94879B");
            });

            modelBuilder.Entity<HocSinh>(entity =>
            {
                entity.HasKey(e => e.MaHs)
                    .HasName("PK__HocSinh__2725A6EFAB2AFBEB");

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
                    .HasConstraintName("FK__HocSinh__MaLopHo__5070F446");

                entity.HasOne(d => d.MaTkNavigation)
                    .WithMany(p => p.HocSinhs)
                    .HasForeignKey(d => d.MaTk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HocSinh__MaTK__5165187F");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.MaLopHoc)
                    .HasName("PK__Lop__FEE05784B2DA335B");

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
                    .HasName("PK__MonHoc__2725DFD968CDBD1D");

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
                    .HasName("PK__MonHoc_T__8A44B1D63ABCC884");

                entity.ToTable("MonHoc_TKB");

                entity.HasIndex(e => new { e.MaMh, e.MaTkb }, "UQ__MonHoc_T__D43142B8B62CC7B4")
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
                    .HasConstraintName("FK__MonHoc_TKB__MaMH__5CD6CB2B");

                entity.HasOne(d => d.MaTkbNavigation)
                    .WithMany(p => p.MonHocTkbs)
                    .HasForeignKey(d => d.MaTkb)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonHoc_TK__MaTKB__5DCAEF64");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A0EE71C27");

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

                entity.Property(e => e.MaTk)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaTK")
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.HasOne(d => d.MaLopHocNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaLopHoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhanVien__MaLopH__45F365D3");

                entity.HasOne(d => d.MaTkNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaTk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhanVien__MaTK__46E78A0C");
            });

            modelBuilder.Entity<NhapDiem>(entity =>
            {
                entity.HasKey(e => e.MaNhapDiem)
                    .HasName("PK__NhapDiem__FCC9F48B8C31B806");

                entity.ToTable("NhapDiem");

                entity.HasIndex(e => new { e.MaMh, e.MaNv }, "UQ__NhapDiem__955782A811A3617D")
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
                    .HasConstraintName("FK__NhapDiem__MaBang__68487DD7");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.NhapDiems)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhapDiem__MaMH__66603565");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.NhapDiems)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhapDiem__MaNV__6754599E");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTk)
                    .HasName("PK__TaiKhoan__2725007058B0D4ED");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.MaTk)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MaTK")
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.LoaiTaiKhoan).HasMaxLength(20);

                entity.Property(e => e.Mk)
                    .HasMaxLength(100)
                    .HasColumnName("MK");
            });

            modelBuilder.Entity<ThuChi>(entity =>
            {
                entity.HasKey(e => e.MaGiaoDich)
                    .HasName("PK__ThuChi__0A2A24EBEC23173B");

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
                    .HasConstraintName("FK__ThuChi__MaHS__5812160E");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.ThuChis)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThuChi__MaNV__59063A47");
            });

            modelBuilder.Entity<Tkb>(entity =>
            {
                entity.HasKey(e => e.MaTkb)
                    .HasName("PK__TKB__3149D60EE84A3CAE");

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
                    .HasConstraintName("FK__TKB__MaHS__5441852A");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.Tkbs)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TKB__MaNV__5535A963");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
