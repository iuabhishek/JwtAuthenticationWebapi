using Microsoft.EntityFrameworkCore.Migrations;

namespace JWTAuthentication.Migrations
{
    public partial class loginuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseName",
                table: "logins");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "logins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "logins");

            migrationBuilder.AddColumn<string>(
                name: "UseName",
                table: "logins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
