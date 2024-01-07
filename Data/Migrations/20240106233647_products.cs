using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cse355.Data.Migrations
{
    /// <inheritdoc />
    public partial class products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerticalSectionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerticalSectionSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alloy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificWeightInKG = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LengthInMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightOnePieceInKG = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
