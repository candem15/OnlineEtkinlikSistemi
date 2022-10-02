using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OES.API.Persistence.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1a870f35-5d91-4f58-b7c2-7644f4cba735");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391c72c8-9403-4c93-a4a4-4c2febd00d74",
                column: "ConcurrencyStamp",
                value: "fa9046c8-08d9-46a8-b9c2-d9e436c20324");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9505059f-22c8-4940-9889-52d6d05b5790",
                column: "ConcurrencyStamp",
                value: "dcc5634d-d0c5-4ae9-9dc6-9b67b7ef3a81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b10223db-522e-406f-a738-81e4f1c3ffaf", "AQAAAAEAACcQAAAAECVziwjk1bazeibwNrEdbugMHok/o268XMxbmF9o2Oxj5/qk7qins7g0p9lyTpmhhg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ce2b828b-a838-4029-b8f5-6630525a2851");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391c72c8-9403-4c93-a4a4-4c2febd00d74",
                column: "ConcurrencyStamp",
                value: "aaac9be2-479f-4eaa-8184-ef0f84e104ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9505059f-22c8-4940-9889-52d6d05b5790",
                column: "ConcurrencyStamp",
                value: "503da83b-d064-4017-8651-24a6deedabab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f73601b-02d5-4fd6-b5ab-a0e2476c78ec", "AQAAAAEAACcQAAAAEM9v34Q5LAYiflruSWomkfpKHWJJiRbmHhk03t2wxqEY/laJMxSW1xz1/vaAR3C2lQ==" });
        }
    }
}
