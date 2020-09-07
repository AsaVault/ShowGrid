using Microsoft.EntityFrameworkCore.Migrations;

namespace ShowGrid.Migrations
{
    public partial class ChangesToMoodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UploadList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadUser",
                columns: table => new
                {
                    UploadUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadUser", x => x.UploadUserId);
                });

            migrationBuilder.CreateTable(
                name: "UserUpload",
                columns: table => new
                {
                    UserUploadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    UploadUserId = table.Column<string>(nullable: true),
                    UploadUserId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUpload", x => x.UserUploadId);
                    table.ForeignKey(
                        name: "FK_UserUpload_UploadUser_UploadUserId1",
                        column: x => x.UploadUserId1,
                        principalTable: "UploadUser",
                        principalColumn: "UploadUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUpload_UploadUserId1",
                table: "UserUpload",
                column: "UploadUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UploadList");

            migrationBuilder.DropTable(
                name: "UserUpload");

            migrationBuilder.DropTable(
                name: "UploadUser");
        }
    }
}
