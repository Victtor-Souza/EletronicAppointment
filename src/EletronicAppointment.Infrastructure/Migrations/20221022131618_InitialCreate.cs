using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EletronicAppointment.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PROJECTS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProjectCategory = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROJECTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USERS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROJECTCONFIG",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Key = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROJECTCONFIG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PROJECTCONFIG_TB_PROJECTS_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TB_PROJECTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_POINTS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Opened = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Closed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AnnotationType = table.Column<int>(type: "integer", nullable: false),
                    Observation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_POINTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_POINTS_TB_PROJECTS_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TB_PROJECTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_POINTS_TB_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USERPROJECTS",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USERPROJECTS", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_TB_USERPROJECTS_TB_PROJECTS_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TB_PROJECTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USERPROJECTS_TB_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_POINTS_ProjectId",
                table: "TB_POINTS",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_POINTS_UserId",
                table: "TB_POINTS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROJECTCONFIG_Key",
                table: "TB_PROJECTCONFIG",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROJECTCONFIG_ProjectId",
                table: "TB_PROJECTCONFIG",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USERPROJECTS_ProjectId",
                table: "TB_USERPROJECTS",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_POINTS");

            migrationBuilder.DropTable(
                name: "TB_PROJECTCONFIG");

            migrationBuilder.DropTable(
                name: "TB_USERPROJECTS");

            migrationBuilder.DropTable(
                name: "TB_PROJECTS");

            migrationBuilder.DropTable(
                name: "TB_USERS");
        }
    }
}
