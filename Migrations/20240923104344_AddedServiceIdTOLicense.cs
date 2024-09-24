using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedServiceIdTOLicense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Licenses");
        }
    }
}
