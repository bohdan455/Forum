using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerySimpleForum.Migrations
{
    public partial class AddLikeToComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikesNumber",
                table: "SubTopics");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CommentId",
                table: "AspNetUsers",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Comment_CommentId",
                table: "AspNetUsers",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Comment_CommentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CommentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "LikesNumber",
                table: "SubTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
