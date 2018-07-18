using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Migrations
{
    public partial class AddUserIdToAuctionAndBid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Items",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bids",
                maxLength: 450,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bids");
        }
    }
}
