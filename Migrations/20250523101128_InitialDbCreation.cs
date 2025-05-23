using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagamentSystem_WPF_DB.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClothingProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "varchar(5)", nullable: true),
                    Fabric = table.Column<string>(type: "nvarchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClothingProducts_Products_ID",
                        column: x => x.ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectronicProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Voltage = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    BatteryCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ElectronicProducts_Products_ID",
                        column: x => x.ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerishableGoodsProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerishableGoodsProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PerishableGoodsProducts_Products_ID",
                        column: x => x.ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingProducts");

            migrationBuilder.DropTable(
                name: "ElectronicProducts");

            migrationBuilder.DropTable(
                name: "PerishableGoodsProducts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
