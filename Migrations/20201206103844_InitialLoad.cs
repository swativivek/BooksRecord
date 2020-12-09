using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksRecord.Migrations
{
    public partial class InitialLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bkctlog",
                columns: table => new
                {
                    bookid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    bookname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bkctlog", x => x.bookid);
                });

            migrationBuilder.InsertData(
                table: "bkctlog",
                columns: new[] { "bookid", "bookname", "review" },
                values: new object[] { "12367", "Electronics", "" });

            migrationBuilder.InsertData(
                table: "bkctlog",
                columns: new[] { "bookid", "bookname", "review" },
                values: new object[] { "27678", "Recipes for the best", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bkctlog");
        }
    }
}
