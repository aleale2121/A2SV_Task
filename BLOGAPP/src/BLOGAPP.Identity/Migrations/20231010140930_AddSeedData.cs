using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOGAPP.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b0fc139-ddab-4952-b172-4c072b658a3d", "AQAAAAIAAYagAAAAEGMy/vHhqqg0sZAJfRX4Od5t796pP8LRFPjB0g+jbzD71bZUVyZmjByWC4xZ4UO8Kg==", "e6f0034c-d335-413a-bbfe-ab4460e09f6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a5e5ace-cc65-4140-922e-567b48773c31", "AQAAAAIAAYagAAAAEOXyArHKtCAUe5mJMXNo549rjMQt8DMIbH4ycXVGQclYhB9KzsI25ozCIJ1YqBCMGw==", "4b59e89d-0ba0-4edd-9d96-4833bef37c74" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b61a6e7-781e-4ada-aa10-7121413d2733", "AQAAAAIAAYagAAAAELFmJEMOYZJc4DZ1M/MTxf/h+VAzdVYclRpP0v/W1GYc4D5HJo9ZuHolME60eFYOPw==", "48ffed99-941a-4d32-8cd3-1ea6d76c5e90" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f4105a8-5b1b-4a21-94e2-25ef994dc30c", "AQAAAAIAAYagAAAAEIriDKH00LQ/fUlMq+e+nw4cNd3G+xknXRRZ6RIcFq2SLfny6Q+jCH55VHtilyhCYQ==", "c6c98de0-2bae-4ed2-9dd4-5ab76a2e984a" });
        }
    }
}
