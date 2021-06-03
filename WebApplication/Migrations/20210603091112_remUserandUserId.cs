using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class remUserandUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_Users_UserId",
                table: "CreditCard");

            migrationBuilder.DropIndex(
                name: "IX_CreditCard_UserId",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CreditCard");

            migrationBuilder.AddColumn<string>(
                name: "CreditCardNumberCard",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreditCardNumberCard",
                table: "Users",
                column: "CreditCardNumberCard");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CreditCard_CreditCardNumberCard",
                table: "Users",
                column: "CreditCardNumberCard",
                principalTable: "CreditCard",
                principalColumn: "NumberCard",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CreditCard_CreditCardNumberCard",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreditCardNumberCard",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreditCardNumberCard",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CreditCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_UserId",
                table: "CreditCard",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_Users_UserId",
                table: "CreditCard",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
