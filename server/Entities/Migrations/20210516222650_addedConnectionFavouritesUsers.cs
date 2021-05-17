using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class addedConnectionFavouritesUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Favorites",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedTime", "UserId" },
                values: new object[] { new DateTime(2021, 5, 17, 1, 26, 50, 9, DateTimeKind.Local).AddTicks(5760), 1 });

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedTime", "UserId" },
                values: new object[] { new DateTime(2021, 5, 17, 1, 26, 50, 9, DateTimeKind.Local).AddTicks(6213), 1 });

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedTime", "UserId" },
                values: new object[] { new DateTime(2021, 5, 17, 1, 26, 50, 9, DateTimeKind.Local).AddTicks(6232), 1 });

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 5, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 7, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 7, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 7, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 8, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 9, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 9, DateTimeKind.Local).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 9, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 9, DateTimeKind.Local).AddTicks(1805));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishTime",
                value: new DateTime(2021, 5, 17, 1, 26, 50, 9, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favorites");

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 729, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 729, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 729, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 725, DateTimeKind.Local).AddTicks(7717));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 727, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 728, DateTimeKind.Local).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 728, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 729, DateTimeKind.Local).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 729, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 729, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 729, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 729, DateTimeKind.Local).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 31, 54, 729, DateTimeKind.Local).AddTicks(2302));
        }
    }
}
