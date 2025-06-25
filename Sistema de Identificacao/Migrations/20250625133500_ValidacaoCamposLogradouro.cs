using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Identificacao.Migrations
{
    /// <inheritdoc />
    public partial class ValidacaoCamposLogradouro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                table: "Logradouros",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Logradouros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Logradouros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Logradouros",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Logradouros",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Logradouros");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Logradouros");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Logradouros");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Logradouros");

            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                table: "Logradouros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
