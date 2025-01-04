using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace c___Api_Example.Migrations
{
    /// <inheritdoc />
    public partial class IbpvDabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Senha = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TokenContribuicao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RGEmissor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RGnumero = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Telefone_pais = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TelefoneDdd = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TelefoneNumero = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BairroEdereco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CidadeEndereco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RuaEdereco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CepEndereco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NumeroEndereco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UfEndereco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Data_nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Rule = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gasto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UrlComprovante = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NumeroFiscal = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IdCaixa = table.Column<int>(type: "integer", nullable: false),
                    CaixaModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gasto_Caixa_CaixaModelId",
                        column: x => x.CaixaModelId,
                        principalTable: "Caixa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gasto_Caixa_IdCaixa",
                        column: x => x.IdCaixa,
                        principalTable: "Caixa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contribuicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UrlEnvelope = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IdCaixa = table.Column<int>(type: "integer", nullable: false),
                    IdMembro = table.Column<int>(type: "integer", nullable: true),
                    CaixaModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contribuicao_Caixa_CaixaModelId",
                        column: x => x.CaixaModelId,
                        principalTable: "Caixa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contribuicao_Caixa_IdCaixa",
                        column: x => x.IdCaixa,
                        principalTable: "Caixa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contribuicao_Usuarios_IdMembro",
                        column: x => x.IdMembro,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contribuicao_CaixaModelId",
                table: "Contribuicao",
                column: "CaixaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuicao_IdCaixa",
                table: "Contribuicao",
                column: "IdCaixa");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuicao_IdMembro",
                table: "Contribuicao",
                column: "IdMembro");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_CaixaModelId",
                table: "Gasto",
                column: "CaixaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_IdCaixa",
                table: "Gasto",
                column: "IdCaixa");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TokenContribuicao",
                table: "Usuarios",
                column: "TokenContribuicao",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contribuicao");

            migrationBuilder.DropTable(
                name: "Gasto");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Caixa");
        }
    }
}
