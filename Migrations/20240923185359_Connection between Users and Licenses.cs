using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesSystem.Migrations
{
    /// <inheritdoc />
    public partial class ConnectionbetweenUsersandLicenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoftwareName",
                table: "Licenses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SoftwareName",
                table: "Licenses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
