using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DragonQuestNine.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccoladeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccoladeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccoladeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccoladeTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccoladeCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccoladeCategory_AccoladeType_AccoladeTypeId",
                        column: x => x.AccoladeTypeId,
                        principalTable: "AccoladeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accolades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsObtained = table.Column<bool>(type: "bit", nullable: false),
                    DateObtained = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccoladeCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accolades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accolades_AccoladeCategory_AccoladeCategoryId",
                        column: x => x.AccoladeCategoryId,
                        principalTable: "AccoladeCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccoladeCategory_AccoladeTypeId",
                table: "AccoladeCategory",
                column: "AccoladeTypeId");

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
                name: "AccoladeCategory");

            migrationBuilder.DropTable(
                name: "AccoladeType");
        }
    }
}
