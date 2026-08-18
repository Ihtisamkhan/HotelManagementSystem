using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenanceReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaintenanceReason",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenanceReason",
                table: "Rooms");
        }
    }
}
