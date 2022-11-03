using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionAppApi.Migrations
{
    public partial class AddedIsDisqualifiedToCompetitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisqualified",
                table: "Competitors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisqualified",
                table: "Competitors");
        }
    }
}
