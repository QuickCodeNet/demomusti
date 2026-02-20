using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickCode.Demomusti.InterviewModule.Persistence.Migrations
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
                name: "INTERVIEW_FEEDBACK_QUESTIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QUESTION_TEXT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    QUESTION_TYPE = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVIEW_FEEDBACK_QUESTIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INTERVIEWERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LAST_NAME = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEPARTMENT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AVATAR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVIEWERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INTERVIEWS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CANDIDATE_ID = table.Column<int>(type: "int", nullable: false),
                    INTERVIEWER_ID = table.Column<int>(type: "int", nullable: false),
                    INTERVIEW_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    INTERVIEW_TYPE = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    INTERVIEW_STATUS = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    FEEDBACK = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RATING = table.Column<short>(type: "smallint", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVIEWS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INTERVIEWS_INTERVIEWERS_INTERVIEWER_ID",
                        column: x => x.INTERVIEWER_ID,
                        principalTable: "INTERVIEWERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INTERVIEW_FEEDBACK_ANSWERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INTERVIEW_ID = table.Column<int>(type: "int", nullable: false),
                    QUESTION_ID = table.Column<int>(type: "int", nullable: false),
                    ANSWER_TEXT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ANSWER_RATING = table.Column<short>(type: "smallint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVIEW_FEEDBACK_ANSWERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INTERVIEW_FEEDBACK_ANSWERS_INTERVIEWS_INTERVIEW_ID",
                        column: x => x.INTERVIEW_ID,
                        principalTable: "INTERVIEWS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INTERVIEW_FEEDBACK_ANSWERS_INTERVIEW_FEEDBACK_QUESTIONS_QUESTION_ID",
                        column: x => x.QUESTION_ID,
                        principalTable: "INTERVIEW_FEEDBACK_QUESTIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INTERVIEW_NOTES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INTERVIEW_ID = table.Column<int>(type: "int", nullable: false),
                    NOTE_TEXT = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVIEW_NOTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INTERVIEW_NOTES_INTERVIEWS_INTERVIEW_ID",
                        column: x => x.INTERVIEW_ID,
                        principalTable: "INTERVIEWS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INTERVIEW_SCHEDULES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INTERVIEW_ID = table.Column<int>(type: "int", nullable: false),
                    SCHEDULED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROOM_NUMBER = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTERVIEW_SCHEDULES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INTERVIEW_SCHEDULES_INTERVIEWS_INTERVIEW_ID",
                        column: x => x.INTERVIEW_ID,
                        principalTable: "INTERVIEWS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEW_FEEDBACK_ANSWERS_INTERVIEW_ID",
                table: "INTERVIEW_FEEDBACK_ANSWERS",
                column: "INTERVIEW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEW_FEEDBACK_ANSWERS_IsDeleted",
                table: "INTERVIEW_FEEDBACK_ANSWERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEW_FEEDBACK_ANSWERS_QUESTION_ID",
                table: "INTERVIEW_FEEDBACK_ANSWERS",
                column: "QUESTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEW_FEEDBACK_QUESTIONS_IsDeleted",
                table: "INTERVIEW_FEEDBACK_QUESTIONS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEW_NOTES_INTERVIEW_ID",
                table: "INTERVIEW_NOTES",
                column: "INTERVIEW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEW_NOTES_IsDeleted",
                table: "INTERVIEW_NOTES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEW_SCHEDULES_INTERVIEW_ID",
                table: "INTERVIEW_SCHEDULES",
                column: "INTERVIEW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEW_SCHEDULES_IsDeleted",
                table: "INTERVIEW_SCHEDULES",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEWERS_IsDeleted",
                table: "INTERVIEWERS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEWS_INTERVIEWER_ID",
                table: "INTERVIEWS",
                column: "INTERVIEWER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INTERVIEWS_IsDeleted",
                table: "INTERVIEWS",
                column: "IsDeleted",
                filter: "IsDeleted = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDIT_LOGS");

            migrationBuilder.DropTable(
                name: "INTERVIEW_FEEDBACK_ANSWERS");

            migrationBuilder.DropTable(
                name: "INTERVIEW_NOTES");

            migrationBuilder.DropTable(
                name: "INTERVIEW_SCHEDULES");

            migrationBuilder.DropTable(
                name: "INTERVIEW_FEEDBACK_QUESTIONS");

            migrationBuilder.DropTable(
                name: "INTERVIEWS");

            migrationBuilder.DropTable(
                name: "INTERVIEWERS");
        }
    }
}
