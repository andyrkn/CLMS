using Microsoft.EntityFrameworkCore.Migrations;

namespace CLMS.QuestionsManagement.Persistance.Migrations
{
    public partial class ApproveAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Answer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Answer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Answer");
        }
    }
}
