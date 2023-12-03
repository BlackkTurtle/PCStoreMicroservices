using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStoreService.API.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Statuses__C8EE2043B71385D9", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C3905BAF4D4E9B9E", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Statuses",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "StatusID");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Article = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ProductInfo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__4943444B3CACFB32", x => x.Article);
                    table.ForeignKey(
                        name: "FK_Products_Brands",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID");
                    table.ForeignKey(
                        name: "FK_Products_Types",
                        column: x => x.Type,
                        principalTable: "Types",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article = table.Column<int>(type: "int", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__C3B4DFAA228ED363", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Products",
                        column: x => x.Article,
                        principalTable: "Products",
                        principalColumn: "Article");
                });

            migrationBuilder.CreateTable(
                name: "PartOrders",
                columns: table => new
                {
                    POrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PartOrde__8BC48CFACF6672FB", x => x.POrderID);
                    table.ForeignKey(
                        name: "FK_PartOrders_Orders",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_PartOrders_Products",
                        column: x => x.Article,
                        principalTable: "Products",
                        principalColumn: "Article");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Article",
                table: "Comments",
                column: "Article");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusID",
                table: "Orders",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_PartOrders_Article",
                table: "PartOrders",
                column: "Article");

            migrationBuilder.CreateIndex(
                name: "IX_PartOrders_OrderID",
                table: "PartOrders",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Type",
                table: "Products",
                column: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PartOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
