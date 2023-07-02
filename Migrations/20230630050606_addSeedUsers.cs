using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationForTest.Migrations
{
    public partial class addSeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17423714-fb1c-482c-8677-a914ace43b40", "17423714-fb1c-482c-8677-a914ace43b40", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11fa953-09da-4c57-88e6-9bfaf3c46a80",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "cf66faed-063a-439e-ade6-a80838042c70", "admin@gmail.com", "ADMIN@GMAIL.COM", null, "f61ef89a-48db-420d-baaa-74c0a43eeb0b", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CourseId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "17423714-fb1c-482c-8677-a914ace43b40", 0, "a0212df9-e375-42db-8853-1b7c1cea49bc", 0, "user@gmail.com", true, false, null, null, "USER@GMAIL.COM", "AQAAAAEAACcQAAAAELyr36e1S5+bkvyEklvk8UTyFfoIxFNG3IMwdBFE+M81RLENUPk65HbV3BrhkRz/kQ==", null, false, new Guid("00000000-0000-0000-0000-000000000000"), "3f882f63-af10-4ad6-9be4-cc2974b041e1", false, "User" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "17423714-fb1c-482c-8677-a914ace43b40", "17423714-fb1c-482c-8677-a914ace43b40" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "17423714-fb1c-482c-8677-a914ace43b40", "17423714-fb1c-482c-8677-a914ace43b40" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17423714-fb1c-482c-8677-a914ace43b40");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17423714-fb1c-482c-8677-a914ace43b40");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11fa953-09da-4c57-88e6-9bfaf3c46a80",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b9b892e1-adec-4e54-8644-5f0bce7627bb", "frankofoedu@gmail.com", "FRANKOFOEDU@GMAIL.COM", "AQAAAAEAACcQAAAAEClKEp4cG+L4RsFrgqhGTu2JawNAG5+RKmobkiZGzQgQI6bE7Ywi1/RMFghA95EezQ==", "4509ffd5-75d3-473c-a87e-7c62a163a72c", "Frank" });
        }
    }
}