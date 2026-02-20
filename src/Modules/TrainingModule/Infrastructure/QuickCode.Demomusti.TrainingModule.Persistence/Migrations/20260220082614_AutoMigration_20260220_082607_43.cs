using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.Demomusti.TrainingModule.Persistence.Migrations
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
                name: "TRAINING",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COURSE_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TRAINING_TYPE = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRAINING_CATEGORIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING_CATEGORIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEE_TRAININGS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPLOYEE_ID = table.Column<int>(type: "int", nullable: false),
                    TRAINING_ID = table.Column<int>(type: "int", nullable: false),
                    ENROLLMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COMPLETION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GRADE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE_TRAININGS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_TRAININGS_TRAINING_TRAINING_ID",
                        column: x => x.TRAINING_ID,
                        principalTable: "TRAINING",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRAINING_MATERIALS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAINING_ID = table.Column<int>(type: "int", nullable: false),
                    MATERIAL_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MATERIAL_URL = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MATERIAL_FILE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING_MATERIALS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRAINING_MATERIALS_TRAINING_TRAINING_ID",
                        column: x => x.TRAINING_ID,
                        principalTable: "TRAINING",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRAINING_SESSIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAINING_ID = table.Column<int>(type: "int", nullable: false),
                    SESSION_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SESSION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SESSION_LOCATION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING_SESSIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRAINING_SESSIONS_TRAINING_TRAINING_ID",
                        column: x => x.TRAINING_ID,
                        principalTable: "TRAINING",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRAINING_CATEGORY_ASSIGNMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRAINING_ID = table.Column<int>(type: "int", nullable: false),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING_CATEGORY_ASSIGNMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRAINING_CATEGORY_ASSIGNMENTS_TRAINING_CATEGORIES_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "TRAINING_CATEGORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRAINING_CATEGORY_ASSIGNMENTS_TRAINING_TRAINING_ID",
                        column: x => x.TRAINING_ID,
                        principalTable: "TRAINING",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRAINING_FEEDBACKS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMPLOYEE_TRAINING_ID = table.Column<int>(type: "int", nullable: false),
                    FEEDBACK_TEXT = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RATING = table.Column<short>(type: "smallint", nullable: false),
                    FEEDBACK_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINING_FEEDBACKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRAINING_FEEDBACKS_EMPLOYEE_TRAININGS_EMPLOYEE_TRAINING_ID",
                        column: x => x.EMPLOYEE_TRAINING_ID,
                        principalTable: "EMPLOYEE_TRAININGS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_TRAININGS_IsDeleted",
                table: "EMPLOYEE_TRAININGS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEE_TRAININGS_TRAINING_ID",
                table: "EMPLOYEE_TRAININGS",
                column: "TRAINING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_IsDeleted",
                table: "TRAINING",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_CATEGORIES_IsDeleted",
                table: "TRAINING_CATEGORIES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_CATEGORY_ASSIGNMENTS_CATEGORY_ID",
                table: "TRAINING_CATEGORY_ASSIGNMENTS",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_CATEGORY_ASSIGNMENTS_IsDeleted",
                table: "TRAINING_CATEGORY_ASSIGNMENTS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_CATEGORY_ASSIGNMENTS_TRAINING_ID",
                table: "TRAINING_CATEGORY_ASSIGNMENTS",
                column: "TRAINING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_FEEDBACKS_EMPLOYEE_TRAINING_ID",
                table: "TRAINING_FEEDBACKS",
                column: "EMPLOYEE_TRAINING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_FEEDBACKS_IsDeleted",
                table: "TRAINING_FEEDBACKS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_MATERIALS_IsDeleted",
                table: "TRAINING_MATERIALS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_MATERIALS_TRAINING_ID",
                table: "TRAINING_MATERIALS",
                column: "TRAINING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_SESSIONS_IsDeleted",
                table: "TRAINING_SESSIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TRAINING_SESSIONS_TRAINING_ID",
                table: "TRAINING_SESSIONS",
                column: "TRAINING_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "TRAINING_CATEGORY_ASSIGNMENTS");

            migrationBuilder.DropTable(
                name: "TRAINING_FEEDBACKS");

            migrationBuilder.DropTable(
                name: "TRAINING_MATERIALS");

            migrationBuilder.DropTable(
                name: "TRAINING_SESSIONS");

            migrationBuilder.DropTable(
                name: "TRAINING_CATEGORIES");

            migrationBuilder.DropTable(
                name: "EMPLOYEE_TRAININGS");

            migrationBuilder.DropTable(
                name: "TRAINING");
        }
    }
}
