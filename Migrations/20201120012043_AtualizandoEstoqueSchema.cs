using Microsoft.EntityFrameworkCore.Migrations;

namespace Sismarket.Migrations
{
    public partial class AtualizandoEstoqueSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId",
                table: "Estoques");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Estoques",
                newName: "ProdutoID");

            migrationBuilder.RenameIndex(
                name: "IX_Estoques_ProdutoId",
                table: "Estoques",
                newName: "IX_Estoques_ProdutoID");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoID",
                table: "Estoques",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produtos_ProdutoID",
                table: "Estoques",
                column: "ProdutoID",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produtos_ProdutoID",
                table: "Estoques");

            migrationBuilder.RenameColumn(
                name: "ProdutoID",
                table: "Estoques",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Estoques_ProdutoID",
                table: "Estoques",
                newName: "IX_Estoques_ProdutoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Estoques",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId",
                table: "Estoques",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
