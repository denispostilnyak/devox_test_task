using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevoxTestTask.DAL.Migrations
{
    public partial class AddDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActivityTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "regular" },
                    { 2, "overtime" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthday", "Name", "Sex" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis", "m" },
                    { 2, new DateTime(2001, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anton", "m" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "DateEnd", "DateStart", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 11, 0, 51, 2, 881, DateTimeKind.Local).AddTicks(869), "First" },
                    { 2, new DateTime(2020, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 11, 0, 51, 2, 892, DateTimeKind.Local).AddTicks(1893), "Second" },
                    { 3, new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 11, 0, 51, 2, 892, DateTimeKind.Local).AddTicks(2097), "Third" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "engineer" },
                    { 2, "analyst" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActivityTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
