using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore1.Migrations
{
    /// <inheritdoc />
    public partial class AddDbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterestGroup_InterestGroup_InterestGroupId",
                table: "UserInterestGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInterestGroup_Users_UserId",
                table: "UserInterestGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInterestGroup",
                table: "UserInterestGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestGroup",
                table: "InterestGroup");

            migrationBuilder.RenameTable(
                name: "UserInterestGroup",
                newName: "UserGroup");

            migrationBuilder.RenameTable(
                name: "InterestGroup",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_UserInterestGroup_InterestGroupId",
                table: "UserGroup",
                newName: "IX_UserGroup_InterestGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup",
                columns: new[] { "UserId", "InterestGroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Groups_InterestGroupId",
                table: "UserGroup",
                column: "InterestGroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Users_UserId",
                table: "UserGroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Groups_InterestGroupId",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Users_UserId",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "UserGroup",
                newName: "UserInterestGroup");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "InterestGroup");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_InterestGroupId",
                table: "UserInterestGroup",
                newName: "IX_UserInterestGroup_InterestGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInterestGroup",
                table: "UserInterestGroup",
                columns: new[] { "UserId", "InterestGroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestGroup",
                table: "InterestGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterestGroup_InterestGroup_InterestGroupId",
                table: "UserInterestGroup",
                column: "InterestGroupId",
                principalTable: "InterestGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterestGroup_Users_UserId",
                table: "UserInterestGroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
