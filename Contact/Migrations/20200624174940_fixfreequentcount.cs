using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.Migrations
{
    public partial class fixfreequentcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OpenCountForFreequent",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OpenCountForFreequent",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
