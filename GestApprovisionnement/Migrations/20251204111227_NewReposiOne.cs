using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestApprovisionnement.Migrations
{
    /// <inheritdoc />
    public partial class NewReposiOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvisionnements_Article_ArticleId",
                table: "Approvisionnements");

            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Approvisionnements");

            migrationBuilder.AlterColumn<int>(
                name: "Quantite",
                table: "Article",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "QuantiteStock",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Approvisionnements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Observations",
                table: "Approvisionnements",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApprovisionnementId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Approvisionnements_ApprovisionnementId",
                        column: x => x.ApprovisionnementId,
                        principalTable: "Approvisionnements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ApprovisionnementId",
                table: "Details",
                column: "ApprovisionnementId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ArticleId",
                table: "Details",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvisionnements_Article_ArticleId",
                table: "Approvisionnements",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvisionnements_Article_ArticleId",
                table: "Approvisionnements");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropColumn(
                name: "QuantiteStock",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Observations",
                table: "Approvisionnements");

            migrationBuilder.AlterColumn<string>(
                name: "Quantite",
                table: "Article",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Approvisionnements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Approvisionnements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvisionnements_Article_ArticleId",
                table: "Approvisionnements",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
