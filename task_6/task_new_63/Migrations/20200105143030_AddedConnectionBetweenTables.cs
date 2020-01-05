using Microsoft.EntityFrameworkCore.Migrations;

namespace task_new_63.Migrations
{
    public partial class AddedConnectionBetweenTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Perfumes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perfumes_BrandId",
                table: "Perfumes",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfumes_Brands_BrandId",
                table: "Perfumes",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfumes_Brands_BrandId",
                table: "Perfumes");

            migrationBuilder.DropIndex(
                name: "IX_Perfumes_BrandId",
                table: "Perfumes");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Perfumes");
        }
    }
}
