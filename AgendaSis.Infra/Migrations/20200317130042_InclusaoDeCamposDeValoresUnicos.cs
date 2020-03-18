using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaSis.Infra.Migrations
{
    public partial class InclusaoDeCamposDeValoresUnicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CPF",
                table: "Pessoa",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CNPJ",
                table: "Pessoa",
                column: "CNPJ",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoa_CPF",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_CNPJ",
                table: "Pessoa");
        }
    }
}
