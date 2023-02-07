using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class Inicial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image_Product",
                table: "Products",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    NameCompany = table.Column<string>(nullable: false),
                    NameOwner = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DNI = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    NumDocument = table.Column<string>(nullable: true),
                    Serie1 = table.Column<string>(nullable: true),
                    Serie2 = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    DataBase = table.Column<string>(nullable: true),
                    Iva = table.Column<string>(nullable: true),
                    Current = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.NameCompany);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.AlterColumn<string>(
                name: "Image_Product",
                table: "Products",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);
        }
    }
}
