using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "Code", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "cdcbe2ff-b370-4e96-9f8b-c566802e38ea", "AQAAAAIAAYagAAAAEN/8KdA12tc7nXksZz5RTouThVaE7HsHd6igDBl/O2t5MMDR+5li2Zyks8GEuGupDw==", "70ec8913-3bcb-44fc-ad85-3f5ffdadc33f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "Code", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "fb8c889d-5a07-46ea-a29f-b12cbe40d0e1", "AQAAAAIAAYagAAAAEJirQn2hiWN4jbojmFTR1fjGf32Ram6WqYdNntZvGppLcXhvmWESG5CAl9aArJCcuQ==", "305c03b7-9d53-4256-a4d3-a7477075a31a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25fad9f6-7b96-46e2-ae45-82c21e486ce2", "AQAAAAIAAYagAAAAEA+kB1FWyEQYKiJqRkZvgTCbbIPIXdROXLJZYIFobRoG3Yt4Ydt8poLoh9pRf8MsmA==", "792163a0-3d18-49d6-bed2-5b833044ff6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75c29620-594f-4ce7-a685-f97ef4667d99", "AQAAAAIAAYagAAAAED0YMZL3NlQgCRJzKUgDlpjLEZDV8v0g9qT4pbpYDFqDsif4y8dYYJqoRB4ttSl3Cw==", "a2761cf6-bc5e-41c8-b923-9ac43e7ce082" });
        }
    }
}
