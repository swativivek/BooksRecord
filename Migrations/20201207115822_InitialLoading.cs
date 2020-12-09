using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksRecord.Migrations
{
    public partial class InitialLoading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "markread",
                table: "bkctlog",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "markread",
                table: "bkctlog");
        }
    }
}
