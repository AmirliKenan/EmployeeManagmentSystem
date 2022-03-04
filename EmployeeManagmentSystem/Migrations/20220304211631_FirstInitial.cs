using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagmentSystem.Migrations
{
    public partial class FirstInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(9223))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8251)),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(9360), "IT" },
                    { 2, new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(9362), "HR" },
                    { 3, new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(9363), "Sales" },
                    { 4, new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(9364), "Economics" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "CreateDate", "DepartmentId", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8523), 1, "Kenan", "Amirli" },
                    { 2, new DateTime(2000, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8526), 2, "Rufat", "Qedirov" },
                    { 3, new DateTime(2001, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8527), 3, "Fazil", "Amirli" },
                    { 4, new DateTime(1992, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8529), 4, "Qara", "Humbatov" },
                    { 5, new DateTime(2003, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8530), 4, "Nurlan", "Ramazanov" },
                    { 6, new DateTime(1998, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8532), 2, "Vasif", "Hasanzadeh" },
                    { 7, new DateTime(2000, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8533), 2, "Turqay", "Abdullayef" },
                    { 8, new DateTime(2004, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8534), 1, "Turqay", "Osmanli" },
                    { 9, new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8535), 1, "Ehmed", "Qarayev" },
                    { 10, new DateTime(2000, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8537), 1, "Qedir", "Babayev" },
                    { 11, new DateTime(2007, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 5, 1, 16, 30, 830, DateTimeKind.Local).AddTicks(8538), 3, "Hebib", "Amirli" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
