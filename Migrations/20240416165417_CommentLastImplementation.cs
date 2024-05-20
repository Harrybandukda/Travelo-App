using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP2139_Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class CommentLastImplementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightComments",
                schema: "Identity",
                columns: table => new
                {
                    FlightCommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightComments", x => x.FlightCommentID);
                    table.ForeignKey(
                        name: "FK_FlightComments_Flights_FlightId",
                        column: x => x.FlightId,
                        principalSchema: "Identity",
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelComments",
                schema: "Identity",
                columns: table => new
                {
                    HotelCommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HotelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelComments", x => x.HotelCommentID);
                    table.ForeignKey(
                        name: "FK_HotelComments_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalSchema: "Identity",
                        principalTable: "Hotels",
                        principalColumn: "HotelsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightComments_FlightId",
                schema: "Identity",
                table: "FlightComments",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelComments_HotelsId",
                schema: "Identity",
                table: "HotelComments",
                column: "HotelsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightComments",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "HotelComments",
                schema: "Identity");
        }
    }
}
