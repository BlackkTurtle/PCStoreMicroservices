using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CommentEntityDateModifiedNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentStatusEnum",
                table: "Comments",
                newName: "CommentStatus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Comments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentStatus",
                table: "Comments",
                newName: "CommentStatusEnum");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
