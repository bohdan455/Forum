using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerySimpleForum.Migrations
{
    public partial class fixProblemWithComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Comment_CommentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_BelongsToId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_SubTopics_SubTopicId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_SubTopicId",
                table: "Comments",
                newName: "IX_Comments_SubTopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BelongsToId",
                table: "Comments",
                newName: "IX_Comments_BelongsToId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Comments_CommentId",
                table: "AspNetUsers",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_BelongsToId",
                table: "Comments",
                column: "BelongsToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SubTopics_SubTopicId",
                table: "Comments",
                column: "SubTopicId",
                principalTable: "SubTopics",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Comments_CommentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_BelongsToId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SubTopics_SubTopicId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_SubTopicId",
                table: "Comment",
                newName: "IX_Comment_SubTopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BelongsToId",
                table: "Comment",
                newName: "IX_Comment_BelongsToId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Comment_CommentId",
                table: "AspNetUsers",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_BelongsToId",
                table: "Comment",
                column: "BelongsToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_SubTopics_SubTopicId",
                table: "Comment",
                column: "SubTopicId",
                principalTable: "SubTopics",
                principalColumn: "Id");
        }
    }
}
