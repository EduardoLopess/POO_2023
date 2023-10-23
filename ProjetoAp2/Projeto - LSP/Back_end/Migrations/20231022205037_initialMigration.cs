using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: true),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoInstituto = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rua = table.Column<string>(type: "TEXT", nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    Complemento = table.Column<string>(type: "TEXT", nullable: true),
                    CEP = table.Column<int>(type: "INTEGER", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PontoDoacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Institutos_InstitutoId",
                        column: x => x.InstitutoId,
                        principalTable: "Institutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voluntariados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntariados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voluntariados_Institutos_InstitutoId",
                        column: x => x.InstitutoId,
                        principalTable: "Institutos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PontoDoacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false),
                    InstitutoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoDoacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontoDoacao_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PontoDoacao_Institutos_InstitutoId",
                        column: x => x.InstitutoId,
                        principalTable: "Institutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariadoBeneficios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    VoluntariadoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariadoBeneficios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoluntariadoBeneficios_Voluntariados_VoluntariadoId",
                        column: x => x.VoluntariadoId,
                        principalTable: "Voluntariados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoluntariadoResponsabilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    VoluntariadoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoluntariadoResponsabilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoluntariadoResponsabilidades_Voluntariados_VoluntariadoId",
                        column: x => x.VoluntariadoId,
                        principalTable: "Voluntariados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriaisDoacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    InstitutoId = table.Column<int>(type: "INTEGER", nullable: true),
                    TipoMaterial = table.Column<int>(type: "INTEGER", nullable: false),
                    PontoDoacaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrioridadeDoacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaisDoacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriaisDoacao_Institutos_InstitutoId",
                        column: x => x.InstitutoId,
                        principalTable: "Institutos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MateriaisDoacao_PontoDoacao_PontoDoacaoId",
                        column: x => x.PontoDoacaoId,
                        principalTable: "PontoDoacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_InstitutoId",
                table: "Enderecos",
                column: "InstitutoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MateriaisDoacao_InstitutoId",
                table: "MateriaisDoacao",
                column: "InstitutoId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaisDoacao_PontoDoacaoId",
                table: "MateriaisDoacao",
                column: "PontoDoacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PontoDoacao_EnderecoId",
                table: "PontoDoacao",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PontoDoacao_InstitutoId",
                table: "PontoDoacao",
                column: "InstitutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariadoBeneficios_VoluntariadoId",
                table: "VoluntariadoBeneficios",
                column: "VoluntariadoId");

            migrationBuilder.CreateIndex(
                name: "IX_VoluntariadoResponsabilidades_VoluntariadoId",
                table: "VoluntariadoResponsabilidades",
                column: "VoluntariadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Voluntariados_InstitutoId",
                table: "Voluntariados",
                column: "InstitutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaisDoacao");

            migrationBuilder.DropTable(
                name: "VoluntariadoBeneficios");

            migrationBuilder.DropTable(
                name: "VoluntariadoResponsabilidades");

            migrationBuilder.DropTable(
                name: "PontoDoacao");

            migrationBuilder.DropTable(
                name: "Voluntariados");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Institutos");
        }
    }
}
