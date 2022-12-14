using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetLiguria.EF7.Migrations;

/// <inheritdoc />
public partial class AddEpisodesMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Episode");

        migrationBuilder.AddColumn<string>(
            name: "Seasons",
            table: "Movies",
            type: "nvarchar(max)",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Seasons",
            table: "Movies");

        migrationBuilder.CreateTable(
            name: "Episode",
            columns: table => new
            {
                SerieTvId = table.Column<int>(type: "int", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Number = table.Column<int>(type: "int", nullable: false),
                Season = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Episode", x => new { x.SerieTvId, x.Id });
                table.ForeignKey(
                    name: "FK_Episode_Movies_SerieTvId",
                    column: x => x.SerieTvId,
                    principalTable: "Movies",
                    principalColumn: "MovieId",
                    onDelete: ReferentialAction.Cascade);
            });
    }
}
