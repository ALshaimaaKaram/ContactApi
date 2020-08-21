using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.Migrations
{
    public partial class fixstar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStart",
                table: "Contacts");

            migrationBuilder.AddColumn<bool>(
                name: "IsStar",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStar",
                table: "Contacts");

            migrationBuilder.AddColumn<bool>(
                name: "IsStart",
                table: "Contacts",
                type: "bit",
                nullable: true);
        }
    }
}
