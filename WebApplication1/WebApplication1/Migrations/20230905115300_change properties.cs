using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class changeproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Brands",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Brands",
                newName: "LastName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Brands",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Brands",
                newName: "IsActive");
        }
    }
}
