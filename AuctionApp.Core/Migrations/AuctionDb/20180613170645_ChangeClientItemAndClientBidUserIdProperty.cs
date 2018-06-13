using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionApp.Core.Migrations.AuctionDb
{
    public partial class ChangeClientItemAndClientBidUserIdProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClientItem",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClientBid",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClientItem",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClientBid",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);
        }
    }
}
