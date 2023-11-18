using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manero.Migrations
{
    /// <inheritdoc />
    public partial class AddedDbSetWishList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListEntity_AspNetUsers_UserId",
                table: "WishListEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListEntity",
                table: "WishListEntity");

            migrationBuilder.RenameTable(
                name: "WishListEntity",
                newName: "WishLists");

            migrationBuilder.RenameIndex(
                name: "IX_WishListEntity_UserId",
                table: "WishLists",
                newName: "IX_WishLists_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetUsers_UserId",
                table: "WishLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetUsers_UserId",
                table: "WishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists");

            migrationBuilder.RenameTable(
                name: "WishLists",
                newName: "WishListEntity");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_UserId",
                table: "WishListEntity",
                newName: "IX_WishListEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListEntity",
                table: "WishListEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListEntity_AspNetUsers_UserId",
                table: "WishListEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
