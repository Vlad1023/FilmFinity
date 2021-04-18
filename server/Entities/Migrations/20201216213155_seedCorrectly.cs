using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class seedCorrectly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsLists_Actors_ActorId",
                table: "ActorsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsLists_Movies_MovieId",
                table: "ActorsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CelebrityJobTitles_Celebrities_CelebrityId",
                table: "CelebrityJobTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_CelebrityJobTitles_JobTitles_JobTitleId",
                table: "CelebrityJobTitles");

            migrationBuilder.UpdateData(
                table: "Celebrities",
                keyColumn: "CelebrityId",
                keyValue: -9,
                column: "ImageSource",
                value: "StaticFiles/images/9.jpg");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsLists_Actors_ActorId",
                table: "ActorsLists",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsLists_Movies_MovieId",
                table: "ActorsLists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelebrityJobTitles_Celebrities_CelebrityId",
                table: "CelebrityJobTitles",
                column: "CelebrityId",
                principalTable: "Celebrities",
                principalColumn: "CelebrityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CelebrityJobTitles_JobTitles_JobTitleId",
                table: "CelebrityJobTitles",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "JobTitleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsLists_Actors_ActorId",
                table: "ActorsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsLists_Movies_MovieId",
                table: "ActorsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CelebrityJobTitles_Celebrities_CelebrityId",
                table: "CelebrityJobTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_CelebrityJobTitles_JobTitles_JobTitleId",
                table: "CelebrityJobTitles");

            migrationBuilder.UpdateData(
                table: "Celebrities",
                keyColumn: "CelebrityId",
                keyValue: -9,
                column: "ImageSource",
                value: "StaticFiles/images/9.png");

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "Favorites",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 510, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 512, DateTimeKind.Local).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 512, DateTimeKind.Local).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 512, DateTimeKind.Local).AddTicks(6777));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 513, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(932));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishTime",
                value: new DateTime(2020, 12, 16, 23, 2, 22, 514, DateTimeKind.Local).AddTicks(1059));

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsLists_Actors_ActorId",
                table: "ActorsLists",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsLists_Movies_MovieId",
                table: "ActorsLists",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CelebrityJobTitles_Celebrities_CelebrityId",
                table: "CelebrityJobTitles",
                column: "CelebrityId",
                principalTable: "Celebrities",
                principalColumn: "CelebrityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CelebrityJobTitles_JobTitles_JobTitleId",
                table: "CelebrityJobTitles",
                column: "JobTitleId",
                principalTable: "JobTitles",
                principalColumn: "JobTitleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
