using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevoxTestTask.DAL.Migrations
{
    public partial class AddActivityEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    ActivityTypeId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityTypeId", "Date", "Duration", "EmployeeId", "Name", "ProjectId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "FirstActivity", 1, 1 },
                    { 2, 2, new DateTime(2020, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, "SecondActivity", 2, 2 },
                    { 3, 1, new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "ThirdActivity", 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateStart",
                value: new DateTime(2020, 8, 11, 12, 16, 29, 776, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateStart",
                value: new DateTime(2020, 8, 11, 12, 16, 29, 789, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateStart",
                value: new DateTime(2020, 8, 11, 12, 16, 29, 789, DateTimeKind.Local).AddTicks(9467));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateStart",
                value: new DateTime(2020, 8, 11, 0, 51, 2, 881, DateTimeKind.Local).AddTicks(869));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateStart",
                value: new DateTime(2020, 8, 11, 0, 51, 2, 892, DateTimeKind.Local).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateStart",
                value: new DateTime(2020, 8, 11, 0, 51, 2, 892, DateTimeKind.Local).AddTicks(2097));
        }
    }
}
