using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumSystem.Data.Migrations
{
    public partial class AddRecursiveComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParrentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParrentId",
                table: "Comments",
                column: "ParrentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParrentId",
                table: "Comments",
                column: "ParrentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParrentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParrentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParrentId",
                table: "Comments");
        }
    }
}
