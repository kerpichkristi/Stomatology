using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Stomatology.Migrations
{
    public partial class InitialRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DentistsTB",
                columns: table => new
                {
                    DentistID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DentistName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DentistsTB", x => x.DentistID);
                });

            migrationBuilder.CreateTable(
                name: "ProceduresTB",
                columns: table => new
                {
                    ProcedureID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProcedureName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Info = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DentistID = table.Column<int>(type: "integer", nullable: true),
                    Img = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProceduresTB", x => x.ProcedureID);
                    table.ForeignKey(
                        name: "FK_ProceduresTB_DentistsTB_DentistID",
                        column: x => x.DentistID,
                        principalTable: "DentistsTB",
                        principalColumn: "DentistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecordsTB",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Info = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    DentistID = table.Column<int>(type: "integer", nullable: true),
                    ProcedureID = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Subscribe = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordsTB", x => x.RecordID);
                    table.ForeignKey(
                        name: "FK_RecordsTB_DentistsTB_DentistID",
                        column: x => x.DentistID,
                        principalTable: "DentistsTB",
                        principalColumn: "DentistID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecordsTB_ProceduresTB_ProcedureID",
                        column: x => x.ProcedureID,
                        principalTable: "ProceduresTB",
                        principalColumn: "ProcedureID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProceduresTB_DentistID",
                table: "ProceduresTB",
                column: "DentistID");

            migrationBuilder.CreateIndex(
                name: "IX_RecordsTB_DentistID",
                table: "RecordsTB",
                column: "DentistID");

            migrationBuilder.CreateIndex(
                name: "IX_RecordsTB_ProcedureID",
                table: "RecordsTB",
                column: "ProcedureID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordsTB");

            migrationBuilder.DropTable(
                name: "ProceduresTB");

            migrationBuilder.DropTable(
                name: "DentistsTB");
        }
    }
}
