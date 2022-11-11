using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeWorkoutBackend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkSequenceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimatedTimeInMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkSequenceModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceInSequence = table.Column<int>(type: "int", nullable: false),
                    NumberOfTimes = table.Column<int>(type: "int", nullable: false),
                    Seconds = table.Column<int>(type: "int", nullable: false),
                    ExerciseModelId = table.Column<int>(type: "int", nullable: false),
                    HomeworkSequenceModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeworkModel_HomeworkSequenceModel_HomeworkSequenceModelId",
                        column: x => x.HomeworkSequenceModelId,
                        principalTable: "HomeworkSequenceModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkModel_HomeworkSequenceModelId",
                table: "HomeworkModel",
                column: "HomeworkSequenceModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseModel");

            migrationBuilder.DropTable(
                name: "HomeworkModel");

            migrationBuilder.DropTable(
                name: "HomeworkSequenceModel");
        }
    }
}
