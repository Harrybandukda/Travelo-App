using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2139_Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class CommentsImplementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListingComments",
                schema: "Identity",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    HotelsId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingComments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_ListingComments_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "Identity",
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListingComments_Flights_FlightId",
                        column: x => x.FlightId,
                        principalSchema: "Identity",
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListingComments_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalSchema: "Identity",
                        principalTable: "Hotels",
                        principalColumn: "HotelsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListingComments_CarId",
                schema: "Identity",
                table: "ListingComments",
                column: "CarId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingComments",
                schema: "Identity");
        }
    }
}
