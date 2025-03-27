using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurisCodeTest.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceWorkingTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkingTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceWorkingTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceWorkingTime_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceWorkingTime_WorkingTime_WorkingTimeId",
                        column: x => x.WorkingTimeId,
                        principalTable: "WorkingTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ServiceWorkingTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserve_ServiceWorkingTime_ServiceWorkingTimeId",
                        column: x => x.ServiceWorkingTimeId,
                        principalTable: "ServiceWorkingTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00ca27f5-d926-4d35-b120-5a9d43277e0b"), "Servicio 3" },
                    { new Guid("07421f5a-3c0e-4dd4-8bcb-42ef8018e661"), "Servicio 2" },
                    { new Guid("753abd1c-ede5-4d56-aa09-083b9d266165"), "Servicio 4" },
                    { new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"), "Servicio 1" },
                    { new Guid("cf4ac3bb-9022-4dc3-9b29-6adaefdb6180"), "Servicio 5" }
                });

            migrationBuilder.InsertData(
                table: "WorkingTime",
                columns: new[] { "Id", "Time" },
                values: new object[,]
                {
                    { new Guid("164ff347-a959-476f-b0aa-2e36132b7b27"), new TimeOnly(12, 0, 0) },
                    { new Guid("8bd023b7-4f09-4823-a2a7-d0d45df7223c"), new TimeOnly(11, 0, 0) },
                    { new Guid("a7996de4-4874-4998-80fc-5b34570ad802"), new TimeOnly(8, 0, 0) },
                    { new Guid("b07906ec-c486-4aaa-b56e-e318a557afcb"), new TimeOnly(10, 0, 0) },
                    { new Guid("faa3f59a-1915-42aa-a703-dab4543afcf7"), new TimeOnly(9, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "ServiceWorkingTime",
                columns: new[] { "Id", "ServiceId", "WorkingTimeId" },
                values: new object[,]
                {
                    { new Guid("08732dd0-e9e4-4546-8739-c48f6560cfb4"), new Guid("753abd1c-ede5-4d56-aa09-083b9d266165"), new Guid("8bd023b7-4f09-4823-a2a7-d0d45df7223c") },
                    { new Guid("28a48cde-6f43-40c2-ad4d-b1ae806c368c"), new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"), new Guid("faa3f59a-1915-42aa-a703-dab4543afcf7") },
                    { new Guid("4332ca43-c21d-44b6-ac55-e0e236c2e628"), new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"), new Guid("164ff347-a959-476f-b0aa-2e36132b7b27") },
                    { new Guid("4b4dce03-5d7d-4234-8aae-7b757ec0bffe"), new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"), new Guid("a7996de4-4874-4998-80fc-5b34570ad802") },
                    { new Guid("845137c8-a5b0-4612-8b5e-89a525ef6b83"), new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"), new Guid("b07906ec-c486-4aaa-b56e-e318a557afcb") },
                    { new Guid("b5ae81b6-194e-43f7-adf0-acae019e54cf"), new Guid("753abd1c-ede5-4d56-aa09-083b9d266165"), new Guid("faa3f59a-1915-42aa-a703-dab4543afcf7") },
                    { new Guid("b5b9d36e-a8ef-459d-8e7a-c0ae6915ce92"), new Guid("07421f5a-3c0e-4dd4-8bcb-42ef8018e661"), new Guid("b07906ec-c486-4aaa-b56e-e318a557afcb") },
                    { new Guid("b82b553f-9b82-452c-9f5f-31a782ce0647"), new Guid("07421f5a-3c0e-4dd4-8bcb-42ef8018e661"), new Guid("164ff347-a959-476f-b0aa-2e36132b7b27") },
                    { new Guid("bcae88c7-14b8-423a-9c10-6244365337d7"), new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"), new Guid("8bd023b7-4f09-4823-a2a7-d0d45df7223c") },
                    { new Guid("e515ccd5-5364-44c3-ae10-2d09ac7f8ab3"), new Guid("07421f5a-3c0e-4dd4-8bcb-42ef8018e661"), new Guid("a7996de4-4874-4998-80fc-5b34570ad802") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_Date_ServiceWorkingTimeId",
                table: "Reserve",
                columns: new[] { "Date", "ServiceWorkingTimeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_ServiceWorkingTimeId",
                table: "Reserve",
                column: "ServiceWorkingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceWorkingTime_ServiceId_WorkingTimeId",
                table: "ServiceWorkingTime",
                columns: new[] { "ServiceId", "WorkingTimeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceWorkingTime_WorkingTimeId",
                table: "ServiceWorkingTime",
                column: "WorkingTimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserve");

            migrationBuilder.DropTable(
                name: "ServiceWorkingTime");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "WorkingTime");
        }
    }
}
