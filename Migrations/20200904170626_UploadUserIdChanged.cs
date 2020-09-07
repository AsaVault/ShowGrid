using Microsoft.EntityFrameworkCore.Migrations;

namespace ShowGrid.Migrations
{
    public partial class UploadUserIdChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUpload_UploadUser_UploadUserId1",
                table: "UserUpload");

            migrationBuilder.DropIndex(
                name: "IX_UserUpload_UploadUserId1",
                table: "UserUpload");

            migrationBuilder.DropColumn(
                name: "UploadUserId1",
                table: "UserUpload");

            migrationBuilder.AlterColumn<int>(
                name: "UploadUserId",
                table: "UserUpload",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserUpload_UploadUserId",
                table: "UserUpload",
                column: "UploadUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUpload_UploadUser_UploadUserId",
                table: "UserUpload",
                column: "UploadUserId",
                principalTable: "UploadUser",
                principalColumn: "UploadUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUpload_UploadUser_UploadUserId",
                table: "UserUpload");

            migrationBuilder.DropIndex(
                name: "IX_UserUpload_UploadUserId",
                table: "UserUpload");

            migrationBuilder.AlterColumn<string>(
                name: "UploadUserId",
                table: "UserUpload",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UploadUserId1",
                table: "UserUpload",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserUpload_UploadUserId1",
                table: "UserUpload",
                column: "UploadUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUpload_UploadUser_UploadUserId1",
                table: "UserUpload",
                column: "UploadUserId1",
                principalTable: "UploadUser",
                principalColumn: "UploadUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
