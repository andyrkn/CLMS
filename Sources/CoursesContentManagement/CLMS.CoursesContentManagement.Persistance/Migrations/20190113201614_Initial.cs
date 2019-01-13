using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CLMS.CoursesContentManagement.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentHolders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HolderEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentHolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Bytes = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ContentHolderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_ContentHolders_ContentHolderId",
                        column: x => x.ContentHolderId,
                        principalTable: "ContentHolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    FileContentId = table.Column<Guid>(nullable: false),
                    ContentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_File_FileContent_FileContentId",
                        column: x => x.FileContentId,
                        principalTable: "FileContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Content_ContentHolderId",
                table: "Content",
                column: "ContentHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_File_ContentId",
                table: "File",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_File_FileContentId",
                table: "File",
                column: "FileContentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "FileContent");

            migrationBuilder.DropTable(
                name: "ContentHolders");
        }
    }
}
