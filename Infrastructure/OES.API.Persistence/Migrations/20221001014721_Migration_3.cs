using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OES.API.Persistence.Migrations
{
    public partial class Migration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "AspNetUsers",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c675b5e2-214a-45a1-b790-2141d102e409");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391c72c8-9403-4c93-a4a4-4c2febd00d74",
                column: "ConcurrencyStamp",
                value: "2c82decb-3b17-4342-b6fc-3e794e224ef2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9505059f-22c8-4940-9889-52d6d05b5790",
                column: "ConcurrencyStamp",
                value: "95dd1c55-f7a4-4ee8-8eec-896dd5a0e63a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88af6c0a-4f84-4f3b-a10e-deb5393d9c1e", "AQAAAAEAACcQAAAAED4/BonoPoINEWFT+JMIVLTItMRBrMYQEmIis2dxrTeb+NGb6inaCxnCe7zx5RWqtA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "Ad");

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
    }
}
