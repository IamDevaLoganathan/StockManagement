using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddPrimarykey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StockDomainId",
                table: "WatchLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WatchLists_StockDomainId",
                table: "WatchLists",
                column: "StockDomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchLists_Stocks_StockDomainId",
                table: "WatchLists",
                column: "StockDomainId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchLists_Stocks_StockDomainId",
                table: "WatchLists");

            migrationBuilder.DropIndex(
                name: "IX_WatchLists_StockDomainId",
                table: "WatchLists");

            migrationBuilder.DropColumn(
                name: "StockDomainId",
                table: "WatchLists");
        }
    }
}
