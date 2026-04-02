using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpertZonez.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationCreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    custId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    custPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    custEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    custPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custRole = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    custCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.custId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    serviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    serviceDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    serviceIcon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.serviceId);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    workerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    workerPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    workerCNIC = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    workerExperienceYears = table.Column<int>(type: "int", nullable: false),
                    workerAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    didWorkerIsApproved = table.Column<bool>(type: "bit", nullable: false),
                    didWorkerIsActive = table.Column<bool>(type: "bit", nullable: false),
                    didWorkerIsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    workerCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.workerId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    serviceRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serviceId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true),
                    custName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    custPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    custLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceDateAndTIme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    requestStatus = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.serviceRequestId);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Customers_userId",
                        column: x => x.userId,
                        principalTable: "Customers",
                        principalColumn: "custId");
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "serviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerServices",
                columns: table => new
                {
                    workerId = table.Column<int>(type: "int", nullable: false),
                    serviceId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerServices", x => new { x.workerId, x.serviceId });
                    table.ForeignKey(
                        name: "FK_WorkerServices_Services_serviceId",
                        column: x => x.serviceId,
                        principalTable: "Services",
                        principalColumn: "serviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerServices_Workers_workerId",
                        column: x => x.workerId,
                        principalTable: "Workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    assignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestId = table.Column<int>(type: "int", nullable: false),
                    workerId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Pending"),
                    assignedByAdminId = table.Column<int>(type: "int", nullable: false),
                    assignedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    adminNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.assignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_ServiceRequests_requestId",
                        column: x => x.requestId,
                        principalTable: "ServiceRequests",
                        principalColumn: "serviceRequestId");
                    table.ForeignKey(
                        name: "FK_Assignments_Workers_workerId",
                        column: x => x.workerId,
                        principalTable: "Workers",
                        principalColumn: "workerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_requestId",
                table: "Assignments",
                column: "requestId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_workerId",
                table: "Assignments",
                column: "workerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_serviceId",
                table: "ServiceRequests",
                column: "serviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_userId",
                table: "ServiceRequests",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerServices_serviceId",
                table: "WorkerServices",
                column: "serviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "WorkerServices");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
