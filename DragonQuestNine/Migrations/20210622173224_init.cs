using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DragonQuestNine.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccoladeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccoladeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accolades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsObtained = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateObtained = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccoladeCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accolades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accolades_AccoladeCategories_AccoladeCategoryId",
                        column: x => x.AccoladeCategoryId,
                        principalTable: "AccoladeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accolades_AccoladeCategoryId",
                table: "Accolades",
                column: "AccoladeCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accolades");

            migrationBuilder.DropTable(
                name: "AccoladeCategories");
        }
    }
}
