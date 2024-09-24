using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesSystem.Migrations
{
    /// <inheritdoc />
    public partial class DeleteMAnyToManyRelationForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseUser");

            migrationBuilder.AddColumn<int>(
                name: "LicenseId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_LicenseId",
                table: "Users",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Licenses_LicenseId",
                table: "Users",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "LicenseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Licenses_LicenseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LicenseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "LicenseUser",
                columns: table => new
                {
                    LicensesLicenseId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseUser", x => new { x.LicensesLicenseId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_LicenseUser_Licenses_LicensesLicenseId",
                        column: x => x.LicensesLicenseId,
                        principalTable: "Licenses",
                        principalColumn: "LicenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicenseUser_UsersUserId",
                table: "LicenseUser",
                column: "UsersUserId");
        }
    }
}
