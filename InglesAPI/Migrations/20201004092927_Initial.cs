using Microsoft.EntityFrameworkCore.Migrations;

namespace InglesAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capitulos",
                columns: table => new
                {
                    CapituloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapituloNumber = table.Column<string>(nullable: false),
                    CapituloNome = table.Column<string>(nullable: false),
                    CapituloTeoria = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulos", x => x.CapituloId);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    ExercicioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExercicioNumber = table.Column<string>(nullable: false),
                    ExercicioTexto = table.Column<string>(nullable: true),
                    ExercicioImagePath = table.Column<string>(nullable: true),
                    CapituloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.ExercicioId);
                    table.ForeignKey(
                        name: "FK_Exercicios_Capitulos_CapituloId",
                        column: x => x.CapituloId,
                        principalTable: "Capitulos",
                        principalColumn: "CapituloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questoes",
                columns: table => new
                {
                    QuestaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestaoNumber = table.Column<string>(nullable: false),
                    QuestaoTexto = table.Column<string>(nullable: false),
                    ExercicioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.QuestaoId);
                    table.ForeignKey(
                        name: "FK_Questoes_Exercicios_ExercicioId",
                        column: x => x.ExercicioId,
                        principalTable: "Exercicios",
                        principalColumn: "ExercicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_CapituloId",
                table: "Exercicios",
                column: "CapituloId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_ExercicioId",
                table: "Questoes",
                column: "ExercicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Capitulos");
        }
    }
}
