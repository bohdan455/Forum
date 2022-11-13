using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerySimpleForum.Migrations
{
    public partial class ChangeTypeOfLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "SubTopics");

            migrationBuilder.AddColumn<int>(
                name: "SubTopicId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SubTopicId",
                table: "AspNetUsers",
                column: "SubTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SubTopics_SubTopicId",
                table: "AspNetUsers",
                column: "SubTopicId",
                principalTable: "SubTopics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SubTopics_SubTopicId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SubTopicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubTopicId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "SubTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
