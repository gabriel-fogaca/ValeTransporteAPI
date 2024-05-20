using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValeControl.API.Migrations
{
    /// <inheritdoc />
    public partial class EscalaTrabalho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EscalaDeTrabalho",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "EscalaId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                column: "EscalaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "EscalaId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "EscalaId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "EscalaId",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalasTrabalho");

            migrationBuilder.DropColumn(
                name: "EscalaId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<string>(
                name: "EscalaDeTrabalho",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "EscalaDeTrabalho",
                value: "5x2");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "EscalaDeTrabalho",
                value: "6x1");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "EscalaDeTrabalho",
                value: "6x2");

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "EscalaDeTrabalho",
                value: "12x36");
        }
    }
}
