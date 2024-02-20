using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingRecords_BookCopies_bookCopyCopyId",
                table: "BorrowingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BorrowingRecords_bookCopyCopyId",
                table: "BorrowingRecords");

            migrationBuilder.DropColumn(
                name: "bookCopyCopyId",
                table: "BorrowingRecords");

            migrationBuilder.AddColumn<int>(
                name: "bookCopyId",
                table: "BorrowingRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecords_bookCopyId",
                table: "BorrowingRecords",
                column: "bookCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingRecords_BookCopies_bookCopyId",
                table: "BorrowingRecords",
                column: "bookCopyId",
                principalTable: "BookCopies",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingRecords_BookCopies_bookCopyId",
                table: "BorrowingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BorrowingRecords_bookCopyId",
                table: "BorrowingRecords");

            migrationBuilder.DropColumn(
                name: "bookCopyId",
                table: "BorrowingRecords");

            migrationBuilder.AddColumn<int>(
                name: "bookCopyCopyId",
                table: "BorrowingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingRecords_bookCopyCopyId",
                table: "BorrowingRecords",
                column: "bookCopyCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingRecords_BookCopies_bookCopyCopyId",
                table: "BorrowingRecords",
                column: "bookCopyCopyId",
                principalTable: "BookCopies",
                principalColumn: "CopyId");
        }
    }
}
