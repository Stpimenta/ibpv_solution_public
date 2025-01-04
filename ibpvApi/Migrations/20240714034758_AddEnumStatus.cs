using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace c___Api_Example.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Usuarios");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
