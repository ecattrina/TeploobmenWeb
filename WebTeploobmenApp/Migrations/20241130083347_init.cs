using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTeploobmenApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataInput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Visotasloy = table.Column<double>(type: "REAL", nullable: false),
                    Nachtempgas = table.Column<double>(type: "REAL", nullable: false),
                    Nachtempmaterial = table.Column<double>(type: "REAL", nullable: false),
                    Skorostgas = table.Column<double>(type: "REAL", nullable: false),
                    Sredtemplogas = table.Column<double>(type: "REAL", nullable: false),
                    Rashodmaterial = table.Column<double>(type: "REAL", nullable: false),
                    Teploemmaterial = table.Column<double>(type: "REAL", nullable: false),
                    Kofteplo = table.Column<double>(type: "REAL", nullable: false),
                    Diametrapparata = table.Column<double>(type: "REAL", nullable: false),
                    Ycoordinate = table.Column<double>(type: "REAL", nullable: false),
                    OperationType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataInput", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataInput");
        }
    }
}
