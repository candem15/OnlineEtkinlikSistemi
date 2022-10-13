using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OES.API.Persistence.Migrations
{
    public partial class Migration_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "EventConfirmation",
                table: "Events",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "624b48ee-1d38-4d95-8245-dde41a409de4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391c72c8-9403-4c93-a4a4-4c2febd00d74",
                column: "ConcurrencyStamp",
                value: "72899da2-5781-46c6-a3b6-45736a5bd532");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9505059f-22c8-4940-9889-52d6d05b5790",
                column: "ConcurrencyStamp",
                value: "8ef89bb8-2c03-4126-b6ec-ec9763f67f64");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84229bb0-16ff-48b6-937c-70f00cc32f7f", "AQAAAAEAACcQAAAAEJbJQ/ok+048K6FYr612Fl7wS52R33GNkxrQ9vKsLojmJ341PuKIj6XNOPJV8odoRw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "EventConfirmation",
                table: "Events",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b74d34ef-b4f4-4d8c-b6d7-4ac0412e8a36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "391c72c8-9403-4c93-a4a4-4c2febd00d74",
                column: "ConcurrencyStamp",
                value: "5930e08e-3512-49a2-a492-3b60716a1464");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9505059f-22c8-4940-9889-52d6d05b5790",
                column: "ConcurrencyStamp",
                value: "86ea67ef-4a56-44b3-ae0c-283be36c18a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7c9dfbe1-8104-49e2-9b8d-75aecf8a844d", "AQAAAAEAACcQAAAAEO1Nqwfil3PpcOm+uNM1F0j19QvdXoJPE20RlG+37CN7sOamEEzsheo2tlmwuojTxg==" });
        }
    }
}
