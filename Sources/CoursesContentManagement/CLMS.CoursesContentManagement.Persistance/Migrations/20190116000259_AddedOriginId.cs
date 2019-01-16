using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CLMS.CoursesContentManagement.Persistance.Migrations
{
    public partial class AddedOriginId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OriginId",
                table: "ContentHolders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "ContentHolders");
        }
    }
}
