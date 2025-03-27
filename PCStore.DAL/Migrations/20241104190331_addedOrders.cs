using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Nakladnis");

            migrationBuilder.CreateTable(
                name: "DeliverOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliverAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    FullAddress = table.Column<string>(type: "TEXT", nullable: false),
                    DeliverOptionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliverAddresses_DeliverOptions_DeliverOptionId",
                        column: x => x.DeliverOptionId,
                        principalTable: "DeliverOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FatherName = table.Column<string>(type: "TEXT", nullable: true),
                    DeliverAddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    NakladnaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DeliverAddresses_DeliverAddressId",
                        column: x => x.DeliverAddressId,
                        principalTable: "DeliverAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Nakladnis_NakladnaId",
                        column: x => x.NakladnaId,
                        principalTable: "Nakladnis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliverAddresses_DeliverOptionId",
                table: "DeliverAddresses",
                column: "DeliverOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliverAddressId",
                table: "Orders",
                column: "DeliverAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_NakladnaId",
                table: "Orders",
                column: "NakladnaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentTypeId",
                table: "Orders",
                column: "PaymentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "DeliverAddresses");

            migrationBuilder.DropTable(
                name: "DeliverOptions");

            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Nakladnis",
                type: "TEXT",
                nullable: true);
        }
    }
}
