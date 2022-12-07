using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTPMBTL.Migrations
{
    /// <inheritdoc />
    public partial class CheckAccountCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckAccounts",
                columns: table => new
                {
                    CheckUserName = table.Column<string>(type: "TEXT", nullable: false),
                    CheckPassword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckAccounts", x => x.CheckUserName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckAccounts");
        }
    }
}
