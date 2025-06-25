using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Identificacao.Migrations
{
    /// <inheritdoc />
    public partial class CampoCepLogradouro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Logradouros",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Logradouros");
        }
    }
}
