using Microsoft.EntityFrameworkCore.Migrations;

namespace NerdStore.Vendas.Data.Migrations
{
    public partial class MudancaSchemaVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Vouchers",
                newName: "Vouchers",
                newSchema: "Venda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Vouchers",
                schema: "Venda",
                newName: "Vouchers");
        }
    }
}
