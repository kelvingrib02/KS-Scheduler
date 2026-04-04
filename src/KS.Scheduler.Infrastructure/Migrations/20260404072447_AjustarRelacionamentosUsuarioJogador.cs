using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KS.Scheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustarRelacionamentosUsuarioJogador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Jogadores_JogadorId",
                table: "Presencas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Presencas_PartidaId",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Jogadores");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamento",
                table: "Presencas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPorPessoa",
                table: "Partidas",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Partidas",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Posicao",
                table: "Jogadores",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Jogadores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    SenhaHash = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_PartidaId_JogadorId",
                table: "Presencas",
                columns: new[] { "PartidaId", "JogadorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_UsuarioId",
                table: "Jogadores",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Usuarios_UsuarioId",
                table: "Jogadores",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Jogadores_JogadorId",
                table: "Presencas",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Usuarios_UsuarioId",
                table: "Jogadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Jogadores_JogadorId",
                table: "Presencas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Presencas_PartidaId_JogadorId",
                table: "Presencas");

            migrationBuilder.DropIndex(
                name: "IX_Jogadores_UsuarioId",
                table: "Jogadores");

            migrationBuilder.DropColumn(
                name: "DataPagamento",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Jogadores");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorPorPessoa",
                table: "Partidas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Partidas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Posicao",
                table: "Jogadores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Jogadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Jogadores",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_PartidaId",
                table: "Presencas",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Jogadores_JogadorId",
                table: "Presencas",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
