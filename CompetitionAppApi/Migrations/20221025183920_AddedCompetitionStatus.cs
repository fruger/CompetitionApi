﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionAppApi.Migrations
{
    public partial class AddedCompetitionStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Competitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Competitions");
        }
    }
}
