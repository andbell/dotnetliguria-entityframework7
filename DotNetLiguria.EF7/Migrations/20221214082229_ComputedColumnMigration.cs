using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetLiguria.EF7.Migrations
{
    /// <inheritdoc />
    public partial class ComputedColumnMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComputedYear",
                table: "Movies",
                type: "int",
                nullable: true,
                computedColumnSql: "JSON_VALUE(Info, '$.Year')");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ComputedYear",
                table: "Movies",
                column: "ComputedYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movies_ComputedYear",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ComputedYear",
                table: "Movies");
        }
    }
}
