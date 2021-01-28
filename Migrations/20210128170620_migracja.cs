using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wypozyczalnia_sprzetu_budowlanego.Migrations
{
    public partial class migracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id_category = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa_kategorii = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__E548B6731A0F7ED2", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id_customer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    nazwisko = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    numer_tel = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__8CC9BA460F14A790", x => x.id_customer);
                });

            migrationBuilder.CreateTable(
                name: "Tool",
                columns: table => new
                {
                    id_tool = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(nullable: false),
                    nazwa = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    producent = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    model = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    cena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tool__C9346C347522EEAE", x => x.id_tool);
                    table.ForeignKey(
                        name: "FK_Tool_ToCategoty",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "id_category",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Renting",
                columns: table => new
                {
                    id_renting = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(nullable: false),
                    tool_id = table.Column<int>(nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Renting__5B9FC36716996CE5", x => x.id_renting);
                    table.ForeignKey(
                        name: "FK_Renting_ToCustomer",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "id_customer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renting_ToTool",
                        column: x => x.tool_id,
                        principalTable: "Tool",
                        principalColumn: "id_tool",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Renting_customer_id",
                table: "Renting",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Renting_tool_id",
                table: "Renting",
                column: "tool_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tool_category_id",
                table: "Tool",
                column: "category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Renting");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Tool");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
