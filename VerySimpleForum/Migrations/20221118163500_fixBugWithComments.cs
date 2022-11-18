using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerySimpleForum.Migrations
{
    public partial class fixBugWithComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubTopics_Comment_CommentsId",
                table: "SubTopics");

            migrationBuilder.DropIndex(
                name: "IX_SubTopics_CommentsId",
                table: "SubTopics");

            migrationBuilder.DropColumn(
                name: "CommentsId",
                table: "SubTopics");

            migrationBuilder.AddColumn<int>(
                name: "SubTopicId",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_SubTopicId",
                table: "Comment",
                column: "SubTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_SubTopics_SubTopicId",
                table: "Comment",
                column: "SubTopicId",
                principalTable: "SubTopics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_SubTopics_SubTopicId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_SubTopicId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "SubTopicId",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "CommentsId",
                table: "SubTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubTopics_CommentsId",
                table: "SubTopics",
                column: "CommentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubTopics_Comment_CommentsId",
                table: "SubTopics",
                column: "CommentsId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
