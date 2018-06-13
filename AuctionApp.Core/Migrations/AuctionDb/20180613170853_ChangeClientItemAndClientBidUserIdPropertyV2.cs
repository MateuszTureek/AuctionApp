using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionApp.Core.Migrations.AuctionDb
{
    public partial class ChangeClientItemAndClientBidUserIdPropertyV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClientItem",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClientBid",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClientItem",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ClientBid",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);
        }
    }
}
