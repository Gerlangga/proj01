using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proj01.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KalkulatorModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Angkasatu = table.Column<int>(type: "int", nullable: false),
                    Operasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Angkadua = table.Column<int>(type: "int", nullable: false),
                    Hasil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KalkulatorModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KalkulatorModel");
        }
    }
}
