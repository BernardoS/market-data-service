using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketDataService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsEnabledColumnToAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Assets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Assets");
        }
    }
}
