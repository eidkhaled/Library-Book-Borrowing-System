using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "BorrowingRecords");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "NumberOfCopies",
                table: "Books",
                newName: "TotalCopies");

            migrationBuilder.AddColumn<string>(
                name: "borrowerAddress",
                table: "BorrowingRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "borrowerName",
                table: "BorrowingRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "BorrowingRecords",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "borrowerAddress",
                table: "BorrowingRecords");

            migrationBuilder.DropColumn(
                name: "borrowerName",
                table: "BorrowingRecords");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "BorrowingRecords");

            migrationBuilder.RenameColumn(
                name: "TotalCopies",
                table: "Books",
                newName: "NumberOfCopies");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "BorrowingRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
