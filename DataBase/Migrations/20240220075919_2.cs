using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingRecords_BookCopies_bookCopyCopyId",
                table: "BorrowingRecords");

            migrationBuilder.AlterColumn<int>(
                name: "bookCopyCopyId",
                table: "BorrowingRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingRecords_BookCopies_bookCopyCopyId",
                table: "BorrowingRecords",
                column: "bookCopyCopyId",
                principalTable: "BookCopies",
                principalColumn: "CopyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowingRecords_BookCopies_bookCopyCopyId",
                table: "BorrowingRecords");

            migrationBuilder.AlterColumn<int>(
                name: "bookCopyCopyId",
                table: "BorrowingRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowingRecords_BookCopies_bookCopyCopyId",
                table: "BorrowingRecords",
                column: "bookCopyCopyId",
                principalTable: "BookCopies",
                principalColumn: "CopyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
