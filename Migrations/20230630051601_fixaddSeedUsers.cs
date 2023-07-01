using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationForTest.Migrations
{
    public partial class fixaddSeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17423714-fb1c-482c-8677-a914ace43b40",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a7b83ed-1dff-4ea0-b155-af76b58ebdb1", "AQAAAAEAACcQAAAAEATBc4GbtusjgFyTDTmt8RX22FJPKK8r+SO15Cr98kv2EpiVnCNZxA7AtaGbnlnyLg==", "1c55f6fd-0aff-4057-84ca-390a7202faee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11fa953-09da-4c57-88e6-9bfaf3c46a80",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32ca8716-e118-41a7-9f1a-fcb34265c8e9", "AQAAAAEAACcQAAAAEGn97OG/zfkg5GLBgjtyOgoOZG4i/Qxjp1sFBAQSYFmSzd22ILQXTDMwLYxAPcfwgw==", "7f25b25c-88e4-421a-a7b8-a77f064c85fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17423714-fb1c-482c-8677-a914ace43b40",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0212df9-e375-42db-8853-1b7c1cea49bc", "AQAAAAEAACcQAAAAELyr36e1S5+bkvyEklvk8UTyFfoIxFNG3IMwdBFE+M81RLENUPk65HbV3BrhkRz/kQ==", "3f882f63-af10-4ad6-9be4-cc2974b041e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11fa953-09da-4c57-88e6-9bfaf3c46a80",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf66faed-063a-439e-ade6-a80838042c70", null, "f61ef89a-48db-420d-baaa-74c0a43eeb0b" });
        }
    }
}
