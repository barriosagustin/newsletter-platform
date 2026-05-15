using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FixUserTopicRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId1",
                table: "UserTopics",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserTopics",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTopics_TopicId1",
                table: "UserTopics",
                column: "TopicId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopics_UserId1",
                table: "UserTopics",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTopics_Topics_TopicId1",
                table: "UserTopics",
                column: "TopicId1",
                principalTable: "Topics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTopics_Users_UserId1",
                table: "UserTopics",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTopics_Topics_TopicId1",
                table: "UserTopics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTopics_Users_UserId1",
                table: "UserTopics");

            migrationBuilder.DropIndex(
                name: "IX_UserTopics_TopicId1",
                table: "UserTopics");

            migrationBuilder.DropIndex(
                name: "IX_UserTopics_UserId1",
                table: "UserTopics");

            migrationBuilder.DropColumn(
                name: "TopicId1",
                table: "UserTopics");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserTopics");
        }
    }
}
