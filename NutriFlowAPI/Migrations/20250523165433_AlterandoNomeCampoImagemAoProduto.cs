using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutriFlowAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoNomeCampoImagemAoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemUrl",
                table: "Produtos",
                newName: "Imagem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "Produtos",
                newName: "ImagemUrl");
        }
    }
}
