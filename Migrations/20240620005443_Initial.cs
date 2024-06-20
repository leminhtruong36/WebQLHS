using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebQLHS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    MaLopHoc = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SiSo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lop__FEE0578410A94583", x => x.MaLopHoc);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    MaMH = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    TenMonHoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MonHoc__2725DFD979F42C5F", x => x.MaMH);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaLopHoc = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__2725D70A38314326", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK__NhanVien__MaLopH__3B75D760",
                        column: x => x.MaLopHoc,
                        principalTable: "Lop",
                        principalColumn: "MaLopHoc");
                });

            migrationBuilder.CreateTable(
                name: "BaiTap",
                columns: table => new
                {
                    MaBaiTap = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: false),
                    MaNV = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaLopHoc = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BaiTap__3AF6A91584D8C7EE", x => x.MaBaiTap);
                    table.ForeignKey(
                        name: "FK__BaiTap__MaLopHoc__3F466844",
                        column: x => x.MaLopHoc,
                        principalTable: "Lop",
                        principalColumn: "MaLopHoc");
                    table.ForeignKey(
                        name: "FK__BaiTap__MaNV__3E52440B",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaCV = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaNV = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChucVu__27258E768B459AE8", x => x.MaCV);
                    table.ForeignKey(
                        name: "FK__ChucVu__MaNV__4222D4EF",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTK = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MK = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LoaiTaiKhoan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaNV = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaiKhoan__27250070B2D309CD", x => x.MaTK);
                    table.ForeignKey(
                        name: "FK__TaiKhoan__MaNV__44FF419A",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "HocSinh",
                columns: table => new
                {
                    MaHS = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    EmailHocSinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaLopHoc = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaTK = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HocSinh__2725A6EF79DE009C", x => x.MaHS);
                    table.ForeignKey(
                        name: "FK__HocSinh__MaLopHo__47DBAE45",
                        column: x => x.MaLopHoc,
                        principalTable: "Lop",
                        principalColumn: "MaLopHoc");
                    table.ForeignKey(
                        name: "FK__HocSinh__MaTK__48CFD27E",
                        column: x => x.MaTK,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTK");
                });

            migrationBuilder.CreateTable(
                name: "BangDiem",
                columns: table => new
                {
                    MaBangDiem = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaHS = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaMH = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BangDiem__9D44FE48327549F4", x => x.MaBangDiem);
                    table.ForeignKey(
                        name: "FK__BangDiem__MaHS__59063A47",
                        column: x => x.MaHS,
                        principalTable: "HocSinh",
                        principalColumn: "MaHS");
                    table.ForeignKey(
                        name: "FK__BangDiem__MaMH__59FA5E80",
                        column: x => x.MaMH,
                        principalTable: "MonHoc",
                        principalColumn: "MaMH");
                });

            migrationBuilder.CreateTable(
                name: "ThuChi",
                columns: table => new
                {
                    MaGiaoDich = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    LoaiGiaoDich = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NgayGiaoDich = table.Column<DateTime>(type: "date", nullable: false),
                    SoTien = table.Column<double>(type: "float", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaHS = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaNV = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ThuChi__0A2A24EB12D1440D", x => x.MaGiaoDich);
                    table.ForeignKey(
                        name: "FK__ThuChi__MaHS__4F7CD00D",
                        column: x => x.MaHS,
                        principalTable: "HocSinh",
                        principalColumn: "MaHS");
                    table.ForeignKey(
                        name: "FK__ThuChi__MaNV__5070F446",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "TKB",
                columns: table => new
                {
                    MaTKB = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    Thu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tiet = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaHS = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaNV = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TKB__3149D60EC16D6E7C", x => x.MaTKB);
                    table.ForeignKey(
                        name: "FK__TKB__MaHS__4BAC3F29",
                        column: x => x.MaHS,
                        principalTable: "HocSinh",
                        principalColumn: "MaHS");
                    table.ForeignKey(
                        name: "FK__TKB__MaNV__4CA06362",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "NhapDiem",
                columns: table => new
                {
                    MaNhapDiem = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    DiemSo = table.Column<double>(type: "float", nullable: false),
                    MaMH = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaNV = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaBangDiem = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhapDiem__FCC9F48B3AC1B78A", x => x.MaNhapDiem);
                    table.ForeignKey(
                        name: "FK__NhapDiem__MaBang__5FB337D6",
                        column: x => x.MaBangDiem,
                        principalTable: "BangDiem",
                        principalColumn: "MaBangDiem");
                    table.ForeignKey(
                        name: "FK__NhapDiem__MaMH__5DCAEF64",
                        column: x => x.MaMH,
                        principalTable: "MonHoc",
                        principalColumn: "MaMH");
                    table.ForeignKey(
                        name: "FK__NhapDiem__MaNV__5EBF139D",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "MonHoc_TKB",
                columns: table => new
                {
                    MaMH_TKB = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaMH = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false),
                    MaTKB = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MonHoc_T__8A44B1D6D7BB5549", x => x.MaMH_TKB);
                    table.ForeignKey(
                        name: "FK__MonHoc_TK__MaTKB__5535A963",
                        column: x => x.MaTKB,
                        principalTable: "TKB",
                        principalColumn: "MaTKB");
                    table.ForeignKey(
                        name: "FK__MonHoc_TKB__MaMH__5441852A",
                        column: x => x.MaMH,
                        principalTable: "MonHoc",
                        principalColumn: "MaMH");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiTap_MaLopHoc",
                table: "BaiTap",
                column: "MaLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_BaiTap_MaNV",
                table: "BaiTap",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_BangDiem_MaMH",
                table: "BangDiem",
                column: "MaMH");

            migrationBuilder.CreateIndex(
                name: "UQ__BangDiem__A557FB139EF3E120",
                table: "BangDiem",
                columns: new[] { "MaHS", "MaMH" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChucVu_MaNV",
                table: "ChucVu",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_MaLopHoc",
                table: "HocSinh",
                column: "MaLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_MaTK",
                table: "HocSinh",
                column: "MaTK");

            migrationBuilder.CreateIndex(
                name: "IX_MonHoc_TKB_MaTKB",
                table: "MonHoc_TKB",
                column: "MaTKB");

            migrationBuilder.CreateIndex(
                name: "UQ__MonHoc_T__D43142B80427D49C",
                table: "MonHoc_TKB",
                columns: new[] { "MaMH", "MaTKB" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaLopHoc",
                table: "NhanVien",
                column: "MaLopHoc");

            migrationBuilder.CreateIndex(
                name: "IX_NhapDiem_MaBangDiem",
                table: "NhapDiem",
                column: "MaBangDiem");

            migrationBuilder.CreateIndex(
                name: "IX_NhapDiem_MaNV",
                table: "NhapDiem",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "UQ__NhapDiem__955782A8EE35622A",
                table: "NhapDiem",
                columns: new[] { "MaMH", "MaNV" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_MaNV",
                table: "TaiKhoan",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_ThuChi_MaHS",
                table: "ThuChi",
                column: "MaHS");

            migrationBuilder.CreateIndex(
                name: "IX_ThuChi_MaNV",
                table: "ThuChi",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_TKB_MaHS",
                table: "TKB",
                column: "MaHS");

            migrationBuilder.CreateIndex(
                name: "IX_TKB_MaNV",
                table: "TKB",
                column: "MaNV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiTap");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "MonHoc_TKB");

            migrationBuilder.DropTable(
                name: "NhapDiem");

            migrationBuilder.DropTable(
                name: "ThuChi");

            migrationBuilder.DropTable(
                name: "TKB");

            migrationBuilder.DropTable(
                name: "BangDiem");

            migrationBuilder.DropTable(
                name: "HocSinh");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Lop");
        }
    }
}
