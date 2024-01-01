using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateCodeEncryption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a338f465-530c-4050-a554-592d055a3c3a", "AQAAAAIAAYagAAAAEMzXlv/vy+KoKKQPDlEdnWBbcoBBq7z0hdcTe/xsxRQkEh157a4ZpA5lNNiU3MoOHw==", "02da28d2-4eef-4bbe-bb59-a4959147120b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71db9566-c6ff-488e-8c96-ac1d9a1e8570", "AQAAAAIAAYagAAAAEIzvyqDtHYAnWGFQ8II2CjxpXZ7cT9HybF09zhWx4wLufdp+ADizWsHSY1VZd8BY+A==", "c57aca83-dcd5-40f9-97b7-07df2edd6749" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdcbe2ff-b370-4e96-9f8b-c566802e38ea", "AQAAAAIAAYagAAAAEN/8KdA12tc7nXksZz5RTouThVaE7HsHd6igDBl/O2t5MMDR+5li2Zyks8GEuGupDw==", "70ec8913-3bcb-44fc-ad85-3f5ffdadc33f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb8c889d-5a07-46ea-a29f-b12cbe40d0e1", "AQAAAAIAAYagAAAAEJirQn2hiWN4jbojmFTR1fjGf32Ram6WqYdNntZvGppLcXhvmWESG5CAl9aArJCcuQ==", "305c03b7-9d53-4256-a4d3-a7477075a31a" });
        }
    }
}
