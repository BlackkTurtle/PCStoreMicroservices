using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAndCommentEntityChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NakladnaId",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<bool>(
                name: "IsReview",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhotoLink",
                table: "Categories",
                type: "TEXT",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReview",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PhotoLink",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "NakladnaId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
