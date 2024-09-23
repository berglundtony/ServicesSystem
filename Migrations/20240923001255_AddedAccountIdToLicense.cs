using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccountIdToLicense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Licenses");
        }
    }
}
