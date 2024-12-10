using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Reservation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_AspNetUsers_GuestId1",
                table: "Reserve");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Rooms_RoomId",
                table: "Reserve");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserve",
                table: "Reserve");

            migrationBuilder.RenameTable(
                name: "Reserve",
                newName: "Reserves");

            migrationBuilder.RenameIndex(
                name: "IX_Reserve_RoomId",
                table: "Reserves",
                newName: "IX_Reserves_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserve_GuestId1",
                table: "Reserves",
                newName: "IX_Reserves_GuestId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserves",
                table: "Reserves",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_AspNetUsers_GuestId1",
                table: "Reserves",
                column: "GuestId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Rooms_RoomId",
                table: "Reserves",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_AspNetUsers_GuestId1",
                table: "Reserves");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Rooms_RoomId",
                table: "Reserves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reserves",
                table: "Reserves");

            migrationBuilder.RenameTable(
                name: "Reserves",
                newName: "Reserve");

            migrationBuilder.RenameIndex(
                name: "IX_Reserves_RoomId",
                table: "Reserve",
                newName: "IX_Reserve_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserves_GuestId1",
                table: "Reserve",
                newName: "IX_Reserve_GuestId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reserve",
                table: "Reserve",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_AspNetUsers_GuestId1",
                table: "Reserve",
                column: "GuestId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Rooms_RoomId",
                table: "Reserve",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
