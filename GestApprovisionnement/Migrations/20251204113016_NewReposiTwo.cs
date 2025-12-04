using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestApprovisionnement.Migrations
{
    /// <inheritdoc />
    public partial class NewReposiTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvisionnements_Article_ArticleId",
                table: "Approvisionnements");

            migrationBuilder.DropIndex(
                name: "IX_Approvisionnements_ArticleId",
                table: "Approvisionnements");

            migrationBuilder.DropColumn(
                name: "PrixUnitaire",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "montant",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Approvisionnements");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrixUnitaire",
                table: "Article",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "montant",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Approvisionnements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Approvisionnements_ArticleId",
                table: "Approvisionnements",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvisionnements_Article_ArticleId",
                table: "Approvisionnements",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id");
        }
    }
}
