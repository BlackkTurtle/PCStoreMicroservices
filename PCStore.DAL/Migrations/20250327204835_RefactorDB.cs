using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RefactorDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nakladnis_NakladnaTypes_NakladnaTypeId",
                table: "Nakladnis");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Statuses_StatusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "NakladnaTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Nakladnis_NakladnaTypeId",
                table: "Nakladnis");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Orders",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "NakladnaTypeId",
                table: "Nakladnis",
                newName: "NakladnaType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Orders",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "NakladnaType",
                table: "Nakladnis",
                newName: "NakladnaTypeId");

            migrationBuilder.CreateTable(
                name: "NakladnaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NakladnaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Nakladnis_NakladnaTypeId",
                table: "Nakladnis",
                column: "NakladnaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nakladnis_NakladnaTypes_NakladnaTypeId",
                table: "Nakladnis",
                column: "NakladnaTypeId",
                principalTable: "NakladnaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Statuses_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
