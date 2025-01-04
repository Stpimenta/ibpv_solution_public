using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace c___Api_Example.Migrations
{
    /// <inheritdoc />
    public partial class updateTableUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "urlImage",
                table: "Usuarios",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "urlImage",
                table: "Usuarios");
        }
    }
}
