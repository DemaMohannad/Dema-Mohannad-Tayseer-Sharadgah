using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace first_project.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "RequestStates",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStates", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "VacationTypes",
                columns: table => new
                {
                    VacationTypeCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    VacationTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTypes", x => x.VacationTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    PosID = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Reportedtoempnum = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Vacdaysleft = table.Column<int>(type: "int", nullable: false, defaultValue: 24),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepID",
                        column: x => x.DepID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PosID",
                        column: x => x.PosID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReqSubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmpNumber = table.Column<string>(type: "nvarchar(6)", nullable: false),
                    VacTypeCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVacDaye = table.Column<int>(type: "int", nullable: false),
                    RequestStateID = table.Column<int>(type: "int", nullable: false),
                    ApprovedbyEmpNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclinedbyEmpNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VacationTypeCode = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_VacationRequests_Employees_EmpNumber",
                        column: x => x.EmpNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationRequests_RequestStates_RequestStateID",
                        column: x => x.RequestStateID,
                        principalTable: "RequestStates",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationRequests_VacationTypes_VacationTypeCode",
                        column: x => x.VacationTypeCode,
                        principalTable: "VacationTypes",
                        principalColumn: "VacationTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepID",
                table: "Employees",
                column: "DepID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PosID",
                table: "Employees",
                column: "PosID");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_EmpNumber",
                table: "VacationRequests",
                column: "EmpNumber");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_RequestStateID",
                table: "VacationRequests",
                column: "RequestStateID");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_VacationTypeCode",
                table: "VacationRequests",
                column: "VacationTypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "RequestStates");

            migrationBuilder.DropTable(
                name: "VacationTypes");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
