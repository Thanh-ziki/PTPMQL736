using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTPMBTL.Migrations
{
    /// <inheritdoc />
    public partial class KhachHangCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    IDKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    TenKH = table.Column<string>(type: "TEXT", nullable: false),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: false),
                    SoBan = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.IDKhachHang);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHangs");
        }
    }
}
