using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.Demomusti.CandidateTrackingModule.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AutoMigration_20260220_082607_43 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDIT_LOGS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ENTITY_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ENTITY_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ACTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_ID = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    USER_GROUP = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TIMESTAMP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OLD_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    NEW_VALUES = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CHANGED_COLUMNS = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IS_CHANGED = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CHANGE_SUMMARY = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IP_ADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_AGENT = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CORRELATION_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IS_SUCCESS = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ERROR_MESSAGE = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    HASH = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDIT_LOGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CANDIDATES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RESUME = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    APPLICATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    APPLICATION_STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    AVATAR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CANDIDATES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SOURCE_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SOURCE_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOURCE_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "APPLICATION_NOTES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CANDIDATE_ID = table.Column<int>(type: "int", nullable: false),
                    NOTE = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICATION_NOTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPLICATION_NOTES_CANDIDATES_CANDIDATE_ID",
                        column: x => x.CANDIDATE_ID,
                        principalTable: "CANDIDATES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXPERIENCES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CANDIDATE_ID = table.Column<int>(type: "int", nullable: false),
                    COMPANY_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    JOB_TITLE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPERIENCES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXPERIENCES_CANDIDATES_CANDIDATE_ID",
                        column: x => x.CANDIDATE_ID,
                        principalTable: "CANDIDATES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QUALIFICATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CANDIDATE_ID = table.Column<int>(type: "int", nullable: false),
                    DEGREE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UNIVERSITY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GRADUATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUALIFICATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QUALIFICATIONS_CANDIDATES_CANDIDATE_ID",
                        column: x => x.CANDIDATE_ID,
                        principalTable: "CANDIDATES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SKILLS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CANDIDATE_ID = table.Column<int>(type: "int", nullable: false),
                    SKILL_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PROFICIENCY = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKILLS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SKILLS_CANDIDATES_CANDIDATE_ID",
                        column: x => x.CANDIDATE_ID,
                        principalTable: "CANDIDATES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CANDIDATE_SOURCES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CANDIDATE_ID = table.Column<int>(type: "int", nullable: false),
                    SOURCE_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CANDIDATE_SOURCES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CANDIDATE_SOURCES_CANDIDATES_CANDIDATE_ID",
                        column: x => x.CANDIDATE_ID,
                        principalTable: "CANDIDATES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CANDIDATE_SOURCES_SOURCE_TYPES_SOURCE_TYPE_ID",
                        column: x => x.SOURCE_TYPE_ID,
                        principalTable: "SOURCE_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APPLICATION_NOTES_CANDIDATE_ID",
                table: "APPLICATION_NOTES",
                column: "CANDIDATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPLICATION_NOTES_IsDeleted",
                table: "APPLICATION_NOTES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATE_SOURCES_CANDIDATE_ID",
                table: "CANDIDATE_SOURCES",
                column: "CANDIDATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATE_SOURCES_IsDeleted",
                table: "CANDIDATE_SOURCES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATE_SOURCES_SOURCE_TYPE_ID",
                table: "CANDIDATE_SOURCES",
                column: "SOURCE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATES_IsDeleted",
                table: "CANDIDATES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_EXPERIENCES_CANDIDATE_ID",
                table: "EXPERIENCES",
                column: "CANDIDATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXPERIENCES_IsDeleted",
                table: "EXPERIENCES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_QUALIFICATIONS_CANDIDATE_ID",
                table: "QUALIFICATIONS",
                column: "CANDIDATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_QUALIFICATIONS_IsDeleted",
                table: "QUALIFICATIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SKILLS_CANDIDATE_ID",
                table: "SKILLS",
                column: "CANDIDATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SKILLS_IsDeleted",
                table: "SKILLS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_SOURCE_TYPES_IsDeleted",
                table: "SOURCE_TYPES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPLICATION_NOTES");

            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "CANDIDATE_SOURCES");

            migrationBuilder.DropTable(
                name: "EXPERIENCES");

            migrationBuilder.DropTable(
                name: "QUALIFICATIONS");

            migrationBuilder.DropTable(
                name: "SKILLS");

            migrationBuilder.DropTable(
                name: "SOURCE_TYPES");

            migrationBuilder.DropTable(
                name: "CANDIDATES");
        }
    }
}
