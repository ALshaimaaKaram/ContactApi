using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.Migrations
{
    public partial class InitialContactsDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    IsStart = table.Column<bool>(nullable: true),
                    OpenCountForFreequent = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
