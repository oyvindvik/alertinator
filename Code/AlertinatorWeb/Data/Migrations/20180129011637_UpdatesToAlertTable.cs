using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AlertinatorWeb.Data.Migrations
{
    public partial class UpdatesToAlertTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Alerts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                table: "Alerts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_Keyword_Url",
                table: "Alerts",
                columns: new[] { "Keyword", "Url" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Alerts_Keyword_Url",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Keyword",
                table: "Alerts");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Alerts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
