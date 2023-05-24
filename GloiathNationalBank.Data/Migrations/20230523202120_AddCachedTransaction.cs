using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GloiathNationalBank.Data.Migrations
{
    public partial class AddCachedTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CachedTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sku = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    IsUpToDate = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CachedTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sku = table.Column<string>(type: "TEXT", nullable: false),
                    MyProperty = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSummaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    From = table.Column<string>(type: "TEXT", nullable: false),
                    To = table.Column<string>(type: "TEXT", nullable: false),
                    RateValue = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sku = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "From", "RateValue", "To" },
                values: new object[] { 1, "EUR", 1.359m, "USD" });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "From", "RateValue", "To" },
                values: new object[] { 2, "CAD", 0.732m, "EUR" });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "From", "RateValue", "To" },
                values: new object[] { 3, "USD", 0.736m, "EUR" });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "From", "RateValue", "To" },
                values: new object[] { 4, "EUR", 1.366m, "CAD" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Currency", "Sku" },
                values: new object[] { 1, 10.00m, "USD", "T2006" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Currency", "Sku" },
                values: new object[] { 2, 34.57m, "CAD", "M2007" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Currency", "Sku" },
                values: new object[] { 3, 17.95m, "USD", "R2008" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Currency", "Sku" },
                values: new object[] { 4, 7.63m, "EUR", "T2006" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Currency", "Sku" },
                values: new object[] { 5, 21.23m, "USD", "B2009" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CachedTransactions");

            migrationBuilder.DropTable(
                name: "ProductSummaries");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
