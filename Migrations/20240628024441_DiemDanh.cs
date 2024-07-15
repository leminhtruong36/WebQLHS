using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebQLHS.Migrations
{
    public partial class DiemDanh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "DiemDanhs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "CoPhep",
                table: "DiemDanhs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoPhep",
                table: "DiemDanhs");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "DiemDanhs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
