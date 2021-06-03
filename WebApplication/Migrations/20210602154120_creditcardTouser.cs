using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class creditcardTouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
