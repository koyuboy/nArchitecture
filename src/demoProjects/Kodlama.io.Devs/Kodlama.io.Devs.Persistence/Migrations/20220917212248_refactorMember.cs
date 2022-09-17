using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class refactorMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GithubAccounts_MemberId",
                table: "GithubAccounts");

            migrationBuilder.CreateIndex(
                name: "IX_GithubAccounts_MemberId",
                table: "GithubAccounts",
                column: "MemberId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GithubAccounts_MemberId",
                table: "GithubAccounts");

            migrationBuilder.CreateIndex(
                name: "IX_GithubAccounts_MemberId",
                table: "GithubAccounts",
                column: "MemberId");
        }
    }
}
