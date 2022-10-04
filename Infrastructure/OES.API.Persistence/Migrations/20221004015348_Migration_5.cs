using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OES.API.Persistence.Migrations
{
    public partial class Migration_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ebdf0073-f432-4098-913d-7bdf9f69cc96");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391c72c8-9403-4c93-a4a4-4c2febd00d74",
                column: "ConcurrencyStamp",
                value: "7f937a39-79f7-4009-9213-aeef1acb60ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9505059f-22c8-4940-9889-52d6d05b5790",
                column: "ConcurrencyStamp",
                value: "beedf7ef-aaca-46d2-b385-de0c4ec63d82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "163941d8-c752-4b7d-83de-ee680e630f91", "admin@admin.com", "AQAAAAEAACcQAAAAEFpCiBdtRVKqMyUD1R14lrCSeytdZVzqSIdUgGM1QSB3PydYrcq0nRkWkKhSn2Nq2w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "96d48e6d-0eef-470f-a0e7-75d1443ffd89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391c72c8-9403-4c93-a4a4-4c2febd00d74",
                column: "ConcurrencyStamp",
                value: "54b3f4f0-608e-487b-a1fd-5545fa9e8b91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9505059f-22c8-4940-9889-52d6d05b5790",
                column: "ConcurrencyStamp",
                value: "c6a2951e-dfda-4d11-8389-899ca582e2b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "1ac1e09a-3cba-4b20-b5b0-b87b89d55890", null, "AQAAAAEAACcQAAAAEIzGWL/DJzIJExxL+AOIfyqD8TUtHKcboGuF56QBlwvj/5EAFPZGwh0tF53K2tPO6g==" });
        }
    }
}
