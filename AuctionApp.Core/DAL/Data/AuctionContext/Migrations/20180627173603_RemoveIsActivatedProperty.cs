using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionApp.Core.DAL.Data.AuctionContext.Migrations
{
    public partial class RemoveIsActivatedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activated",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activated",
                table: "Items",
                nullable: false,
                defaultValue: false);
        }
    }
}
