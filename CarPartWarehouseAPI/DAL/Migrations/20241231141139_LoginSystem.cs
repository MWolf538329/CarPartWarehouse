using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class LoginSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLinks_Products_ProductDTOID",
                table: "ProductLinks");

            migrationBuilder.DropIndex(
                name: "IX_ProductLinks_ProductDTOID",
                table: "ProductLinks");

            migrationBuilder.DropColumn(
                name: "StockWas",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "ProductDTOID",
                table: "ProductLinks");

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.AddColumn<int>(
                name: "StockWas",
                table: "StockHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductDTOID",
                table: "ProductLinks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLinks_ProductDTOID",
                table: "ProductLinks",
                column: "ProductDTOID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLinks_Products_ProductDTOID",
                table: "ProductLinks",
                column: "ProductDTOID",
                principalTable: "Products",
                principalColumn: "ID");
        }
    }
}
