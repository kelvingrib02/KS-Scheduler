using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KS.Scheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoIdsEDecimais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Presencas_PartidaId_JogadorId",
                table: "Presencas");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Partidas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Jogadores",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Jogadores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_PartidaId",
                table: "Presencas",
                column: "PartidaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Presencas_PartidaId",
                table: "Presencas");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Partidas",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Jogadores",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Jogadores",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_PartidaId_JogadorId",
                table: "Presencas",
                columns: new[] { "PartidaId", "JogadorId" },
                unique: true);
        }
    }
}
