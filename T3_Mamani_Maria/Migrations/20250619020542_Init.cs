using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T3_Mamani_Maria.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnioPublicacion",
                table: "Libro",
                newName: "Anio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Anio",
                table: "Libro",
                newName: "AnioPublicacion");
        }
    }
}
