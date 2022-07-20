using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPanel.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReferansKategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    UstKategoriId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferansKategoriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferansKategoriler_ReferansKategoriler_UstKategoriId",
                        column: x => x.UstKategoriId,
                        principalTable: "ReferansKategoriler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Referanslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisaAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referanslar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referanslar_ReferansKategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "ReferansKategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReferansKategoriler_UstKategoriId",
                table: "ReferansKategoriler",
                column: "UstKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Referanslar_KategoriId",
                table: "Referanslar",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Referanslar");

            migrationBuilder.DropTable(
                name: "ReferansKategoriler");
        }
    }
}
