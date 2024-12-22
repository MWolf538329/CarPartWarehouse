using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DTOImplementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLinks_Products_ProductID",
                table: "ProductLinks");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductLinks",
                newName: "ProductDTOID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLinks_ProductID",
                table: "ProductLinks",
                newName: "IX_ProductLinks_ProductDTOID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subcategories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLinks_Products_ProductDTOID",
                table: "ProductLinks",
                column: "ProductDTOID",
                principalTable: "Products",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLinks_Products_ProductDTOID",
                table: "ProductLinks");

            migrationBuilder.RenameColumn(
                name: "ProductDTOID",
                table: "ProductLinks",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLinks_ProductDTOID",
                table: "ProductLinks",
                newName: "IX_ProductLinks_ProductID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subcategories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLinks_Products_ProductID",
                table: "ProductLinks",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID");
        }
    }
}
