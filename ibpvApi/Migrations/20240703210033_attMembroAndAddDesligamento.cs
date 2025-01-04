using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace c___Api_Example.Migrations
{
    /// <inheritdoc />
    public partial class attMembroAndAddDesligamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gasto_Caixa_CaixaModelId",
                table: "Gasto");

            migrationBuilder.DropForeignKey(
                name: "FK_Gasto_Caixa_IdCaixa",
                table: "Gasto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gasto",
                table: "Gasto");

            migrationBuilder.RenameTable(
                name: "Gasto",
                newName: "GastoModel");

            migrationBuilder.RenameIndex(
                name: "IX_Gasto_IdCaixa",
                table: "GastoModel",
                newName: "IX_GastoModel_IdCaixa");

            migrationBuilder.RenameIndex(
                name: "IX_Gasto_CaixaModelId",
                table: "GastoModel",
                newName: "IX_GastoModel_CaixaModelId");

            migrationBuilder.AddColumn<string>(
                name: "ComplementoEndereco",
                table: "Usuarios",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataBatismo",
                table: "Usuarios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "estadoCivil",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "filhos",
                table: "Usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "igrejaBatismo",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pastorBatismo",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "profissão",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GastoModel",
                table: "GastoModel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DesligamentoModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    idMembro = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesligamentoModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_DesligamentoModel_Usuarios_idMembro",
                        column: x => x.idMembro,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesligamentoModel_idMembro",
                table: "DesligamentoModel",
                column: "idMembro");

            migrationBuilder.AddForeignKey(
                name: "FK_GastoModel_Caixa_CaixaModelId",
                table: "GastoModel",
                column: "CaixaModelId",
                principalTable: "Caixa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GastoModel_Caixa_IdCaixa",
                table: "GastoModel",
                column: "IdCaixa",
                principalTable: "Caixa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GastoModel_Caixa_CaixaModelId",
                table: "GastoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GastoModel_Caixa_IdCaixa",
                table: "GastoModel");

            migrationBuilder.DropTable(
                name: "DesligamentoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GastoModel",
                table: "GastoModel");

            migrationBuilder.DropColumn(
                name: "ComplementoEndereco",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "dataBatismo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "estadoCivil",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "filhos",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "igrejaBatismo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "pastorBatismo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "profissão",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "GastoModel",
                newName: "Gasto");

            migrationBuilder.RenameIndex(
                name: "IX_GastoModel_IdCaixa",
                table: "Gasto",
                newName: "IX_Gasto_IdCaixa");

            migrationBuilder.RenameIndex(
                name: "IX_GastoModel_CaixaModelId",
                table: "Gasto",
                newName: "IX_Gasto_CaixaModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gasto",
                table: "Gasto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasto_Caixa_CaixaModelId",
                table: "Gasto",
                column: "CaixaModelId",
                principalTable: "Caixa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gasto_Caixa_IdCaixa",
                table: "Gasto",
                column: "IdCaixa",
                principalTable: "Caixa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
