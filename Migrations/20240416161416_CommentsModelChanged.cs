using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2139_Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class CommentsModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingComments_Flights_FlightId",
                schema: "Identity",
                table: "ListingComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingComments_Hotels_HotelsId",
                schema: "Identity",
                table: "ListingComments");

            migrationBuilder.DropIndex(
                name: "IX_ListingComments_FlightId",
                schema: "Identity",
                table: "ListingComments");

            migrationBuilder.DropIndex(
                name: "IX_ListingComments_HotelsId",
                schema: "Identity",
                table: "ListingComments");

            migrationBuilder.DropColumn(
                name: "FlightId",
                schema: "Identity",
                table: "ListingComments");

            migrationBuilder.DropColumn(
                name: "HotelsId",
                schema: "Identity",
                table: "ListingComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                schema: "Identity",
                table: "ListingComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HotelsId",
                schema: "Identity",
                table: "ListingComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ListingComments_FlightId",
                schema: "Identity",
                table: "ListingComments",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingComments_HotelsId",
                schema: "Identity",
                table: "ListingComments",
                column: "HotelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingComments_Flights_FlightId",
                schema: "Identity",
                table: "ListingComments",
                column: "FlightId",
                principalSchema: "Identity",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingComments_Hotels_HotelsId",
                schema: "Identity",
                table: "ListingComments",
                column: "HotelsId",
                principalSchema: "Identity",
                principalTable: "Hotels",
                principalColumn: "HotelsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
