using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValeControl.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFuncionarioEscalaEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalasTrabalho");

            migrationBuilder.RenameColumn(
                name: "EscalaId",
                table: "Funcionarios",
                newName: "Escala");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ativo",
                value: false);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ativo",
                value: false);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ativo",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Escala",
                table: "Funcionarios",
                newName: "EscalaId");

            migrationBuilder.CreateTable(
                name: "EscalasTrabalho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalasTrabalho", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EscalasTrabalho",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "5x2" },
                    { 2, "6x1" },
                    { 3, "6x2" },
                    { 4, "12x36" }
                });

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ativo",
                value: true);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ativo",
                value: true);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ativo",
                value: true);
        }
    }
}
