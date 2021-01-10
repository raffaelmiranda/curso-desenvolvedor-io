using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Catalogo.Data.Migrations
{
    public partial class MudancaSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalogo");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produtos",
                newSchema: "Catalogo");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categorias",
                newSchema: "Catalogo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Produtos",
                schema: "Catalogo",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "Categorias",
                schema: "Catalogo",
                newName: "Categorias");
        }
    }
}
