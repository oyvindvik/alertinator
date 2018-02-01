using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AlertinatorWeb.Data.Migrations
{
    public partial class UniqueIndexOnAlertTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropIndex(
                name: "IX_Alerts_Keyword_Url",
                table: "Alerts");*/

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_Keyword_Url",
                table: "Alerts",
                columns: new[] { "Keyword", "Url" },
                unique: true,
                filter: "[Keyword] IS NOT NULL AND [Url] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Alerts_Keyword_Url",
                table: "Alerts");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_Keyword_Url",
                table: "Alerts",
                columns: new[] { "Keyword", "Url" });
        }
    }
}
