using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Migrations
{
    public partial class ItemAddUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Items");
        }
    }
}
