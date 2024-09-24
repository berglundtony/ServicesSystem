using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesSystem.Migrations
{
    /// <inheritdoc />
    public partial class JustToCheckIfIHaveChangedSomething : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Licenses_LicenseId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "LicenseId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Licenses_LicenseId",
                table: "Users",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "LicenseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Licenses_LicenseId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "LicenseId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Licenses_LicenseId",
                table: "Users",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "LicenseId");
        }
    }
}
